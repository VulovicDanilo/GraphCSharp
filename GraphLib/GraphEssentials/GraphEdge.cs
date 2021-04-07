using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib.GraphEssentials
{
    public class GraphEdge<TNode, TEdge>
        where TNode : IEquatable<TNode>
        where TEdge : IEquatable<TEdge>, IComparable
    {
        public TEdge Weight { get; }
        public GraphNode<TNode, TEdge> Dest { get; }
        public GraphEdge(GraphNode<TNode, TEdge> dest)
        {
            Dest = dest;
        }
        public GraphEdge(GraphNode<TNode, TEdge> dest, TEdge value)
        {
            Weight = value;
            Dest = dest;
        }
    }
}
