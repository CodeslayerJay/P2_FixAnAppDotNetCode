﻿
using System.Collections.Generic;

namespace P2_FixAnAppDotNetCode.Models
{
    public interface ICart
    {
        void AddItem(Product product, int quantity);

        void RemoveLine(Product product);

        void Clear();

        double GetTotalValue();

        double GetAverageValue();
    }
}