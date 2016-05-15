using CarriageServices.Exceptions;
using CarriageServices.Models;
using Graph.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace CarriageServices.Controllers
{
    
    /// <summary>
    /// Responsible to provide a RESTfull services to Carriage Services clients
    /// </summary>
    [RoutePrefix("api/CarriageServices")]    
    public class CarriageServicesController : ApiController
    {

        /// <summary>
        /// Computes all routes between two nodes.
        /// </summary>
        /// <param name="startNode">Initial node of a path.</param>
        /// <param name="endNode">End node of a path.</param>
        /// <param name="maxStops">Maximum number of stops in a path.</param>
        /// <returns>List of <code>GraphRouteAlgorithmReturn</code> object in JSON or XML format, that contains the paths and the weights of all routes found.</returns>
        // GET AvailableRoutes/C/C/3
        [Route("AvailableRoutes/{startNode:length(1)}/{endNode:length(1)}/{maxStops:int}")]

        public IEnumerable<GraphRouteAlgorithmReturn> GetAllRoutes(char startNode, char endNode, int maxStops)
        {
            GraphInstance graph = GraphInstance.Instance;
            if (graph.IsGraphBuilded())
                return graph.AllRoutes(startNode, endNode, maxStops);
            else
                throw new GraphNotBuildException();
        }

        /// <summary>
        /// Computes the total weight of any route in a graph.
        /// </summary>
        /// <param name="route">Route to calculate weight. Format: 'A-B-C'</param>
        /// <returns>-1 if doesn't exists a route, total weight value if exists</returns>
        // GET Distance/A-B-C
        [Route("Distance/{route}")]

        public int GetDistance(string route)
        {
            GraphInstance graph = GraphInstance.Instance;
            if (graph.IsGraphBuilded())
                return graph.Distance(route);
            else
                throw new GraphNotBuildException();
        }

        /// <summary>
        /// Computes the shortest path between two nodes.
        /// </summary>
        /// <param name="startNode">Initial node of a path.</param>
        /// <param name="endNode">End node of a path.</param>
        /// <returns>Object <code>GraphRouteAlgorithmReturn</code> in JSON or XML format, that contains the path and the weight of distance computed.</returns>
        // GET ShortestRoute/A/C"
        [Route("ShortestRoute/{startNode:length(1)}/{endNode:length(1)}")]

        public GraphRouteAlgorithmReturn GetShortestRoute(char startNode, char endNode)
        {
            GraphInstance graph = GraphInstance.Instance;
            if (graph.IsGraphBuilded())
                return graph.ShortestRoute(startNode, endNode);
            else
                throw new GraphNotBuildException();
        }
        
        /// <summary>
        /// Creates a new instance of a Graph to be used in another avaiable operations.
        /// </summary>
        /// <param name="value">Graph definition.</param>
        /// <returns><code>HttpStatusCode.Created</code> if the graph was created successfully, <code>ttpStatusCode.NotAcceptable</code> otherwise.</returns>
        // POST api/CarriageServices/AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7
        [Route("{value}")]
        public HttpStatusCode PostGraph(string value)
        {            
            if (value != null)
            {
                GraphInstance graph = GraphInstance.Instance;
                graph.BuildGraph(value);

                return HttpStatusCode.Created;
            }
            return HttpStatusCode.NotAcceptable;
        }
    }
}
