//=========================================================================
//**   消息队列服务产品中间件和消息队列服务总线（CeriumX.Messaging）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：MessagePost.cs
// 项目名称：消息队列服务产品中间件和消息队列服务总线
// 创建时间：2022-10-10 17:17:45
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System.Drawing;

namespace CeriumX.Messaging.Appx4WPF.Entity;

/// <summary>
/// <inheritdoc/>
/// </summary>
public sealed class MessagePost : IMessageObjectData, IAsyncDisposable
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public Image? Portrait { get; set; }


    #region 接口实现[IMessageObjectData]

    /// <summary>
    /// 资源释放通知令牌
    /// </summary>
    public CancellationToken? ReleaseNoticeToken { get; } = default;

    #endregion


    /// <summary>
    /// 资源释放
    /// </summary>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public async ValueTask DisposeAsync()
    {
        using (Portrait) { }
        await Task.Delay(0).ConfigureAwait(false);
    }
}