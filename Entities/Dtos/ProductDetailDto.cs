using Core.Entities;

namespace Entities.Dtos
{
    public class ProductDetailDto : IDto
    {
        public int ProductId { get; set; }
        public virtual string ProductName { get; set; }
        public virtual string CategoryName { get; set; }
    }
}