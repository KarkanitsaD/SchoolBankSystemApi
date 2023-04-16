﻿namespace DAL.Entities;

public class User
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public string Phone { get; set; }

    public string PasswordHash { get; set; }

    public bool IsDeleted { get; set; }
}