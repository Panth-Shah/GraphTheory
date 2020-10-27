using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] input = new int[][] { new int[] { 0,6,0}, new int[] { 5,8,7}, new int[] { 0,9,0} };
            GraphDFSImplementation dfs = new GraphDFSImplementation();
            dfs.DepthFirstSearch(input);
        }
    }
}
