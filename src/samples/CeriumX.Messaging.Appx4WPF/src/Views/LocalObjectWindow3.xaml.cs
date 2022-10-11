using CeriumX.Messaging.Appx4WPF.Entity;
using CeriumX.Messaging.Appx4WPF.Infrastructure;
using System;
using System.Collections.Generic;
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
/// LocalObjectWindow3.xaml 的交互逻辑
/// </summary>
public partial class LocalObjectWindow3 : Window
{
    private readonly IMessageService? _service;


    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="service"><inheritdoc/></param>
    public LocalObjectWindow3(IMessageService? service)
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
        _service?.Subscribe(MessageKeys.MSG_TIP_PRIVATE, msgHandler);
    }
}