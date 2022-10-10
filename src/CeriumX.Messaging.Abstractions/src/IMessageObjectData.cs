﻿//=========================================================================
//**   消息队列服务产品中间件和消息队列服务总线（CeriumX.Messaging）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：IMessageObjectData.cs
// 项目名称：消息队列服务产品中间件和消息队列服务总线
// 创建时间：2022-10-09 17:29:04
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
/// 仅用于对象投递的消息约束接口
/// </summary>
/// <remarks>NOTE：仅限LocalMQ支持。</remarks>
public interface IMessageObjectData
{
    /// <summary>
    /// 资源释放通知令牌
    /// </summary>
    public CancellationToken? ReleaseNoticeToken { get; }
}