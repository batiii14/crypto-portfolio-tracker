using Core.Entities;

namespace Entities.concretes
{
    public class SellingTransaction : IEntity
    {
        public int Id { get; set; }
        public CoinsBought coin { get; set; }
        public double Quantity { get; set; }
        public double SellingPrice { get; set; }

    }
}
