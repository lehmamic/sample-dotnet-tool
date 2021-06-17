using System;
using System.Reflection;
using System.Threading.Tasks;
using CommandLine;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SampleDotNetTool.Commands;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Extensions.Logging;

namespace SampleDotNetTool
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            var levelSwitch = new LoggingLevelSwitch
            {
                MinimumLevel = LogEventLevel.Information,
            };

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(levelSwitch)
                .Enrich.FromLogContext()
                .WriteTo.Console(outputTemplate: "{Timestamp:HH:mm:ss} [{Level:u3}] {SourceContext} {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<ILoggerFactory>(_ => new SerilogLoggerFactory(Log.Logger))
                .AddMediatR(Assembly.GetExecutingAssembly())
                .BuildServiceProvider();

            return await Parser.Default.ParseArguments<HelloCommand, GoodbyeCommand>(args)
                .MapResult(
                    async (CommandBase command) =>
                    {
                        if (command.Verbose)
                        {
                            levelSwitch.MinimumLevel = LogEventLevel.Verbose;
                        }

                        return await serviceProvider.GetRequiredService<IMediator>().Send(command);
                    },
                    _ => Task.FromResult(1));
        }
    }
}
