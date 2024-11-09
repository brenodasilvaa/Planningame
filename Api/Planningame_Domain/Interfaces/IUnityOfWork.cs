using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planningame_Domain.Interfaces
{
    public interface IUnityOfWork
    {
        Task SaveAsync();
    }
}
