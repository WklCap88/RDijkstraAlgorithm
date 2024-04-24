using System;
using System.Collections.Generic;

namespace Pathfinder
{
    internal static class Algorithm
    {
        public static IEnumerable<Node> ShortestPath(Graph graph, Node from, Node to)
        {
            var priorityQueue = new PriorityQueue<Node>((a, b) => a.Distance.CompareTo(b.Distance));

            // Set distance of the starting node to 0
            from.Distance = 0;
            priorityQueue.Enqueue(from);
            var startToEndDistance = double.PositiveInfinity;

            while (priorityQueue.Count > 0)
            {
                var currentNode = priorityQueue.Dequeue();

                if (currentNode.Equals(to))
                    break;

                if (currentNode.Visited)
                {
                    continue;
                }

                currentNode.Visited = true;

                foreach (var (weight, neighbor) in graph.Neighbors(currentNode))
                {
                    if (neighbor.Visited)
                    {
                        continue;
                    }

                    if (currentNode.Distance + weight < neighbor.Distance && currentNode.Distance + weight < startToEndDistance)
                    {
                        neighbor.Distance = currentNode.Distance + weight;
                        neighbor.Parent = currentNode;

                        if (!priorityQueue.Contains(neighbor))
                        {
                            priorityQueue.Enqueue(neighbor);
                        }
                    }
                }
            }

            return ReconstructShortestPath(from, to);
        }

        private static IEnumerable<Node> ReconstructShortestPath(Node from, Node to)
        {
            var path = new List<Node>();
            var current = to;
            while (current != from)
            {
                if (current.Parent != null)
                {
                    path.Add(current);
                    current = current.Parent;
                }
                else
                {
                    break; // If there is no current.Parent then reached node 'from', exit the loop
                }
            }
            path.Add(from);
            path.Reverse();
            return path;
        }
    }

    internal class PriorityQueue<T>
    {
        private readonly List<T> _heap = new List<T>();
        private Func<T, T, int> _comparer;

        public PriorityQueue(Func<T, T, int> comparer)
        {
            _comparer = comparer;
        }

        public int Count => _heap.Count;

        public bool Contains(T item)
        {
            return _heap.Contains(item);
        }

        public void Enqueue(T item)
        {
            _heap.Add(item);
            HeapifyUp(_heap.Count - 1);
        }

        public T Dequeue()
        {
            var firstItem = _heap[0];
            var lastItem = _heap[_heap.Count - 1];
            _heap[0] = lastItem;
            _heap.RemoveAt(_heap.Count - 1);
            HeapifyDown(0);
            return firstItem;
        }

        public void UpdatePriority(T item)
        {
            var index = _heap.IndexOf(item);
            HeapifyUp(index);
        }

        private void HeapifyUp(int i)
        {
            var parent = (i - 1) / 2;
            if (i > 0 && _comparer(_heap[i], _heap[parent]) < 0)
            {
                Swap(i, parent);
                HeapifyUp(parent);
            }
        }

        private void HeapifyDown(int i)
        {
            var leftChild = 2 * i + 1;
            var rightChild = 2 * i + 2;
            var smallest = i;

            if (leftChild < _heap.Count && _comparer(_heap[leftChild], _heap[smallest]) < 0)
                smallest = leftChild;
            if (rightChild < _heap.Count && _comparer(_heap[rightChild], _heap[smallest]) < 0)
                smallest = rightChild;

            if (smallest != i)
            {
                Swap(i, smallest);
                HeapifyDown(smallest);
            }
        }

        private void Swap(int i, int j)
        {
            (_heap[j], _heap[i]) = (_heap[i], _heap[j]);
        }
    }
}
