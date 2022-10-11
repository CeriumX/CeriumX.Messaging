//=========================================================================
//**   消息队列服务产品中间件和消息队列服务总线（CeriumX.Messaging）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：MessageService.cs
// 项目名称：消息队列服务产品中间件和消息队列服务总线
// 创建时间：2022-10-10 11:57:02
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
/// 消息队列服务
/// </summary>
internal sealed class MessageService : IMessageService
{
    private readonly MessageContext _context;


    /// <summary>
    /// 消息队列服务
    /// </summary>
    /// <param name="context">消息队列服务上下文</param>
    internal MessageService(MessageContext context)
    {
        _context = context;
        _context.Logger.Info($"成功创建消息队列服务[Id: {Id}]。");
    }


    #region 接口实现[IMessageService]

    /// <summary>
    /// 服务标识
    /// </summary>
    public string Id => _context.ServiceId;

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime Time { get; } = DateTime.Now;

    /// <summary>
    /// 服务端中所有订阅主题枚举列表
    /// </summary>
    public IEnumerable<string> ServerSubscribes => _context.CurrentSubscribeManager.CurrentSubscribes;

    /// <summary>
    /// 消息队列服务中所有订阅主题枚举列表
    /// </summary>
    public IEnumerable<string> CurrentSubscribes => _context.CurrentSubscribeManager.CurrentSubscribes;


    /// <summary>
    /// 订阅消息
    /// </summary>
    /// <typeparam name="TMessage">消息流转泛型</typeparam>
    /// <param name="topic">消息主题</param>
    /// <param name="messageHandler">消息接收处理回调函数</param>
    /// <returns>消息队列订阅令牌</returns>
    public IMessageToken Subscribe<TMessage>(string topic, IMessageHandler<TMessage> messageHandler)
        where TMessage : class
        => _context.CurrentSubscribeManager.Subscribe(topic, messageHandler);

    /// <summary>
    /// 发送消息
    /// </summary>
    /// <typeparam name="TMessage">消息流转泛型</typeparam>
    /// <param name="topic">消息主题</param>
    /// <param name="messageData">需要发送的消息(泛型对象)</param>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public async ValueTask SendAsync<TMessage>(string topic, TMessage messageData)
        where TMessage : class
        => await _context.CurrentMessageProducer.SendAsync(topic, messageData).ConfigureAwait(false);

    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="topic">消息主题</param>
    /// <param name="messageData">需要发送的消息(字节数组)</param>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public async ValueTask SendAsync(string topic, byte[] messageData)
        => await _context.CurrentMessageProducer.SendAsync(topic, messageData).ConfigureAwait(false);

    /// <summary>
    /// 资源释放
    /// </summary>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public async ValueTask DisposeAsync()
    {
        _context.Logger.Info($"开始放消息队列服务释资源[Id: {Id}]。");

        await _context.DisposeAsync().ConfigureAwait(false);

        _context.Logger.Info($"消息队列服务释放资源结束[Id: {Id}]。");

        NLog.LogManager.Shutdown();
    }

    #endregion

}