using GraphLib.GraphEssentials;
using GraphLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib.Graphs
{
    public class DirectedGraph<TNode, TEdge> : GraphBase<TNode, TEdge>, IDirectedGraph<TNode, TEdge>
        where TNode : IEquatable<TNode>
        where TEdge : IEquatable<TEdge>, IComparable
    {
        public bool AddNode(TNode value)
        {
            if (FindNode(value) != null)
            {
                return false;
            }
            else
            {
                nodes.Add(new GraphNode<TNode, TEdge>(value));
                return true;
            }
        }

        public bool AddEdge(TNode srcValue, TNode destValue)
        {
            var srcNode = FindNode(srcValue);
            var destNode = FindNode(destValue);
            if (srcNode is null || destNode is null)
            {
                return false;
            }
            else if (srcNode.HasNeighbour(destNode))
            {
                return false;
            }
            else
            {
                srcNode.AddNeighbour(destNode);
                return true;
            }
        }

        public bool RemoveNode(TNode value)
        {
            var removeNode = FindNode(value);
            if (removeNode is null)
            {
                return false;
            }
            else
            {
                foreach (var node in Nodes)
                {
                    node.RemoveNeighbour(removeNode);
                }
                nodes.Remove(removeNode);
                return true;
            }
        }

        public bool RemoveEdge(TNode srcValue, TNode destValue)
        {
            var srcNode = FindNode(srcValue);
            var destNode = FindNode(destValue);
            if (srcNode is null || destNode is null)
            {
                return false;
            }
            else if (!srcNode.HasNeighbour(destNode))
            {
                return false;
            }
            else
            {
                srcNode.RemoveNeighbour(destNode);
                return true;
            }
        }

        public GraphNode<TNode, TEdge> FindNode(TNode value)
        {
            return nodes.Find(x => x.Value.Equals(value));
        }

        public GraphEdge<TNode, TEdge> FindEdge(TNode srcValue, TNode destValue)
        {
            var srcNode = FindNode(srcValue);
            var destNode = FindNode(destValue);
            if (srcNode is null || destNode is null)
            {
                return null;
            }
            return srcNode.Neighbours.FirstOrDefault(x => x.Dest.Equals(destNode));
        }

        public bool ContainsNode(TNode value)
        {
            return FindNode(value) is not null;
        }

        public bool ContainsEdge(TNode srcValue, TNode destValue)
        {
            return FindEdge(srcValue, destValue) is not null;
        }
    }
}
