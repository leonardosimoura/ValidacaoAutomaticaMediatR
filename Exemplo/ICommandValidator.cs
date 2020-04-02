using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExemploMediatR.Exemplo
{
    public interface ICommandValidator<TCommand> where TCommand : IBaseRequest
    {
        Task<bool> ValidarCommandAsync(TCommand cmd, CancellationToken cancellationToken);
    }
}
