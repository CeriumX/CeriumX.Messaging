using CeriumX.Messaging.Abstractions;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CeriumX.Messaging.Appx4WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IMessageServiceFactory _factory;
    private IMessageService? _service;


    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public MainWindow()
    {
        _factory = LocalMQ.MessageServiceFactoryProvider.Create();

        InitializeComponent();
    }


    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="sender"><inheritdoc/></param>
    /// <param name="e"><inheritdoc/></param>
    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        MessageURI uri = new(@"localmq://127.0.0.1:5257");
        MessageOptions option = new(uri)
        {
            Id = "CeriumX_LocalMQ_{hostname}_{ip}_{mac}",
            NLogRulePrefixName = "MsgLocalMQ"
        };
        _service = await _factory.CreateAsync(option).ConfigureAwait(false);
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="e"><inheritdoc/></param>
    protected override async void OnClosed(EventArgs e)
    {
        if (_service is not null)
        {
            await _service.DisposeAsync().ConfigureAwait(false);
        }

        base.OnClosed(e);
    }

    private void BtnLocalObject_Click(object sender, RoutedEventArgs e)
    {
        if (_service is null)
        {
            return;
        }

        Views.LocalObjectWindow1 window1 = new(_service)
        {
            Owner = this
        };
        window1.Show();

        Views.LocalObjectWindow2 window2 = new(_service)
        {
            Owner = this,
            WindowStartupLocation = WindowStartupLocation.Manual,
            Left = 15,
            Top = 15
        };
        window2.Show();

        Views.LocalObjectWindow3 window3 = new(_service)
        {
            Owner = this,
            WindowStartupLocation = WindowStartupLocation.Manual,
            Left = 15,
            Top = window2.Height + window2.Top + 15
        };
        window3.Show();
    }

    private void BtnLocalMessage_Click(object sender, RoutedEventArgs e)
    {
        if (_service is null)
        {
            return;
        }

        Views.LocalMessageWindow1 window1 = new(_service)
        {
            Owner = this
        };
        window1.Show();

        Views.LocalMessageWindow2 window2 = new(_service)
        {
            Owner = this,
            WindowStartupLocation = WindowStartupLocation.Manual,
            Left = 15,
            Top = 15
        };
        window2.Show();

        Views.LocalMessageWindow3 window3 = new(_service)
        {
            Owner = this,
            WindowStartupLocation = WindowStartupLocation.Manual,
            Left = 15,
            Top = window2.Height + window2.Top + 15
        };
        window3.Show();
    }
}