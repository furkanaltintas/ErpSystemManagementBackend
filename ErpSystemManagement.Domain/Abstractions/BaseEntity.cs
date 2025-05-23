﻿namespace ErpSystemManagement.Domain.Abstractions;

public class BaseEntity
{
    public Guid Id { get; set; }

    public BaseEntity() { Id = Guid.NewGuid(); }
}