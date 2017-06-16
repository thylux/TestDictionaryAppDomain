using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDictionaryAppDomain
{
    class Program
    {
        static void Main(string[] args)
        {
            TestFixture fixture = new TestFixture
            {
                TestString = "",
                TestInteger = 0,
                TestDictionary = new Dictionary<string, string>
                {
                    { "test", "" }
                },
                TestClass = new TestClass
                {
                    TestString = "",
                    TestInteger = 0,
                    TestDictionary = new Dictionary<string, string>
                    {
                        { "test", "" }
                    }
                }
            };

            RunDomain(fixture);

            if (fixture.TestString == "" 
                || fixture.TestInteger == 0 
                || fixture.TestDictionary["test"] == ""
                || fixture.TestClass.TestString == ""
                || fixture.TestClass.TestInteger == 0
                || fixture.TestClass.TestDictionary["test"] == "")
                Console.WriteLine("Not yet!");
            else
                Console.WriteLine("It works!");
        }

        private static void RunDomain(TestFixture fixture)
        {
            using (var domain = GenericDisposable<TestWorker>.CreateDomainWithType($"TestWorker"))
            {
                domain.Object.Work(fixture);
            }
        }
    }
}
