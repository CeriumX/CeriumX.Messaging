//=========================================================================
//**   消息队列服务产品中间件和消息队列服务总线（CeriumX.Messaging）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：IMessageService.cs
// 项目名称：消息队列服务产品中间件和消息队列服务总线
// 创建时间：2022-10-09 23:34:47
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace CeriumX.Messaging.Abstractions;

/// <summary>
/// 消息队列服务接口
/// </summary>
public interface IMessageService : IAsyncDisposable
{
    /// <summary>
    /// 服务标识
    /// </summary>
    string Id { get; }

    /// <summary>
    /// 创建时间
    /// </summary>
    DateTime Time { get; }

    /// <summary>
    /// 服务端中所有订阅主题枚举列表
    /// </summary>
    IEnumerable<string> ServerSubscribes { get; }

    /// <summary>
    /// 消息队列服务中所有订阅主题枚举列表
    /// </summary>
    IEnumerable<string> CurrentSubscribes { get; }


    /// <summary>
    /// 订阅消息
    /// </summary>
    /// <typeparam name="TMessage">消息流转泛型</typeparam>
    /// <param name="topic">消息主题</param>
    /// <param name="messageHandler">消息接收处理回调函数</param>
    /// <returns>消息队列订阅令牌</returns>
    IMessageToken Subscribe<TMessage>(string topic, IMessageHandler<TMessage> messageHandler)
        where TMessage : class;

    /// <summary>
    /// 发送消息
    /// </summary>
    /// <typeparam name="TMessage">消息流转泛型</typeparam>
    /// <param name="topic">消息主题</param>
    /// <param name="messageData">需要发送的消息(泛型对象)</param>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    ValueTask SendAsync<TMessage>(string topic, TMessage messageData)
        where TMessage : class;

    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="topic">消息主题</param>
    /// <param name="messageData">需要发送的消息(字节数组)</param>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    ValueTask SendAsync(string topic, byte[] messageData);
}