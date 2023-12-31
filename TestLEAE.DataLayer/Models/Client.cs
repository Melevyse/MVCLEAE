﻿using System.ComponentModel.DataAnnotations;
 
namespace TestLEAE.DataLayer;

public class Client
{
    [Key]
    public Guid Id { get; set; }
    public long Inn { get; set; }
    public string? Name { get; set; }
    [EnumDataType(typeof(ClientType))]
    public ClientType Type { get; set; }
    public DateTime DateToAdd { get; set; }
    public DateTime DateToUpdate { get; set; }
    public List<Founder> Founders { get; set; } = new();
}

