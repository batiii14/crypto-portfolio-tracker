using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.concretes
{
    public class CoinsBought:IEntity
    {
        [Key]
        public int Id { get; set; }
        public int WalletId { get; set; }
        public String Name { get; set; }
        public double quantity { get; set; }
    }
}
