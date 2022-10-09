// See https://aka.ms/new-console-template for more information
using CeriumX.Messaging.Abstractions;

Console.WriteLine("Hello, World!");
Console.WriteLine();
Console.WriteLine();


MessageURI uri = new MessageURI(@"rabbitmq://test:test@127.0.0.1:5257,127.0.0.1:5257/dbname/?aaa=1&bbb=2&ccc=3&ddd=4");

MessageOptions option = new MessageOptions(uri)
{
    Id = "CeriumX_Messaging_{hostname}_{ip}_{mac}",
    NLogRulePrefixName = "MessagingMQ"
};

Console.WriteLine($"Id: {option.Id}");
Console.WriteLine();
Console.WriteLine($"Scheme: {option.MessagingURI.Scheme}");
Console.WriteLine($"Hosts: {option.MessagingURI.Hosts}");
Console.WriteLine($"UserName: {option.MessagingURI.UserName}");
Console.WriteLine($"Password: {option.MessagingURI.Password}");
Console.WriteLine();
Console.WriteLine($"NLogRulePrefixName: {option.NLogRulePrefixName}");
Console.WriteLine();
Console.WriteLine();


Console.WriteLine("按任意键继续...");
Console.ReadKey();