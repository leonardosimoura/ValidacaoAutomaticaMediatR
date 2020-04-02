using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExemploMediatR.Exemplo
{
    public class ExemploCommandHandler : IRequestHandler<ExemploCommand, bool>
    {
        public ExemploCommandHandler(ILogger<ExemploCommandHandler> logger)
        {
            _logger = logger;
        }

        private ILogger<ExemploCommandHandler> _logger { get; }

        public Task<bool> Handle(ExemploCommand request, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Execução IRequestHandler");
            return Task.FromResult(true);
        }
    }
}
