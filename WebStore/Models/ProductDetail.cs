using System;
namespace WebStore
{
    public record ProductDetail(Guid Id, string Name, decimal Price, double Weight, string Description, int Inventory);
}