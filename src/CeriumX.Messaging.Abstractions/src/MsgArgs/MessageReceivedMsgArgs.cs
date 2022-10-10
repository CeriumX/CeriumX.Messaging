//=========================================================================
//**   消息队列服务产品中间件和消息队列服务总线（CeriumX.Messaging）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：MessageReceivedMsgArgs.cs
// 项目名称：消息队列服务产品中间件和消息队列服务总线
// 创建时间：2022-10-09 23:44:16
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
/// 消息接收事件参数类
/// </summary>
/// <typeparam name="TMessage">消息流转泛型</typeparam>
public sealed class MessageReceivedMsgArgs<TMessage> : EventArgs
    where TMessage : class
{
    /// <summary>
    /// 消息接收事件参数
    /// </summary>
    /// <param name="topic">消息主题</param>
    public MessageReceivedMsgArgs(string topic)
    {
        Topic = topic;
    }


    /// <summary>
    /// 消息主题
    /// </summary>
    public string Topic { get; }

    /// <summary>
    /// 原始数据
    /// </summary>
    public byte[]? RawData { get; set; }

    /// <summary>
    /// 消息流转数据
    /// </summary>
    public TMessage? MessageData { get; set; }
}