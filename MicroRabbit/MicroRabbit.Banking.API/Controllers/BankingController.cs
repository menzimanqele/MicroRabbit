using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Models;
using MicroRabbit.Banking.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroRabbit.Banking.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankingController : ControllerBase
    {


        private readonly IAccountService accountService;
        public BankingController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpGet]
        public ActionResult <IEnumerable<Account>> Get()
        {
            return Ok(accountService.GetAccounts());
        }

        [HttpPost]
        public IActionResult Post([FromBody] AccountTransfer accountTransfer)
        {
            this.accountService.Transfer(accountTransfer);
            return Ok(accountTransfer);
        }
    }
}
