//=========================================================================
//**   消息队列服务产品中间件和消息队列服务总线（CeriumX.Messaging）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：MessageManager.cs
// 项目名称：消息队列服务产品中间件和消息队列服务总线
// 创建时间：2022-10-10 12:29:34
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System.Collections.Concurrent;

namespace CeriumX.Messaging.LocalMQ;

/// <summary>
/// 消息管理者
/// </summary>
internal sealed class MessageManager : IAsyncDisposable
{
    private readonly BlockingCollection<MessageInfo> _messages = new();
    private readonly CancellationTokenSource _cts = new();
    private readonly MessageContext _context;


    /// <summary>
    /// 消息管理者
    /// </summary>
    /// <param name="context">消息队列服务上下文</param>
    internal MessageManager(MessageContext context)
    {
        _context = context;
        _context.Logger.Info($"初始化消息管理者，并开启消息消费工作[Id: {context.ServiceId}]。");

        //开启消息消费
        StartConsume();
    }


    /// <summary>
    /// 消息入队
    /// </summary>
    /// <param name="info">消息实体</param>
    internal void EnqueueMessage(MessageInfo info)
    {
        if (info.DispatchMessage is not null)
        {
            _context.Logger.Debug($"消息入队[Id: {_context.ServiceId}] - {info.Topic}：{BitConverter.ToString(info.DispatchMessage)}");
        }
        else
        {
            string? fullname = info.DispatchObject?.GetType().FullName;
            _context.Logger.Debug($"消息入队[Id: {_context.ServiceId}] - {info.Topic}：收到投递对象（{fullname}）入队请求。");
        }

        _messages.Add(info);
    }

    /// <summary>
    /// 开启消息消费工作，给订阅者分发消息。
    /// </summary>
    private void StartConsume()
    {
        _ = Task.Run(() =>
        {
            while (!_cts.Token.IsCancellationRequested)
            {
                // TryTake 方法不阻塞，且CPU占用过高。
                MessageInfo info = _messages.Take();

                try
                {
                    // 分发消息给订阅者
                    _ = _context.CurrentSubscribeManager.DispatchMessage(info);
                }
                catch (Exception ex)
                {
                    _context.Logger.Error(ex, ex.Message);
                }
            }
        }, _cts.Token).ConfigureAwait(false);

        //_ = Task.Factory.StartNew(() =>
        //{
        //    while (!_cts.Token.IsCancellationRequested)
        //    {
        //        try
        //        {
        //            // TryTake 方法不阻塞，且CPU占用过高。
        //            var result = _messages.Take();

        //            // 分发消息给订阅者
        //            _ = _context.CurrentSubscribeManager.DispatchMessage(result);
        //        }
        //        catch (Exception ex)
        //        {
        //            _context.Logger.Error(ex, ex.Message);
        //            break;
        //        }
        //    }

        //    _cts.Token.ThrowIfCancellationRequested();
        //}, _cts.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default).ConfigureAwait(false);
    }

    /// <summary>
    /// 资源释放
    /// </summary>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public async ValueTask DisposeAsync()
    {
        await Task.Delay(0).ConfigureAwait(false);

        _context.Logger.Info($"开始释放消息管理者资源[Id: {_context.ServiceId}]。");

        if (_cts is not null)
        {
            _cts.Cancel();
        }

        using (_cts) { }
        using (_messages) { }

        _context.Logger.Info($"消息管理者释放资源结束[Id: {_context.ServiceId}]。");
    }
}