using System;
using ee.itcollege.mpalmeos.Contracts.BLL.Base.Services;

namespace ee.itcollege.mpalmeos.BLL.Base.Services
{
    public class BaseService : IBaseService
    {
        private readonly Guid _instanceId = Guid.NewGuid();
        public Guid InstanceId => _instanceId;
    }

}