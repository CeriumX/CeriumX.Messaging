//=========================================================================
//**   消息队列服务产品中间件和消息队列服务总线（CeriumX.Messaging）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：MessageTokenBase.cs
// 项目名称：消息队列服务产品中间件和消息队列服务总线
// 创建时间：2022-10-09 23:48:59
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
/// 消息队列订阅令牌基类
/// </summary>
internal abstract class MessageTokenBase : IMessageToken
{
    /// <summary>
    /// 消息队列订阅令牌基类
    /// </summary>
    /// <param name="topic">消息主题</param>
    internal MessageTokenBase(string topic)
    {
        Topic = topic;
    }


    #region 接口实现[IMessageToken]

    /// <summary>
    /// 令牌编号
    /// </summary>
    public string Id { get; } = CommonHelper.NewGUID();

    /// <summary>
    /// 消息主题
    /// </summary>
    public string Topic { get; }

    /// <summary>
    /// 令牌时间
    /// </summary>
    public DateTime Time { get; } = DateTime.Now;


    /// <summary>
    /// 反订阅
    /// </summary>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public abstract Task UnSubscribeAsync();

    #endregion


    /// <summary>
    /// 接收消息
    /// </summary>
    /// <param name="info">内部消息流转实体</param>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    internal abstract Task OnReceivedAsync(MessageInfo info);
}