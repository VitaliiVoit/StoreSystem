namespace StoreSystem.Domain.Entities;

public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null || obj is not BaseEntity)
            return false;

        return Id == ((BaseEntity)obj).Id;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 31;
            hash = hash * 23 + Id.GetHashCode();
            return hash;
        }
    }
}
