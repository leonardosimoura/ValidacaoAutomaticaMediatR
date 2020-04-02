using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExemploMediatR.Exemplo;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExemploMediatR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommandController : ControllerBase
    {
        private readonly ILogger<CommandController> _logger;
        private IMediator _mediator { get; }
        public CommandController(ILogger<CommandController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogDebug("Cmd 1");
            var cmd1 =_mediator.Send(new ExemploCommand { Exemplo = "" });
            _logger.LogDebug("Cmd 2");
            var cmd2= _mediator.Send(new ExemploCommand { Exemplo = "Exemplo" });

            return Ok();
        }
    }
}
