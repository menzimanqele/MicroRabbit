using MicroRabbit.Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Transfer.Domain.Interfaces
{
   public  interface ITransferRepository
    {
       public IEnumerable<TransferLog> GetTransferLogs();
        void Add(TransferLog transferLog);
    }
}
