
import java.io.File

fun main(args: Array<String>) {
    for (filename in File(""".""").walk()) {
        if (!filename.toString().endsWith(".txt")) {
            continue
        }
        val testCase = TestCase(filename)
        testCase.run()
    }
}

/*
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

 */