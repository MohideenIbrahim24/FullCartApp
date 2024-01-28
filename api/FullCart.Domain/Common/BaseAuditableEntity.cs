using FullCart.Domain.Common;

namespace FullCart.Domain;

public abstract class BaseAuditableEntity : BaseEntity
{
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    public string CreatedBy { get; set; }

    public DateTime LastModifiedOn { get; set; }

    public string LastModifiedBy { get; set; }
    public bool IsDeleted { get; set; }
}
