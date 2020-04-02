using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExemploMediatR.Exemplo
{
    
    public class ExemploCommand : IRequest<bool>
    {
        public string Exemplo { get; set; }
    }

    public class ExemploCommandValidator : ICommandValidator<ExemploCommand>
    {
        public Task<bool> ValidarCommandAsync(ExemploCommand cmd, CancellationToken cancellationToken)
        {
            return Task.FromResult(!string.IsNullOrWhiteSpace(cmd.Exemplo));
        }
    }
}
