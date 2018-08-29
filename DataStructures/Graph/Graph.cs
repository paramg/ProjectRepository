using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Libraries.Graph
{
    [TestClass]
    public class Graph
    {
        public Graph()
        {
        }

        #region Graph nodes initialization.

        #region This variable is used in the code (just for understanding).
        Dictionary<string, string[]> network = new Dictionary<string, string[]>
        {
            { "Min",     new[] { "William", "Jayden", "Omar" } },
            {  "William", new[] { "Min", "Noam" } }, 
            {  "Jayden",  new[] { "Min", "Amelia", "Ren", "Noam" } },
            {  "Ren",     new[] { "Jayden", "Omar" } },
            {  "Amelia",  new[] { "Jayden", "Adam", "Miguel" } },
            {  "Adam",    new[] { "Amelia", "Miguel", "Sofia", "Lucas" } },
            {  "Miguel",  new[] { "Amelia", "Adam", "Liam", "Nathan" } },
            {  "Noam",    new[] { "Nathan", "Jayden", "William" } },
            {  "Omar",    new[] { "Ren", "Min", "Scott" } }
        };
        #endregion

        static Graph min = new Graph("Min");
        static Graph william = new Graph("William");
        static Graph jayden = new Graph("Jayden");
        static Graph ren = new Graph("Ren");
        static Graph amelia = new Graph("Amelia");
        static Graph adam = new Graph("Adam");
        static Graph miguel = new Graph("Miguel");
        static Graph noam = new Graph("Noam");
        static Graph omar = new Graph("Omar");
        static Graph sofia = new Graph("Sofia");
        static Graph lucas = new Graph("Lucas");
        static Graph nathan = new Graph("Nathan");
        static Graph liam = new Graph("Liam");
        static Graph scott = new Graph("Scott");
        static Graph cycletomin = new Graph("cycletomin");

        Dictionary<string, Graph> graphMapping = new Dictionary<string, Graph>
        {
            { "Min",     min },
            {  "William", william },
            {  "Jayden",  jayden },
            {  "Ren",     ren },
            {  "Amelia",  amelia },
            {  "Adam",    adam },
            {  "Miguel", miguel },
            {  "Noam",    noam },
            {  "Omar",    omar },
            { "cycletomin", cycletomin}
        };

        public void PopulateDirectedGraphNetwork(bool createCycle = false)
        {
            min.AddNeighborNode(william);
            min.AddNeighborNode(jayden);
            min.AddNeighborNode(omar);

            william.AddNeighborNode(noam);

            jayden.AddNeighborNode(amelia);
            jayden.AddNeighborNode(ren);
            jayden.AddNeighborNode(noam);

            ren.AddNeighborNode(omar);

            amelia.AddNeighborNode(adam);
            amelia.AddNeighborNode(miguel);

            adam.AddNeighborNode(miguel);
            adam.AddNeighborNode(sofia);
            adam.AddNeighborNode(lucas);

            miguel.AddNeighborNode(liam);
            miguel.AddNeighborNode(nathan);

            omar.AddNeighborNode(scott);

            if (createCycle)
            {
                ren.AddNeighborNode(min);
            }
        }

        public void PopulateGraphNetwork()
        {
            min.AddNeighborNode(william);
            min.AddNeighborNode(jayden);
            min.AddNeighborNode(omar);

            william.AddNeighborNode(min);
            william.AddNeighborNode(noam);

            jayden.AddNeighborNode(min);
            jayden.AddNeighborNode(amelia);
            jayden.AddNeighborNode(ren);
            jayden.AddNeighborNode(noam);

            ren.AddNeighborNode(jayden);
            ren.AddNeighborNode(omar);

            amelia.AddNeighborNode(jayden);
            amelia.AddNeighborNode(adam);
            amelia.AddNeighborNode(miguel);

            adam.AddNeighborNode(amelia);
            adam.AddNeighborNode(miguel);
            adam.AddNeighborNode(sofia);
            adam.AddNeighborNode(lucas);

            miguel.AddNeighborNode(amelia);
            miguel.AddNeighborNode(adam);
            miguel.AddNeighborNode(liam);
            miguel.AddNeighborNode(nathan);

            noam.AddNeighborNode(nathan);
            noam.AddNeighborNode(jayden);
            noam.AddNeighborNode(william);

            omar.AddNeighborNode(ren);
            omar.AddNeighborNode(min);
            omar.AddNeighborNode(scott);
        }
        #endregion

        IList<Graph> NodeList { get; set; }
        string Label { get; set; }

        Boolean isVisited { get; set; }

        Boolean isBeingVisited { get; set; }

        public Graph(string label)
        {
            this.Label = label;
            this.NodeList = new List<Graph>();
        }

        public void AddNeighborNode(Graph node)
        {
            this.NodeList.Add(node);
        }

        public bool DetectCycleUsingDfs()
        {
            foreach (KeyValuePair<string, Graph> graph in graphMapping)
            {
                if (!graph.Value.isVisited)
                {
                    int cycleDetectionValue = this.DetectCycleHelper(graph.Value);

                    if (cycleDetectionValue == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private int DetectCycleHelper(Graph graphNode)
        {
            graphNode.isBeingVisited = true;

            foreach (Graph adjacent in graphNode.NodeList)
            {
                if (adjacent.isBeingVisited)
                {
                    Console.WriteLine("Detected the cycle!");
                    return 0;
                }

                if (!adjacent.isVisited)
                {
                    adjacent.isVisited = true;
                    DetectCycleHelper(adjacent);
                }
            }

            graphNode.isBeingVisited = false;

            return 1;
        }

        /// <summary>
        /// Dfs can be build using the stack or recursion.
        /// </summary>
        public void SimpleDfs(Graph targetNode = null)
        {
            foreach(KeyValuePair<string, Graph> graph in graphMapping)
            {
                if (!graph.Value.isVisited)
                {
                    this.SimpleDfsHelper(graph.Value);
                }
            }
        }

        private void SimpleDfsHelper(Graph graphNode, Graph targetNode = null)
        {
            graphNode.isVisited = true;

            if (targetNode != null && graphNode == targetNode)
            {
                Console.WriteLine("Node found in the graph.");
                return;
            }

            foreach(Graph adjacent in graphNode.NodeList)
            {
                if (!adjacent.isVisited)
                {
                    SimpleDfsHelper(adjacent);
                }
            }
        }

        /// <summary>
        /// The method takes the start and end node to find the shortest distance between them.
        /// This method depends on Bfs that gives the shortest path.
        /// It finds the path from source to destination by mapping the node to parent node in a dictionary and then backtracking to find the shortest path.
        /// </summary>
        /// <returns></returns>
        public List<string> TrackShortestRouteUsingBfs(string startNode, string endNode)
        {
            // Define a queue to track the BFS 
            Queue<Graph> queue = new Queue<Graph>();

            Dictionary<Graph, Graph> graphNodeWithParent = new Dictionary<Graph, Graph>();
            List<string> shortestPath = new List<string>();

            // Treat every node as the starting node, as sometimes the graph network could be disconnected.
            foreach (KeyValuePair<string, Graph> graphNode in graphMapping)
            {
                Graph startGraphNode;
                graphMapping.TryGetValue(graphNode.Key, out startGraphNode);

                // Define the queue and add the starting node to the queue.
                queue.Enqueue(startGraphNode);
                startGraphNode.isVisited = true;
                graphNodeWithParent.Add(startGraphNode, null);

                while (queue.Count > 0)
                {
                    // Remove the node from queue.
                    Graph node = queue.Dequeue();

                    // Check if it's the target node and return if it's true.
                    if (node.Label == endNode)
                    {
                        shortestPath.Add(node.Label);
                        Graph currentNode = graphNodeWithParent[node];

                        // Node found, Return the path of the dictionary.
                        while (currentNode != null)
                        {
                            shortestPath.Add(currentNode.Label);

                            if (currentNode.Label == startNode)
                            {
                                break;
                            }

                            currentNode = graphNodeWithParent[currentNode];
                        }

                        shortestPath.Reverse();
                        return shortestPath;
                    }

                    // Loop through all the neighbors (nodes) and queue them.
                    foreach (Graph currentNode in node.NodeList)
                    {
                        if (!currentNode.isVisited)
                        {
                            queue.Enqueue(currentNode);
                            currentNode.isVisited = true;

                            // Add the current node as key and parent node as value.
                            graphNodeWithParent.Add(currentNode, node);
                        }
                    }
                }
            }

            return null;
        }

        public Graph SimpleBFS(string targetNode)
        {
            // Define a queue to track the BFS 
            Queue<Graph> queue = new Queue<Graph>();

            // Treat every node as the starting node, as sometimes the graphs could be disconnected.
            foreach(KeyValuePair<string, Graph> graphNode in graphMapping)
            {
                Graph startGraphNode;
                graphMapping.TryGetValue(graphNode.Key, out startGraphNode);

                // Define the queue and add the starting node to the queue.
                queue.Enqueue(startGraphNode);
                startGraphNode.isVisited = true;

                while (queue.Count > 0)
                {
                    // Remove the node from queue.
                    Graph node = queue.Dequeue();

                    // Check if it's the target node and return if it's true.
                    if (node.Label == targetNode)
                    {
                        // Node found, Return the node.
                        return node;
                    }

                    // Loop through all the neighbors (nodes) and queue them.
                    foreach (Graph currentNode in node.NodeList)
                    {
                        if (!currentNode.isVisited)
                        {
                            queue.Enqueue(currentNode);
                            currentNode.isVisited = true;
                        }
                    }
                }
            }

            return null;
        }

        [TestMethod]
        public void TestSimpleBfs()
        {
            this.PopulateGraphNetwork();

            string targetNode = "Adam";
            Graph node = this.SimpleBFS(targetNode);

            Assert.AreEqual(node.Label, targetNode);
        }

        [TestMethod]
        public void TestTrackShortestRouteUsingBfs()
        {
            this.PopulateGraphNetwork();

            string startNode = "Jayden";
            string targetNode = "Adam";

            List<string> shortestPathList = this.TrackShortestRouteUsingBfs(startNode, targetNode);

            Assert.IsTrue(shortestPathList.Contains("Jayden"));
            Assert.IsTrue(shortestPathList.Contains("Amelia"));
            Assert.IsTrue(shortestPathList.Contains("Adam"));
        }

        [TestMethod]
        public void TestCyclesInGraphUsingDfs()
        {
            this.PopulateDirectedGraphNetwork(true);
            bool isCycle = this.DetectCycleUsingDfs();

            Assert.IsTrue(isCycle);
        }

        [TestMethod]
        public void TestCyclesInGraphUsingDfs2()
        {
            this.PopulateDirectedGraphNetwork();
            bool isCycle = this.DetectCycleUsingDfs();

            Assert.IsFalse(isCycle);
        }
    }
}
