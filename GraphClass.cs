using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory
{
    public class GraphClass<T>
    {
        private const int NUM_VERTICES = 20;
        private Vertex<T>[] vertices;
        private int[,] adjMatrix;
        int numVerts;

        public GraphClass()
        {
            vertices = new Vertex<T>[NUM_VERTICES];
            adjMatrix = new int[NUM_VERTICES, NUM_VERTICES];
            numVerts = 0;
            for (int j = 0; j<= NUM_VERTICES; j++)
            {
                for(int k = 0; k <= NUM_VERTICES; k++)
                {
                    //No edges defined for vertices in Graph
                    adjMatrix[j, k] = 0;
                }
            }
        }

        //Implement method to find unvisited adjucent matrix
        //First find if Adjucent vertex exist for given vertex by looking at value 1
        //in the column against that row

        public void AddVertex(T label)
        {
            vertices[numVerts] = new Vertex<T>(label);
            numVerts++;
        }

        public void AddEdge(int start, int end)
        {
            adjMatrix[start, end] = 1;
            adjMatrix[end, start] = 1;
        }

        public void ShowVertex(int v)
        {
            Console.WriteLine(vertices[v].label + " ");
        }



        //Representing Vertices of Graph
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

        //This is a Node class with Id is Node id
        //Edges using Adjacency list
        public class Node
        {
            private int id;
            LinkedList<Node> adjecent = new LinkedList<Node>();
            private Node(int id)
            {
                this.id = id;
            }
        }

    }
}
