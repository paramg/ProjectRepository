using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Libraries.Graph
{
    public class Graph<TNode>
    {
        bool isCycleExists = false;

        IList<Vertex<TNode>> GraphVertexList { get; set; }
        public Stack<TNode> TopologicalOrderStack { get; set; }
        
        IList<Vertex<TNode>> DfsList { get; set; }

        public Graph(IList<Vertex<TNode>> vertexList)
        {
            this.GraphVertexList = vertexList;
            this.TopologicalOrderStack = new Stack<TNode>();
            this.DfsList = new List<Vertex<TNode>>();
        }

        public Graph(int[][] adjacencyArray)
        {
        }

        public IList<Vertex<TNode>> DFS()
        {
            foreach (Vertex<TNode> node in this.GraphVertexList)
            {
                this.DFS(node);
            }

            return this.DfsList;
        }

        public bool IsCycleExists()
        {
            foreach (Vertex<TNode> node in this.GraphVertexList)
            {
                this.DetectCycle(node);
            }

            return this.isCycleExists;
        }

        private void DetectCycle(Vertex<TNode> vertex)
        {
            vertex.isVisited = true;
            vertex.isBeingVisited = true;

            foreach(Vertex<TNode> v in vertex.AdjacencyList)
            {
                if(v.isBeingVisited == true)
                {
                    isCycleExists = true;
                    break;
                }

                if(!v.isVisited)
                {
                    this.DetectCycle(v);
                }
            }

            vertex.isBeingVisited = false;
        }

        private void DFS(Vertex<TNode> vertex)
        {
            vertex.isVisited = true;

            foreach (Vertex<TNode> v in vertex.AdjacencyList)
            {
                if (!v.isVisited)
                {
                    this.DFS(v);

                    this.TopologicalOrderStack.Push(v.node);

                    if (!this.DfsList.Contains(v))
                    {
                        this.DfsList.Add(v);
                    }
                }
            }
        }
    }
}
