using GraphLib.GraphEssentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib.Interfaces
{
    public interface IGraphBase<TNode, TEdge> :IClearable
        where TNode : IEquatable<TNode>
        where TEdge : IEquatable<TEdge>, IComparable
    {
        public int NodesCount { get; }
        public int EdgesCount { get; }
        public IReadOnlyList<GraphNode<TNode, TEdge>> Nodes { get; }
    }
}
