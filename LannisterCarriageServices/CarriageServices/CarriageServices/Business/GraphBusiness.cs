using CarriageServices.Exceptions;
using CarriageServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarriageServices.Business
{
    public class GraphBusiness
    {
        /// <summary>
        /// Creates a Graph with de information provided
        /// </summary>
        /// <param name="graphInfo">Informations about the Graph. Format AB0</param>
        /// <returns>A <coide>Graph</coide> object created according <paramref name="graphInfo"/></returns>
        public static Graph CreateGraph(string graphInfo)
        {
            Graph graph = new Graph();
            // Remove spaces and convert to Upper 
            graphInfo = graphInfo.Replace(" ", "").ToUpper().Trim();

            string[] nodeInfos = graphInfo.Split(',');

            foreach (string nodeInfo in nodeInfos)
            {
                // All nodes has starting and ending and a value
                if (nodeInfo.Length == 3)
                {
                    // Build a Node and Node Connection Information
                    char nodeName = nodeInfo[0];
                    NodeConnection nodeConn = new NodeConnection();
                    nodeConn.Node = nodeInfo[1];
                    nodeConn.RouteValue = int.Parse(nodeInfo[2].ToString());

                    // Searches for a node in Graph                    
                    Node node = FindNode(graph, nodeName);

                    // Add a new node or new node connection in a existing node
                    if (node != null)
                    {
                        if (!node.Connections.Contains(nodeConn))
                            node.Connections.Add(nodeConn);
                        else
                            throw new DuplicatedNodeConnectionException(String.Format("Node: {0}, Value: {1}", nodeConn.Node, nodeConn.RouteValue));
                    }
                    else
                    {
                        Node newNode = new Node();
                        newNode.Name = nodeName;
                        newNode.Connections.Add(nodeConn);

                        graph.Nodes.Add(newNode);
                    }
                }
                else
                    throw new NodeInfoIncorrectException(nodeInfo);                    
            }
            return graph;
        }

        /// <summary>
        /// Searchs a node in Graph nodes list
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        private static Node FindNode(Graph graph, char nodeName)
        {            
            if (graph.Nodes.Count > 0)
            {
                return graph.Nodes.Find(n => n.Name.Equals(nodeName));
            }                

            return null;
        }
    }
}