using CeriumX.Messaging.Appx4WPF.Entity;
using CeriumX.Messaging.Appx4WPF.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CeriumX.Messaging.Appx4WPF.Views;

/// <summary>
/// LocalMessageWindow2.xaml 的交互逻辑
/// </summary>
public partial class LocalMessageWindow2 : Window
{
    private readonly IMessageService? _service;


    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="service"><inheritdoc/></param>
    public LocalMessageWindow2(IMessageService? service)
    {
        _service = service;

        InitializeComponent();
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="e"><inheritdoc/></param>
    protected override void OnInitialized(EventArgs e)
    {
        base.OnInitialized(e);

        IMessageHandler<MessageInfo> msgHandler = new MessageHandlerBase<MessageInfo>(async (e) =>
        {
            await Dispatcher.InvokeAsync(() =>
            {
                if (!string.IsNullOrEmpty(e.MessageData?.Message))
                {
                    lstMonitor.Items.Insert(0, $"{DateTime.Now:G} 收到消息：{e.MessageData?.Name} - {e.MessageData?.Message}");
                }

                if (lstMonitor.Items.Count > 50)
                {
                    lstMonitor.Items.RemoveAt(lstMonitor.Items.Count - 1);
                }
            });
        });

        _service?.Subscribe(MessageKeys.MSG_TIP_PUBLIC, msgHandler);

        IMessageHandler<MessagePost> objHandler = new MessageHandlerBase<MessagePost>(async (e) =>
        {
            await Dispatcher.InvokeAsync(() =>
            {
                if (e.MessageData?.Portrait != null)
                {
                    lstMonitor.Items.Insert(0, $"{DateTime.Now:G} 收到对象：{e.MessageData?.Name} - {e.MessageData?.Portrait?.Width}:{e.MessageData?.Portrait?.Height}");
                    using (e.MessageData?.Portrait)
                    {
                        using MemoryStream ms = new();
                        e.MessageData?.Portrait?.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        ms.Position = 0;

                        BitmapImage bi = new();
                        bi.BeginInit();
                        bi.CacheOption = BitmapCacheOption.OnLoad;
                        bi.StreamSource = ms;
                        bi.EndInit();

                        ImgPortrait.Source = bi;
                    }
                }

                if (lstMonitor.Items.Count > 50)
                {
                    lstMonitor.Items.RemoveAt(lstMonitor.Items.Count - 1);
                }
            });
        });

        _service?.Subscribe(MessageKeys.MSG_OBJ_PRIVATE, objHandler);
    }
}