//=========================================================================
//**   消息队列服务产品中间件和消息队列服务总线（CeriumX.Messaging）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：MessageToken.cs
// 项目名称：消息队列服务产品中间件和消息队列服务总线
// 创建时间：2022-10-09 23:52:29
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System.Text.Json;

namespace CeriumX.Messaging.Abstractions;

/// <summary>
/// 消息队列订阅令牌
/// </summary>
/// <typeparam name="TMessage">消息流转泛型</typeparam>
internal sealed class MessageToken<TMessage> : MessageTokenBase
    where TMessage : class
{
    /// <summary>
    /// 消息接收处理事件
    /// </summary>
    private readonly IMessageHandler<TMessage> _messageHandler;

    /// <summary>
    /// 消息反订阅回调函数
    /// </summary>
    private readonly Func<IMessageToken, Task> _unsubscribeCallback;


    /// <summary>
    /// 消息队列订阅令牌
    /// </summary>
    /// <param name="topic">消息主题</param>
    /// <param name="messageHandler">消息接收处理事件</param>
    /// <param name="unsubscribeCallback">消息反订阅回调函数</param>
    internal MessageToken(string topic, IMessageHandler<TMessage> messageHandler, Func<IMessageToken, Task> unsubscribeCallback)
        : base(topic)
    {
        _messageHandler = messageHandler;
        _unsubscribeCallback = unsubscribeCallback;
    }


    /// <summary>
    /// 反订阅
    /// </summary>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public override async Task UnSubscribeAsync()
    {
        if (_unsubscribeCallback is not null)
        {
            await _unsubscribeCallback.Invoke(this).ConfigureAwait(false);
        }
    }

    /// <summary>
    /// 接收消息
    /// </summary>
    /// <param name="info">内部消息流转实体</param>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    internal override async Task OnReceivedAsync(MessageInfo info)
    {
        if (info.DispatchObject is not null)
        {
            MessageReceivedMsgArgs<TMessage> e = new(info.Topic)
            {
                RawData = info.DispatchMessage,
                MessageData = info.DispatchObject as TMessage
            };

            await _messageHandler.OnReceivedAsync(e).ConfigureAwait(false);
        }

        if (info.DispatchMessage is not null)
        {
            MessageReceivedMsgArgs<TMessage> e = new(info.Topic)
            {
                RawData = info.DispatchMessage,
                MessageData = default
            };

            bool isEmptyData = typeof(TMessage).GetInterfaces().Any(p => p.Equals(typeof(IMessageEmptyData)));

            if (!isEmptyData)
            {
                e.MessageData = JsonSerializer.Deserialize<TMessage>(GetBuffer(info.DispatchMessage));
            }

            await _messageHandler.OnReceivedAsync(e).ConfigureAwait(false);
        }


        static ReadOnlySpan<byte> GetBuffer(byte[] buffer) => new(buffer);
    }
}