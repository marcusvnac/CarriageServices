using Graph.Models;
using System.Collections.Generic;
using System.Text;

namespace Graph.Business
{
    /// <summary>
    /// Implements an algorithm to find all routes from a node to another in a graph.
    /// </summary>
    public class AllRoutesAlgorithm
    {
        /// <summary>
        /// Graph object.
        /// </summary>
        private GraphModel graph;

        /// <summary>
        /// Initial node of a path.
        /// </summary>
        private char startNode;

        /// <summary>
        /// End node of a path.
        /// </summary>
        private char endNode;

        /// <summary>
        /// Maximum number of stops in a path.
        /// </summary>
        private int maxStops;

        /// <summary>
        /// List of routes found.
        /// </summary>
        private List<string> routes;

        /// <summary>
        /// Stack of nodes that are still not visited.
        /// </summary>
        private Stack<char> nodesToVisit;

        /// <summary>
        /// Initializes a new instance of the AllRoutesAlgorithm class with the informations provided.
        /// </summary>
        /// <param name="graph">Graph where algorithm is executed.</param>
        /// <param name="startNode">Initial node of path.</param>
        /// <param name="endNode">End node of a path.</param>
        /// <param name="maxStops">Maximum number of stops in a path.</param>
        public AllRoutesAlgorithm(GraphModel graph, char startNode, char endNode, int maxStops)
        {
            this.graph = graph;
            this.startNode = startNode;
            this.endNode = endNode;
            this.maxStops = maxStops;

            routes = new List<string>();

            nodesToVisit = new Stack<char>();
            nodesToVisit.Push(startNode);
        }

        /// <summary>
        /// Computes all routes between two nodes in a graph.
        /// </summary>
        private void ComputeRoutes()
        {
            StringBuilder route = new StringBuilder();
            int count = -1;

            while (nodesToVisit.Count > 0)
            {
                char actualNode = nodesToVisit.Pop();
                Node node = graph.Nodes.Find(n => n.Label.Equals(actualNode));

                // Verify if route still valid
                if (route.Length > 0)
                {
                    char priorNodeToVerify = route[route.Length - 1];
                    Node verNode = graph.Nodes.Find(n => n.Label.Equals(priorNodeToVerify));
                    if (verNode.edges.Find(n => n.NodeLabel.Equals(node.Label)) == null)
                        continue;
                }

                // Add a node to route
                if (route.Length == 0)
                    route.Append(node.Label);
                else
                    route.Append("-" + node.Label);
                count++;

                // Verify if maximum stops reached
                if ((count >= maxStops) && !(node.Label.Equals(endNode)))
                {
                    route.Remove(route.Length-2, 2);
                    count--;

                    bool continueValidation = true;
                    while (continueValidation)
                    {
                        char nodeToVerify = route[route.Length - 1];
                        char priorNodeToVerify = route[route.Length - 3];

                        Node verNode = graph.Nodes.Find(n => n.Label.Equals(nodeToVerify));
                        Node priorNode = graph.Nodes.Find(n => n.Label.Equals(priorNodeToVerify));
                        if (verNode.edges.Count <= 1
                            || (priorNode.edges.Find(n => n.NodeLabel.Equals(nodeToVerify)) == null))
                        {
                            route.Remove(route.Length - 2, 2);
                            count--;
                            continueValidation = (route.Length > 2);
                        }
                        else
                            continueValidation = false;
                    }                    
                    continue;
                }

                // Verify if found a path end 
                if (node.Label.Equals(endNode))
                {
                    if (!routes.Contains(route.ToString())
                        && route.ToString().Split('-').Length > 1)
                        routes.Add(route.ToString());

                    if (count >= maxStops-1)
                    {                        
                        route.Clear();
                        route.Append(startNode);
                        count = 0;
                        //if (nodesToVisit.Count == 0)
                          //  nodesToVisit.Push(startNode);
                        continue;
                    }
                }
                
                foreach (Edge conn in node.edges)
                {
                    nodesToVisit.Push(conn.NodeLabel);
                }
            } 
        }

        /// <summary>
        /// Computes all routes between two nodes in a graph.
        /// </summary>
        /// <returns>List of <code>GraphRouteAlgorithmReturn</code> with the informations about the paths found. Empty list otherwise.</returns>
        public List<GraphRouteAlgorithmReturn> ComputeAllRoutes()
        {
            ComputeRoutes();

            List<GraphRouteAlgorithmReturn> result = new List<GraphRouteAlgorithmReturn>();

            foreach (string route in routes)
            {
                GraphRouteAlgorithmReturn path = new GraphRouteAlgorithmReturn();
                path.Value = route.Split('-').Length-1;
                path.Path = route;

                result.Add(path);
            }

            return result;
        }

    }
}
