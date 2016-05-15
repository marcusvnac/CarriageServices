using System;

namespace CarriageServices.Exceptions
{
    /// <summary>
    /// Exception that occurrs when Graph was not build previously
    /// </summary> 
    [Serializable]
    public class GraphNotBuildException : Exception
    {
        public GraphNotBuildException() 
            : base(String.Format("The graph was not builded yet. Please call POST method to build your graph."))
        {
        }

    }
}