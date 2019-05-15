using System;

namespace ee.itcollege.mpalmeos.Contracts.Base
{
    public interface ITrackableInstance
    {
        Guid InstanceId { get; }
    }
}