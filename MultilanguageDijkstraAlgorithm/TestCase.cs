using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultilanguageDijkstraAlgorithm
{
    class TestCase
    {
        private string filename;

        public TestCase(string filename)
        {
            this.filename = filename;
        }

        internal void Run()
        {
            Console.Write("Running " + filename + "... ");
            string[] lines = System.IO.File.ReadAllLines(filename);
            string metadata = lines[0];
            // #start#end#27#start:a:c:d:end#
            Assignment assignment = new Assignment();
            foreach(string line in lines.Skip(1).Where(str => str != ""))
            {
                string[] split = line.Split(':');
                string node1s = split[0];
                int distance = int.Parse(split[1]);
                string node2s = split[2];
                assignment.AddEdge(node1s, distance, node2s);
            }
            string[] metadataSplit = metadata.Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
            assignment.StartNode = assignment.AllNodes[metadataSplit[0]];
            assignment.FinishNode = assignment.AllNodes[metadataSplit[1]];
            bool expectSuccess = metadataSplit[2] != "FAIL";

            DijkstraResult result = Dijkstra.Compute(assignment);
            
            if (result.Successful)
            {
                if (!expectSuccess)
                {
                    Console.WriteLine("fail! (unexpectedly succeeded)");
                    return;
                }
                if (result.PathLength != int.Parse(metadataSplit[2]))
                {
                    Console.WriteLine("fail! (bad path length)");
                    return;
                }
                string[] nodeNames = metadataSplit[3].Split(':');
                if (nodeNames.Length != result.BestPath.Count)
                {
                    Console.WriteLine("fail! (bad node count)");
                    return;
                }
                for (int i =0; i < nodeNames.Length; i++)
                {
                    if (nodeNames[i] != result.BestPath[i].Name)
                    {
                        Console.WriteLine("fail! (bad path)");
                        return;
                    }
                }
                Console.WriteLine("OK!");
            }
            else
            {
                if (expectSuccess)
                {
                    Console.WriteLine("fail! (unexpectedly failed)");
                }
                else
                {
                    Console.WriteLine("OK!");
                }
            }
        }
    }
}
