//=========================================================================
//**   消息队列服务产品中间件和消息队列服务总线（CeriumX.Messaging）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：MessageOptions.cs
// 项目名称：消息队列服务产品中间件和消息队列服务总线
// 创建时间：2022-10-09 17:34:13
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using GSA.ToolKits.CommonUtility;
using System.Net;

namespace CeriumX.Messaging.Abstractions;

/// <summary>
/// 消息队列创建选项(参数)类
/// </summary>
[Serializable]
public sealed class MessageOptions
{
    /// <summary>
    /// 消息服务唯一标识
    /// </summary>
    private string _id = string.Empty;


    /// <summary>
    /// 消息队列创建选项(参数)
    /// </summary>
    /// <param name="messageURI">消息队列服务接入统一资源标识符(URI)</param>
    public MessageOptions(MessageURI messageURI) => MessagingURI = messageURI;


    /// <summary>
    /// 消息服务唯一标识
    /// </summary>
    /// <remarks>
    /// 格式：Define_[custom]_{hostname}_{ip}_{mac}
    /// <para>Define 消息服务识别标定名称（如：CeriumX）</para>
    /// <para>[custom] 自定义</para>
    /// <para>{hostname} 自动解析为当前主机名称</para>
    /// <para>{ip} 自动解析为当前IP地址</para>
    /// <para>{mac} 自动解析为当前MAC地址</para>
    /// </remarks>
    public string Id
    {
        get => _id;
        set => Parse(value);
    }

    /// <summary>
    /// 消息队列服务接入统一资源标识符(URI)
    /// </summary>
    public MessageURI MessagingURI { get; }

    /// <summary>
    /// NLog配置规则名前缀
    /// </summary>
    /// <remarks>如：MessagingMQ.*，传递 MessagingMQ 即可。</remarks>
    public string? NLogRulePrefixName { get; set; } = "MessagingMQ";


    /// <summary>
    /// 解析消息服务唯一标识
    /// </summary>
    /// <param name="valueString">需要解析的数据</param>
    private void Parse(string valueString)
    {
        if (valueString.Contains("{hostname}"))
        {
            valueString = valueString.Replace("{hostname}", Dns.GetHostName());
        }

        string ip = NetworkHelper.GetIpAddress();

        if (valueString.Contains("{ip}"))
        {
            valueString = valueString.Replace("{ip}", ip);
        }

        if (valueString.Contains("{mac}"))
        {
            string mac = NetworkHelper.GetMacAddress(ip);
            valueString = valueString.Replace("{mac}", mac);
        }

        _id = valueString;
    }
}