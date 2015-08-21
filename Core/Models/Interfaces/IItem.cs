using System;
using System.Collections.Generic;

namespace CashRegister.Core.Models.Interfaces
{
    public interface IItem<T> where T : IItemVariation
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        List<T> Variations { get; set; }
    }
}