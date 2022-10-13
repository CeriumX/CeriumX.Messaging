//=========================================================================
//**   消息队列服务产品中间件和消息队列服务总线（CeriumX.Messaging）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：SubscribeManager.cs
// 项目名称：消息队列服务产品中间件和消息队列服务总线
// 创建时间：2022-10-10 12:52:40
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System.Collections.Concurrent;

namespace CeriumX.Messaging.LocalMQ;

/// <summary>
/// 订阅管理者
/// </summary>
internal sealed class SubscribeManager : IAsyncDisposable
{
    private readonly ConcurrentDictionary<string, IList<IMessageToken>> _subscribeList = new();
    private readonly MessageContext _context;


    /// <summary>
    /// 订阅管理者
    /// </summary>
    /// <param name="context">消息队列服务上下文</param>
    internal SubscribeManager(MessageContext context)
    {
        _context = context;
    }


    /// <summary>
    /// 获取消息队列订阅令牌枚举列表
    /// </summary>
    /// <param name="topic">消息主题</param>
    /// <returns>消息队列订阅令牌枚举列表</returns>
    internal IEnumerable<IMessageToken>? this[string topic]
    {
        get
        {
            if (_subscribeList.TryGetValue(topic, out IList<IMessageToken>? result))
            {
                return result;
            }
            return default;
        }
    }

    /// <summary>
    /// 消息队列服务中所有订阅主题枚举列表
    /// </summary>
    internal IEnumerable<string> CurrentSubscribes => _subscribeList.Keys;


    #region 成员方法

    /// <summary>
    /// 消息订阅
    /// </summary>
    /// <typeparam name="TMessage">消息流转泛型</typeparam>
    /// <param name="topic">消息主题</param>
    /// <param name="messageHandler">消息接收处理回调函数</param>
    /// <returns>消息队列订阅令牌</returns>
    internal IMessageToken Subscribe<TMessage>(string topic, IMessageHandler<TMessage> messageHandler)
        where TMessage : class
    {
        MessageToken<TMessage> token = new(topic, messageHandler, UnSubscribeAsync);

        if (_subscribeList.TryGetValue(topic, out IList<IMessageToken>? tokenList))
        {
            tokenList.Add(token);
        }
        else
        {
            Interlocked.Exchange(ref tokenList, new List<IMessageToken> { token });
            _subscribeList[topic] = tokenList;
        }

        _context.Logger.Info($"收到新的消息订阅请求，消息主题（{topic}）已接收。");

        return token;
    }

    /// <summary>
    /// 消息反订阅
    /// </summary>
    /// <param name="messageToken">消息队列订阅令牌</param>
    private async Task UnSubscribeAsync(IMessageToken messageToken)
    {
        IList<IMessageToken>? tokenList = _subscribeList.Values.SingleOrDefault(p => p == messageToken);

        if (tokenList is not null && tokenList.Any())
        {
            lock (_subscribeList)
            {
                tokenList.Remove(messageToken);
            }

            _context.Logger.Info($"收到消息反订阅请求，订阅名称（{messageToken.Topic}）已处理。");
        }

        await Task.Delay(0).ConfigureAwait(false);
    }

    /// <summary>
    /// 消息投递
    /// </summary>
    /// <param name="msgInfo">内部消息流转实体</param>
    /// <returns>An object that represents the current operation.</returns>
    internal async Task DispatchMessage(MessageInfo msgInfo)
    {
        _context.Logger.Debug($"消息投递[Id: {_context.ServiceId}] - {msgInfo.Topic}：{msgInfo.DispatchMessage}");

        if (_subscribeList.TryGetValue(msgInfo.Topic, out IList<IMessageToken>? tokenList))
        {
            for (int i = 0, iLen = tokenList.Count; i < iLen; i++)
            {
                if (tokenList[i] is MessageTokenBase token)
                {
                    await token.OnReceivedAsync(msgInfo).ConfigureAwait(false);
                }

                // 销毁调用方messagehandler，反订阅之后数组变短，避免索引越界。
                if (tokenList.Count < iLen)
                {
                    i--;
                    iLen = tokenList.Count;
                }
            }
        }
    }

    #endregion

    /// <summary>
    /// 资源释放
    /// </summary>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public async ValueTask DisposeAsync()
    {
        _context.Logger.Info($"订阅者管理器开始释放资源[Id: {_context.ServiceId}]。");

        foreach (IList<IMessageToken> tokenList in _subscribeList.Values)
        {
            if (tokenList is not null && tokenList.Any())
            {
                foreach (IMessageToken token in tokenList)
                {
                    await token.UnSubscribeAsync().ConfigureAwait(false);
                }

                tokenList.Clear();
            }
        }

        _subscribeList.Clear();

        _context.Logger.Info($"订阅者管理器释放资源结束[Id: {_context.ServiceId}]。");
    }
}