using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultilanguageDijkstraAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> testcases = System.IO.Directory.EnumerateFiles(@"..\..\..\data", "*.txt");
            foreach(string filename in testcases)
            {
                TestCase testCase = new TestCase(filename);
                testCase.Run();
            }
        }
    }

}
