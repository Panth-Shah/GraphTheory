using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory
{
    public class GraphBFSImplement
    {
        private GraphClass<int> graph;
        private Queue<int> q;
        private Vertex<int>[] vertices;
        private int numVertices;
        private int[][] adjMatrix;
        public GraphBFSImplement()
        {
            q = new Queue<int>();
            graph = new GraphClass<int>();
        }

        public void BreadthFirstSearch(int[][] matrix)
        {
            //insert root vertices in queue
            numVertices = matrix.Length;
            int row = matrix.Length;
            int column = matrix[0].Length;

            vertices[0].wasVisited = true;
            graph.ShowVertex(0);
            q.Enqueue(0);
            int vert1, vert2;
            while (q.Count > 0)
            {
                vert1 = q.Dequeue();
                vert2 = GetAdjUnvisitedVertex(vert1);

                //find all the unVisited adjucent vertices of origin vertex
                while (vert2 != -1)
                {
                    vertices[vert2].wasVisited = true;
                    graph.ShowVertex(vert2);
                    //Search for all the adjecent nodes of origin
                    vert2 = GetAdjUnvisitedVertex(vert1);
                }
            }
            //cleans up vertices array
            for (int i = 0; i <= numVertices - 1; i++)
            {
                vertices[i].wasVisited = false;
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

    public class Vertex<T>
    {
        //We will store the list of vertices in an array and will reference them in the Grpah class
        //by their position in the array
        public bool wasVisited;
        public T label;

        public Vertex(T label)
        {
            this.label = label;
            wasVisited = false;
        }
    }
}
