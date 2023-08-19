using Core.Entities;

namespace Entities.concretes
{
    public class CoinUpdater:IEntity
    {
        public int Id { get; set; }
        public string CoinName { get; set; }
        public double UpdatedValue { get; set; }

    }
}
