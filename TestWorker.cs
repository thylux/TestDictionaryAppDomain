using System;
using System.IO;

namespace TestDictionaryAppDomain
{
    /// <summary>
    /// Tests that should be shared across AppDomains
    /// </summary>
    [Serializable()]
    public class TestWorker : MarshalByRefObject
    {
        public bool Work(TestFixture fixture)
        {
            fixture.TestString = "tested";
            fixture.TestInteger = 10;
            fixture.TestDictionary["test"] = "tested";
            fixture.TestClass.TestString = "tested";
            fixture.TestClass.TestInteger = 10;
            fixture.TestClass.TestDictionary["test"] = "tested";

            return true;
        }
    }
}
