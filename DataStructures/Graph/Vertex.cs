using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Libraries.Graph
{
    public class Vertex<TNode>
    {
        public TNode node { get; set; }
        public bool isVisited;
        public bool isBeingVisited;

        public Vertex<TNode> predecessor;

        public IList<Vertex<TNode>> AdjacencyList { get; set; }

        public Vertex()
        {
            this.AdjacencyList = new List<Vertex<TNode>>();
        }

        public void AddAdjacentNode(Vertex<TNode> vertex)
        {
            this.AdjacencyList.Add(vertex);
        }

        public override string ToString()
        {
            return this.node.ToString();
        }
    }
}
