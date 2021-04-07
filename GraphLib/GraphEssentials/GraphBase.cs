using GraphLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib.GraphEssentials
{
    public abstract class GraphBase<TNode, TEdge> : IGraphBase<TNode, TEdge>
        where TNode : IEquatable<TNode>
        where TEdge : IEquatable<TEdge>, IComparable
    {
        protected readonly List<GraphNode<TNode, TEdge>> nodes;

        public virtual int NodesCount
        {
            get
            {
                return nodes.Count;
            }
        }

        public virtual int EdgesCount
        {
            get
            {
                return nodes.Sum(x => x.Neighbours.Count);
            }
        }

        public virtual IReadOnlyList<GraphNode<TNode, TEdge>> Nodes
        {
            get
            {
                return nodes.AsReadOnly();
            }
        }

        public GraphBase()
        {
            nodes = new List<GraphNode<TNode, TEdge>>();
        }

        public virtual void Clear()
        {
            foreach (var node in nodes)
            {
                node.RemoveAllNeighbours();
            }
            nodes.Clear();
        }

        public override string ToString()
        {
            var countInfo = $"Nodes count: {NodesCount}{Environment.NewLine}";
            return countInfo + String.Join($"{Environment.NewLine}", Nodes.Select(x => x.ToString()));
        }
    }
}
