﻿namespace StoreSystem.Domain.Entities;

public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }
}
