//=========================================================================
//**   消息队列服务产品中间件和消息队列服务总线（CeriumX.Messaging）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：MessageURI.cs
// 项目名称：消息队列服务产品中间件和消息队列服务总线
// 创建时间：2022-10-09 17:37:14
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System.Text;
using System.Text.RegularExpressions;

namespace CeriumX.Messaging.Abstractions;

/// <summary>
/// 消息队列服务接入统一资源标识符(URI)
/// </summary>
/// <remarks>
/// 方案名称://用户名:密码@IP地址:端口号,IP地址:端口号
/// <list type="bullet">
/// <item>localmq://127.0.0.1:5257</item>
/// <item>mqtt://test:test@127.0.0.1:5257</item>
/// <item>kafka://127.0.0.1:5257</item>
/// <item>kafka://127.0.0.1:5257,127.0.0.1:5257</item>
/// <item>rabbitmq://test:test@127.0.0.1:5257</item>
/// <item>rabbitmq://test:test@127.0.0.1:5257,127.0.0.1:5257</item>
/// </list>
/// </remarks>
[Serializable]
public sealed class MessageURI
{
    /// <summary>
    /// 消息队列服务接入统一资源标识符(URI)
    /// </summary>
    /// <remarks>
    /// 方案名称://用户名:密码@IP地址:端口号,IP地址:端口号
    /// <list type="bullet">
    /// <item>localmq://127.0.0.1:5257</item>
    /// <item>mqtt://test:test@127.0.0.1:5257</item>
    /// <item>kafka://127.0.0.1:5257</item>
    /// <item>kafka://127.0.0.1:5257,127.0.0.1:5257</item>
    /// <item>rabbitmq://test:test@127.0.0.1:5257</item>
    /// <item>rabbitmq://test:test@127.0.0.1:5257,127.0.0.1:5257</item>
    /// </list>
    /// </remarks>
    /// <param name="uriString">统一资源标识符(URI)字符串</param>
    public MessageURI(string uriString) => Parse(uriString);


    /// <summary>
    /// 方案名称
    /// </summary>
    public string? Scheme { get; private set; }

    /// <summary>
    /// 主机地址
    /// </summary>
    public string? Hosts { get; private set; }

    /// <summary>
    /// 用户名称
    /// </summary>
    public string? UserName { get; private set; }

    /// <summary>
    /// 用户密码
    /// </summary>
    public string? Password { get; private set; }


    #region 成员方法

    /// <summary>
    /// 解析统一资源标识符(URI)
    /// </summary>
    private void Parse(string uriString)
    {
        const string serverPattern = @"(?<host>((\[[^]]+?\]|[^:@,/?#]+)(:\d+)?))";
        const string serversPattern = @$"{serverPattern}(,{serverPattern})*";
        const string databasePattern = @"(?<database>[^/?]+)";
        const string optionPattern = @"(?<option>[^&;]+=[^&;]+)";
        const string optionsPattern = @$"(\?{optionPattern}((&|;){optionPattern})*)?";
        const string pattern = @$"^(?<scheme>[a-z]+)://((?<username>[^:@]+)(:(?<password>[^:@]*))?@)?{serversPattern}(/{databasePattern})?/?{optionsPattern}$";

        var match = Regex.Match(uriString, pattern);

        if (match.Success is false)
        {
            throw new Exception($"The URI string {uriString} is not valid.");
        }

        ExtractScheme(match);
        ExtractUsernameAndPassword(match);
        ExtractHosts(match);
    }

    /// <summary>
    /// 解析统一资源标识符(URI)包含的头部信息
    /// </summary>
    /// <param name="match">正则匹配规则</param>
    private void ExtractScheme(Match match)
    {
        var schemeGroup = match.Groups["scheme"];

        if (schemeGroup.Success)
        {
            Scheme = Uri.UnescapeDataString(schemeGroup.Value);
        }
    }

    /// <summary>
    /// 解析统一资源标识符(URI)包含的用户名与密码
    /// </summary>
    /// <param name="match">正则匹配规则</param>
    private void ExtractUsernameAndPassword(Match match)
    {
        var usernameGroup = match.Groups["username"];

        if (usernameGroup.Success)
        {
            UserName = Uri.UnescapeDataString(usernameGroup.Value);
        }

        var passwordGroup = match.Groups["password"];

        if (passwordGroup.Success)
        {
            Password = Uri.UnescapeDataString(passwordGroup.Value);
        }
    }

    /// <summary>
    /// 解析统一资源标识符(URI)包含的主机地址信息
    /// </summary>
    /// <param name="match">正则匹配规则</param>
    private void ExtractHosts(Match match)
    {
        var sb = new StringBuilder();

        foreach (Capture host in match.Groups["host"].Captures.Cast<Capture>())
        {
            if (sb.Length is 0)
            {
                sb.Append(host.Value);
            }
            else
            {
                sb.Append($",{host.Value}");
            }
        }

        Hosts = sb.ToString();
    }

    #endregion

}