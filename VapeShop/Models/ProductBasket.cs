﻿namespace VapeShop.Models;

public class ProductBasket : BaseEntity
{
    public Product? Product { get; set; }
    public int Amount { get; set; }
}