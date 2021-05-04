using System;
using CommandLine;
using Corsinvest.ProxmoxVE.Api;
using Corsinvest.ProxmoxVE.Api.Extension.VM;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace pveAutoConnectVM
{
    public class Program
    {
        private static int Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(Run);
            return 0;
        }

        private static void Run(Options option)
        {
            var builder = new HostBuilder()
                .UseConsoleLifetime();

            var host = builder.Build();

            using var serviceScope = host.Services.CreateScope();
            {
                var services = serviceScope.ServiceProvider;
                try
                {
                    var client = new PveClient(option.Host, option.Port);
                    if (!client.Login(option.Username, option.Password))
                    {
                        return;
                    }

                    foreach (var vm in client.GetVMs())
                    {
                        vm.LxcApi.Vncproxy.CreateRest();
                    }
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred.");
                }
            }
        }

        private class Options
        {
            [Option('h', "host", Required = true, HelpText = "Server Url")]
            public string Host { get; set; }

            [Option("port", HelpText = "Server Port [443]")]
            public int Port { get; set; } = 443;

            [Option('u', "username", Required = true, HelpText = "Your account")]
            public string Username { get; set; }

            [Option('p', "password", Required = true, HelpText = "Your password")]
            public string Password { get; set; }
        }

    }
}
