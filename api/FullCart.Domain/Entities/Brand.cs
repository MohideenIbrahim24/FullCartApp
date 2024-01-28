using FullCart.Domain.Common;

namespace FullCart.Domain.Entities
{
    public class Brand : BaseAuditableEntity
    {
        public string Name { get; set; }

        public Brand()
        {
            this.Id = Guid.NewGuid();
        }
    }
}