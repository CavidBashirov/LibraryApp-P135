using DomainLayer.Common;

namespace DomainLayer.Entities
{
    public class Library : BaseEntity
    {
        public string Name { get; set; }
        public int SeatCount { get; set; }
    }
}
