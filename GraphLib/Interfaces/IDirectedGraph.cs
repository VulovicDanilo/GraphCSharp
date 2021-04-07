using GraphLib.GraphEssentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib.Interfaces
{
    interface IDirectedGraph<TNode, TEdge>
        where TNode : IEquatable<TNode>
        where TEdge : IEquatable<TEdge>, IComparable
    {
        public bool AddNode(TNode value);
        public bool AddEdge(TNode srcValue, TNode destValue);
        public bool RemoveNode(TNode value);
        public bool RemoveEdge(TNode srcValue, TNode destValue);
        public GraphNode<TNode, TEdge> FindNode(TNode value);
        public GraphEdge<TNode, TEdge> FindEdge(TNode srcValue, TNode destValue);
        public bool ContainsNode(TNode value);
        public bool ContainsEdge(TNode srcValue, TNode destValue);
    }
}
