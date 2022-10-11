//=========================================================================
//**   消息队列服务产品中间件和消息队列服务总线（CeriumX.Messaging）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：MessageProducer.cs
// 项目名称：消息队列服务产品中间件和消息队列服务总线
// 创建时间：2022-10-10 12:47:48
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

namespace CeriumX.Messaging.LocalMQ;

/// <summary>
/// 消息生产者
/// </summary>
internal sealed class MessageProducer : IAsyncDisposable
{
    private readonly MessageContext _context;


    /// <summary>
    /// 消息生产者
    /// </summary>
    /// <param name="context">消息服务上下文</param>
    internal MessageProducer(MessageContext context)
    {
        _context = context;
        _context.Logger.Info($"消息生产者初始化成功[Id: {_context.ServiceId}]。");
    }


    /// <summary>
    /// 发送消息
    /// </summary>
    /// <typeparam name="TMessage">消息流转泛型</typeparam>
    /// <param name="topic">消息主题</param>
    /// <param name="messageData">需要发送的消息(泛型对象)</param>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    internal async ValueTask SendAsync<TMessage>(string topic, TMessage messageData)
        where TMessage : class
    {
        bool isDispatchObject = typeof(TMessage).GetInterfaces().Any(p => p.Equals(typeof(IMessageObjectData)));

        if (isDispatchObject)
        {
            // 对象直接入队
            _context.CurrentMessageManager.EnqueueMessage(MessageInfo.Create(topic, messageData as IMessageObjectData));
        }
        else
        {
            // 序列化后入队
            byte[] messageArray = JsonSerializer.SerializeToUtf8Bytes(messageData);
            await SendAsync(topic, messageArray).ConfigureAwait(false);
        }

        await Task.Delay(0).ConfigureAwait(false);
    }

    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="topic">消息主题</param>
    /// <param name="messageData">需要发送的消息(字节数组)</param>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    internal async ValueTask SendAsync(string topic, byte[] messageData)
    {
        _context.CurrentMessageManager.EnqueueMessage(MessageInfo.Create(topic, messageData));
        await Task.Delay(0).ConfigureAwait(false);
    }

    /// <summary>
    /// 资源释放
    /// </summary>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public async ValueTask DisposeAsync()
    {
        await Task.Delay(0).ConfigureAwait(false);
    }
}