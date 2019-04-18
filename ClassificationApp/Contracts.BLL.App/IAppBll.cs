using System;
using Contracts.BLL.App.Services;
using Contracts.BLL.Base;

namespace Contracts.BLL.App
{
    public interface IAppBll : IBaseBll
    {
        ICompanyService Companies { get; }
        
    }
}