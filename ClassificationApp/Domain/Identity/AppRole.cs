using ee.itcollege.mpalmeos.Contracts.DAL.Base;
using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    public class AppRole : IdentityRole<int>, IDomainEntity
    {
        
    }
}