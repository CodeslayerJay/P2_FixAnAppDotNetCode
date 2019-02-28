using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2_FixAnAppDotNetCode.Models.Repositories
{
    public interface IOrderRepository
    {
        void Save(Order order);
    }
}
