//=========================================================================
//**   消息队列服务产品中间件和消息队列服务总线（CeriumX.Messaging）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：MessageInfo.cs
// 项目名称：消息队列服务产品中间件和消息队列服务总线
// 创建时间：2022-10-09 16:11:24
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
/// 内部消息流转实体类
/// </summary>
[Serializable]
internal sealed class MessageInfo
{
    /// <summary>
    /// 内部消息流转实体类
    /// </summary>
    /// <param name="topic">消息主题</param>
    internal MessageInfo(string topic) => Topic = topic;


    /// <summary>
    /// 消息主题
    /// </summary>
    internal string Topic { get; }

    /// <summary>
    /// 需要投递的消息
    /// </summary>
    internal byte[]? DispatchMessage { get; set; }

    /// <summary>
    /// 需要投递的对象
    /// </summary>
    /// <remarks>NOTE：仅限LocalMQ支持。</remarks>
    internal IMessageObjectData? DispatchObject { get; set; }


    /// <summary>
    /// 创建内部消息流转实体
    /// </summary>
    /// <param name="topic">消息主题</param>
    /// <param name="dispatchMessage">需要投递的消息</param>
    /// <returns>内部消息流转实体</returns>
    internal static MessageInfo Create(string topic, byte[] dispatchMessage)
    {
        return new MessageInfo(topic)
        {
            DispatchMessage = dispatchMessage
        };
    }

    /// <summary>
    /// 创建内部消息流转实体
    /// </summary>
    /// <remarks>NOTE：仅限LocalMQ支持。</remarks>
    /// <param name="topic">消息主题</param>
    /// <param name="dispatchObject">需要投递的对象</param>
    /// <returns>内部消息流转实体</returns>
    internal static MessageInfo Create(string topic, IMessageObjectData? dispatchObject)
    {
        return new MessageInfo(topic)
        {
            DispatchObject = dispatchObject
        };
    }
}