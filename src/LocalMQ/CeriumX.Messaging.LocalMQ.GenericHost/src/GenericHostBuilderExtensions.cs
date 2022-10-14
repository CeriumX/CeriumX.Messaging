//=========================================================================
//**   消息队列服务产品中间件和消息队列服务总线（CeriumX.Messaging）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：GenericHostBuilderExtensions.cs
// 项目名称：消息队列服务产品中间件和消息队列服务总线
// 创建时间：2022-10-14 15:49:30
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using CeriumX.Messaging.Abstractions;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace CeriumX.Messaging.LocalMQ.GenericHost;

/// <summary>
/// 消息队列服务产品中间件和消息队列服务总线GenericHost扩展服务
/// </summary>
public static class GenericHostBuilderExtensions
{
    /// <summary>
    /// 集成消息队列服务产品中间件的LocalMQ(本地化消息队列)实现
    /// </summary>
    /// <param name="hostBuilder">The <see cref="IHostBuilder"/> to configure.</param>
    /// <returns>The same instance of the <see cref="IHostBuilder"/> for chaining.</returns>
    public static IHostBuilder UseMessagingOfLocalMQ(this IHostBuilder hostBuilder)
    {
        return hostBuilder.ConfigureServices((context, services) =>
        {
            IMessageServiceFactory factory = MessageServiceFactoryProvider.Create();
            services.TryAddSingleton(sp => factory);
        });
    }
}