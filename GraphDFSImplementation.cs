using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory
{
    public class GraphDFSImplementation
    {
        private GraphClass<int> graph;
        private Vertex<int>[] vertices;
        private Stack<int> stack;
        private int numVertices;
        private int[][] adjMatrix;

        public GraphDFSImplementation()
        {

        }

        public void DepthFirstSearch(int[][] matrix)
        {
            //Find root vertex and set it visited
            numVertices = matrix.Length;
            vertices[0].wasVisited = true;
            graph.ShowVertex(0);
            stack.Push(0);
            while(stack.Count > 0)
            {
                //select first element in stack and find all adjacent unvisited vertices in graph
                int v = GetAdjUnvisitedVertex(stack.Peek());
                if(v == -1)
                {
                    //If no adjacent unvisited vertices present for top stack element
                    stack.Pop();
                }
                else
                {
                    vertices[v].wasVisited = true;
                    graph.ShowVertex(v);
                    stack.Push(v);
                }
            }

            //Clear graph for rerun
            for (int j = 0; j<=numVertices-1; j++)
            {
                vertices[j].wasVisited = false;
            }

        }

        private int GetAdjUnvisitedVertex(int v)
        {
            for (int j = 0; j <= numVertices - 1; j++)
            {
                if (adjMatrix[v][j] == 1 && vertices[j].wasVisited == false)
                {
                    return j;
                }
            }
            return -1;
        }
    }


}
