using CommandLine;

namespace SampleDotNetTool.Commands
{
    [Verb("hello", HelpText = "Just an example command.")]
    public class HelloCommand : CommandBase
    {
        [Option('t', "target", Required = true, HelpText = "Specifies whom to say hello.")]
        public string GreetingTarget { get; set; }
    }
}