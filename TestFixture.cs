using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDictionaryAppDomain
{
    [Serializable()]
    public class TestFixture : MarshalByRefObject
    {
        public string TestString { get; set; }
        public Dictionary<string, string> TestDictionary { get; set; }
        public int TestInteger { get; set; }
        public TestClass TestClass { get; set; }
    }

    [Serializable()]
    public class TestClass : MarshalByRefObject
    {
        public string TestString { get; set; }
        public Dictionary<string, string> TestDictionary { get; set; }
        public int TestInteger { get; set; }
    }
}
