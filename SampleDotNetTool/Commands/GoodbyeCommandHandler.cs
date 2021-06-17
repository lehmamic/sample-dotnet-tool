using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace SampleDotNetTool.Commands
{
    public class GoodbyeCommandHandler : IRequestHandler<GoodbyeCommand, int>
    {
        private readonly ILogger<GoodbyeCommandHandler> _logger;

        public GoodbyeCommandHandler(ILogger<GoodbyeCommandHandler> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<int> Handle(GoodbyeCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Goodbye {request.GreetingTarget}");

            return Task.FromResult(0);
        }
    }
}