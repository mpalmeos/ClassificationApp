using System;
using System.Threading.Tasks;
using Contracts.Base;

namespace Contracts.BLL.Base
{
    public interface IBaseBll : ITrackableInstance
    {   
        Task<int> SaveChangesAsync();
    }
}