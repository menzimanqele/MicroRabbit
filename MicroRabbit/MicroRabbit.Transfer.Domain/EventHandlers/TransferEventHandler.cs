using MicroRabbit.Transfer.Domain.Events;
using MicroRabbit.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MicroRabbit.Transfer.Domain.Interfaces;

namespace MicroRabbit.Transfer.Domain.EventHandlers
{
    public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
    {
        private readonly ITransferRepository transferRepository;

        public TransferEventHandler(ITransferRepository transferRepository)
        {
            this.transferRepository = transferRepository;
        }
        public Task Handle(TransferCreatedEvent @event)
        {
            transferRepository.Add(new Models.TransferLog { FromAccount = @event.From, ToAccount = @event.To,TransferAmount=@event.Amount });
            return Task.CompletedTask;
        }
    }
}
