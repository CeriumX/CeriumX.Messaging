//=========================================================================
//**   消息队列服务产品中间件和消息队列服务总线（CeriumX.Messaging）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：MessageHandlerBase.cs
// 项目名称：消息队列服务产品中间件和消息队列服务总线
// 创建时间：2022-10-09 23:46:33
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
/// 消息接收处理基类
/// </summary>
/// <typeparam name="TMessage">消息流转泛型</typeparam>
public sealed class MessageHandlerBase<TMessage> : IMessageHandler<TMessage>
    where TMessage : class
{
    private readonly Func<MessageReceivedMsgArgs<TMessage>, Task> _handler;


    /// <summary>
    /// 消息接收处理基类
    /// </summary>
    /// <param name="callback">消息接收处理回调函数</param>
    public MessageHandlerBase(Func<MessageReceivedMsgArgs<TMessage>, Task> callback)
    {
        _handler = callback;
    }


    #region 接口实现[IMessageHandler]

    /// <summary>
    /// 接收消息
    /// </summary>
    /// <param name="e">消息接收事件参数</param>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public Task OnReceivedAsync(MessageReceivedMsgArgs<TMessage> e) => _handler.Invoke(e);

    #endregion

}