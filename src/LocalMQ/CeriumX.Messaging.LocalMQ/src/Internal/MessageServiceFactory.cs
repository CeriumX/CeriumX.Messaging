//=========================================================================
//**   消息队列服务产品中间件和消息队列服务总线（CeriumX.Messaging）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：MessageServiceFactory.cs
// 项目名称：消息队列服务产品中间件和消息队列服务总线
// 创建时间：2022-10-10 11:08:03
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
/// 消息队列服务创建工厂
/// </summary>
internal sealed class MessageServiceFactory : IMessageServiceFactory
{
    /// <summary>
    /// 消息队列服务管理器
    /// </summary>
    private readonly MessageServiceManager _serviceManager = new();


    #region 接口实现[IMessageServiceFactory]

    /// <summary>
    /// 创建消息队列服务
    /// </summary>
    /// <param name="options">消息队列创建选项(参数)</param>
    /// <returns>消息队列服务</returns>
    public async ValueTask<IMessageService> CreateAsync(MessageOptions options)
    {
        return await Task.Run(() =>
        {
            MessageContext context = new(options);
            IMessageService service = new MessageService(context);
            _serviceManager.Add(service);

            return service;
        });
    }

    /// <summary>
    /// 资源释放
    /// </summary>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public async ValueTask DisposeAsync()
    {
        if (_serviceManager is not null)
        {
            await _serviceManager.DisposeAsync().ConfigureAwait(false);
        }
    }

    #endregion

}