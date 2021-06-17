using CommandLine;
using MediatR;

namespace SampleDotNetTool.Commands
{
    public abstract class CommandBase : IRequest<int>
    {
        [Option("verbose", Default = false, Required = false, HelpText = "Enables verbose output.")]
        public bool Verbose { get; set; }
    }
}