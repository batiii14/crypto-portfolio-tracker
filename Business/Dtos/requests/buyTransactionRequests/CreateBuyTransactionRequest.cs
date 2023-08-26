using Entities.concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.requests.buyTransactionRequests
{
    public class CreateBuyTransactionRequest
    {
        public int UserId { get; set; }
        public string CoinName { get; set; }
        public double Value { get; set; }
        public double Quantity { get; set; }
    }
}
