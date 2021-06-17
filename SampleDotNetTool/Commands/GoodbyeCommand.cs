using CommandLine;

namespace SampleDotNetTool.Commands
{
    [Verb("goodbye", HelpText = "Just an example command.")]
    public class GoodbyeCommand : CommandBase
    {
        [Option('t', "target", Required = true, HelpText = "Specifies whom to say hello.")]
        public string GreetingTarget { get; set; }
    }
}