﻿using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Models;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using MicroRabbit.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;
        private readonly IEventBus _bus;

        public AccountService(IAccountRepository accountRepository, IEventBus bus)
        {
            this.accountRepository = accountRepository;
            this._bus = bus;    
        }
        public IEnumerable<Account> GetAccounts()
        {
            return accountRepository.GetAccount();
        }

        public void Transfer(AccountTransfer accountTransfer)
        {
            var createTransferCommand = new CreateTransferCommand(
                accountTransfer.FromAccount,accountTransfer.ToAccount,accountTransfer.TransferAmount
                );
            _bus.sendCommand(createTransferCommand);

        }
    }
}
