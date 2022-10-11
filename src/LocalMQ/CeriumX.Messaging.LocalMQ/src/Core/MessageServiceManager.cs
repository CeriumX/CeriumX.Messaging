//=========================================================================
//**   消息队列服务产品中间件和消息队列服务总线（CeriumX.Messaging）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：MessageServiceManager.cs
// 项目名称：消息队列服务产品中间件和消息队列服务总线
// 创建时间：2022-10-10 12:11:43
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace CeriumX.Messaging.LocalMQ;

/// <summary>
/// 消息队列服务管理器
/// </summary>
internal sealed class MessageServiceManager : IAsyncDisposable
{
    /// <summary>
    /// 消息队列服务集合队列
    /// </summary>
    private readonly Dictionary<string, WeakReference<IMessageService>> _services = new();


    /// <summary>
    /// 添加一个消息队列服务
    /// </summary>
    /// <param name="service">消息队列服务</param>
    internal void Add(IMessageService service)
        => _services[service.Id] = new WeakReference<IMessageService>(service);

    /// <summary>
    /// 释放资源
    /// </summary>
    public async ValueTask DisposeAsync()
    {
        foreach (WeakReference<IMessageService> item in _services.Values)
        {
            if (item.TryGetTarget(out IMessageService? service) && service is not null)
            {
                await service.DisposeAsync().ConfigureAwait(false);
            }
        }

        _services.Clear();
        await Task.Delay(0).ConfigureAwait(false);
    }
}