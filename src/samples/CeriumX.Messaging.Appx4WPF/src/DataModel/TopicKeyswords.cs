//=========================================================================
//**   消息队列服务产品中间件和消息队列服务总线（CeriumX.Messaging）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：TopicKeyswords.cs
// 项目名称：消息队列服务产品中间件和消息队列服务总线
// 创建时间：2022-10-10 17:14:18
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System.Collections.ObjectModel;

namespace CeriumX.Messaging.Appx4WPF.DataModel;

/// <summary>
/// <inheritdoc/>
/// </summary>
public sealed class TopicKeyswords : ObservableCollection<KeyValuePair<string, string>>
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public TopicKeyswords()
    {
        Add(new KeyValuePair<string, string>("MSG_TIP_PUBLIC", "CeriumX_Messaging_Tip_Public"));
        Add(new KeyValuePair<string, string>("MSG_TIP_PRIVATE", "CeriumX_Messaging_Tip_Private"));
        Add(new KeyValuePair<string, string>("MSG_OBJ_PRIVATE", "CeriumX_Messaging_Object_Private"));
    }
}