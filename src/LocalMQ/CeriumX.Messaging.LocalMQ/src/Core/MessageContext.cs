//=========================================================================
//**   消息队列服务产品中间件和消息队列服务总线（CeriumX.Messaging）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：MessageContext.cs
// 项目名称：消息队列服务产品中间件和消息队列服务总线
// 创建时间：2022-10-10 11:28:31
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace CeriumX.Messaging.LocalMQ;

/// <summary>
/// 消息队列服务上下文
/// </summary>
internal sealed class MessageContext : IAsyncDisposable
{
    /// <summary>
    /// 消息队列服务上下文
    /// </summary>
    /// <param name="options">消息队列创建选项(参数)</param>
    internal MessageContext(MessageOptions options)
    {
        string ruleName = options.NLogRulePrefixName is null ? "MessagingMQ" : options.NLogRulePrefixName;
        Logger = NLog.LogManager.GetLogger($"{ruleName}.Cockroach.{options.Id ?? ServiceId}");

        Logger.Info($"实例化本地化消息队列服务产品中间件上下文对象[Id: {ServiceId}]。");

        CurrentOptions = options;

        CurrentSubscribeManager = new SubscribeManager(this);
        CurrentMessageManager = new MessageManager(this);
        CurrentMessageProducer = new MessageProducer(this);
    }


    /// <summary>
    /// 服务标识
    /// </summary>
    internal string ServiceId { get; } = CommonHelper.NewGUID();

    /// <summary>
    /// 日志记录器
    /// </summary>
    internal NLog.Logger Logger { get; }

    /// <summary>
    /// 消息队列创建选项(参数)
    /// </summary>
    internal MessageOptions CurrentOptions { get; }

    /// <summary>
    /// 订阅管理者
    /// </summary>
    internal SubscribeManager CurrentSubscribeManager { get; }

    /// <summary>
    /// 消息管理者
    /// </summary>
    internal MessageManager CurrentMessageManager { get; }

    /// <summary>
    /// 消息生产者
    /// </summary>
    internal MessageProducer CurrentMessageProducer { get; }


    /// <summary>
    /// 资源释放
    /// </summary>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public async ValueTask DisposeAsync()
    {
        Logger.Info($"开始释放消息队列服务上下文资源。");

        // 释放订阅管理者
        if (CurrentSubscribeManager is not null)
        {
            await CurrentSubscribeManager.DisposeAsync().ConfigureAwait(false);
        }

        // 释放消息管理者
        if (CurrentMessageManager is not null)
        {
            await CurrentMessageManager.DisposeAsync().ConfigureAwait(false);
        }

        // 释放消息生产者
        if (CurrentMessageProducer is not null)
        {
            await CurrentMessageProducer.DisposeAsync().ConfigureAwait(false);
        }

        Logger.Info($"消息队列服务上下文资源释放完成。");
    }
}