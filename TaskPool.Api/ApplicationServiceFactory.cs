using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Interception;
using TaskPool.Repositories;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Interception.InterceptionBehaviors;
using TaskPool.Services;
using TaskPool.Services.Interfaces;

namespace TaskPool.Common
{

    public class ApplicationServiceFactory
    {
        private static volatile UnityContainer _instance;
        private static readonly object SyncLock = new object();
        public static UnityContainer Instance
        {
            get
            {
                lock (SyncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new UnityContainer();
                        _instance.RegisterType<ILoginService, LoginService>();
                        _instance.RegisterType<ILandingServices, LandingServices>();
                        _instance.RegisterType<IMasterServices, MasterServices>();
                    }
                    return _instance;
                }
            }
            
        }
        public static UnityContainer GetUnityContainter()
        {
            return Instance;
        }
        public static void OverrideUnityContainer(UnityContainer unityContainer)
        {
            _instance = unityContainer;
        }
        public T GetApplicationService<T>() where T: class
        {
            return Intercept.ThroughProxy(Instance.Resolve<T>(),new InterfaceInterceptor(),new IInterceptionBehavior[] { });
        }
    }
}
