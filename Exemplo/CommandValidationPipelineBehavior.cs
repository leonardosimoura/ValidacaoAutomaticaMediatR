using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Logging;

namespace ExemploMediatR.Exemplo
{
    public class CommandValidationPipelineBehavior<TCommand, TReturn> : IPipelineBehavior<TCommand, TReturn> where TCommand : IRequest<TReturn>
    {
        public CommandValidationPipelineBehavior(IServiceProvider serviceProvider,  ILogger<CommandValidationPipelineBehavior<TCommand, TReturn>> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        private IServiceProvider _serviceProvider { get; }
        private ILogger<CommandValidationPipelineBehavior<TCommand,TReturn>> _logger { get; }

        public async Task<TReturn> Handle(TCommand request, CancellationToken cancellationToken, RequestHandlerDelegate<TReturn> next)
        {
            var validator = _serviceProvider.GetService<ICommandValidator<TCommand>>();

            if (validator != null)
            {
                if (!await validator.ValidarCommandAsync(request, cancellationToken))
                {
                    _logger.LogDebug("Validação Falhou!");
                    return await Task.FromResult(default(TReturn));
                }
                _logger.LogDebug("Validação OK!");
            }

            return await next();
        }
    }
}
