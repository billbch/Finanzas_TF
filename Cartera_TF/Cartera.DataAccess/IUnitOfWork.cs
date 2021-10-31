using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cartera.DataAccess
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
