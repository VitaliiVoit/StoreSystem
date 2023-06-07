namespace StoreSystem.Domain.Entities;

public abstract class Person : BaseEntity
{
    [Required, StringLength(50)]
    public string FirstName { get; set; }

    [Required, StringLength(50)]
    public string LastName { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string? FullName { get; set; }

    protected Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString()
    {
        return FullName ?? "Unknown Person";
    }
}
