using System;
using System.Security.Policy;

namespace TestDictionaryAppDomain
{
    // https://stackoverflow.com/questions/7793074/unload-an-appdomain-while-using-idisposable
    [Serializable()]
    public class GenericDisposable<T> : MarshalByRefObject, IDisposable
        where T : class
    {
        public Action Dispose { get; set; }
        public T Object { get; set; }
        void IDisposable.Dispose()
        {
            Dispose();
        }

        public static GenericDisposable<T> CreateDomainWithType(string domainName)
        {
            var appDomain = AppDomain.CreateDomain(domainName,
                                                    new Evidence(AppDomain.CurrentDomain.Evidence),
                                                    new AppDomainSetup
                                                    {
                                                        ApplicationBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                                                        ConfigurationFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile
                                                    });
            var inst = appDomain.CreateInstanceAndUnwrap(typeof(T).Assembly.FullName, typeof(T).FullName) as T;

            return new GenericDisposable<T>()
            {
                Dispose = () => {
                    AppDomain.Unload(appDomain);
                },
                Object = (T)inst
            };
        }
    }
}
