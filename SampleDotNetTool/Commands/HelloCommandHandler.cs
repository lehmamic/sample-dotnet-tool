using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace SampleDotNetTool.Commands
{
    public class HelloCommandHandler : IRequestHandler<HelloCommand, int>
    {
        private readonly ILogger<HelloCommandHandler> _logger;

        public HelloCommandHandler(ILogger<HelloCommandHandler> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<int> Handle(HelloCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Hello {request.GreetingTarget}");

            return Task.FromResult(0);
        }
    }
}