using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib.GraphEssentials
{
    public class GraphNode<TNode, TEdge>
        where TNode : IEquatable<TNode>
        where TEdge : IEquatable<TEdge>, IComparable
    {
        public TNode Value { get; }
        private readonly List<GraphEdge<TNode, TEdge>> neighbours;
        public IList<GraphEdge<TNode, TEdge>> Neighbours
        {
            get
            {
                return neighbours.AsReadOnly();
            }
        }

        public GraphNode(TNode value)
        {
            Value = value;
            neighbours = new List<GraphEdge<TNode, TEdge>>();
        }

        public bool AddNeighbour(GraphNode<TNode, TEdge> neighbour)
        {
            if (HasNeighbour(neighbour))
            {
                return false;
            }
            else
            {
                neighbours.Add(new GraphEdge<TNode, TEdge>(neighbour));
                return true;
            }
        }

        public bool AddNeighbour(GraphNode<TNode, TEdge> neighbour, TEdge weight)
        {
            if (HasNeighbour(neighbour))
            {
                return false;
            }
            else
            {
                neighbours.Add(new GraphEdge<TNode, TEdge>(neighbour, weight));
                return true;
            }
        }

        public bool HasNeighbour(GraphNode<TNode, TEdge> neighbour)
        {
            return neighbours.Any(x => x.Dest.Equals(neighbour));
        }

        public bool HasNeighbour(GraphNode<TNode, TEdge> neighbour, TEdge weight)
        {
            return neighbours.Any(x => x.Dest.Equals(neighbour) && x.Weight.CompareTo(weight) == 0);
        }

        public bool RemoveNeighbour(GraphNode<TNode, TEdge> neighbour, TEdge weight)
        {
            var toRemove = neighbours.FirstOrDefault(x => x.Dest.Equals(neighbour) && x.Weight.CompareTo(weight) == 0);
            if (toRemove is null)
            {
                return false;
            }
            else
            {
                neighbours.Remove(toRemove);
                return true;
            }
        }

        public bool RemoveNeighbour(GraphNode<TNode, TEdge> neighbour)
        {
            var toRemove = neighbours.FirstOrDefault(x => x.Dest.Equals(neighbour));
            if (toRemove is null)
            {
                return false;
            }
            else
            {
                neighbours.Remove(toRemove);
                return true;
            }
        }

        public bool RemoveAllNeighbours()
        {
            neighbours.Clear();
            return true;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("[Node Value: " + Value + " -> ");
            builder.Append(String.Join(", ", neighbours.Select(x => x.Dest.Value)));
            builder.Append(']');
            return builder.ToString();
        }
    }
}
