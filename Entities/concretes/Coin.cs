using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.concretes
{
    public class Coin : IEntity
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public double Value { get; set; }
    }
}
