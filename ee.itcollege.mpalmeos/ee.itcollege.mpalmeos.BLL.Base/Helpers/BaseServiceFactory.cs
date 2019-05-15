using System;
using System.Collections.Generic;
using ee.itcollege.mpalmeos.BLL.Base.Services;
using ee.itcollege.mpalmeos.Contracts.BLL.Base.Helpers;
using ee.itcollege.mpalmeos.Contracts.DAL.Base;

namespace ee.itcollege.mpalmeos.BLL.Base.Helpers
{
    public class BaseServiceFactory<TUnitOfWork> : IBaseServiceFactory<TUnitOfWork>
        where TUnitOfWork : IBaseUnitOfWork
    {
        private readonly Dictionary<Type, Func<TUnitOfWork, object>> _serviceCreationMethodCache;

        public BaseServiceFactory() : this(new Dictionary<Type, Func<TUnitOfWork, object>>())
        {
        }

        public BaseServiceFactory(Dictionary<Type, Func<TUnitOfWork, object>> serviceCreationMethodCache)
        {
            _serviceCreationMethodCache = serviceCreationMethodCache;
        }


        public virtual void AddToCreationMethods<TService>(Func<TUnitOfWork, TService> creationMethod)
            where TService : class
        {
            _serviceCreationMethodCache.Add(typeof(TService), creationMethod);
        }


        public virtual Func<TUnitOfWork, object> GetServiceFactory<TService>()
        {
            if (_serviceCreationMethodCache.ContainsKey(typeof(TService)))
            {
                return _serviceCreationMethodCache[typeof(TService)];
            }

            throw new NullReferenceException("No service creation method found for " + typeof(TService).FullName);
        }

        /*
        public virtual Func<TUnitOfWork, object> GetEntityServiceFactory<TEntity>()
            where TEntity : class, IDomainEntity, new()
        {
            return (uow) => new BaseEntityService<TEntity, TUnitOfWork>(uow);
        }
        */
    }
}