using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLib.Models

{
    public abstract class AdjacencyList<T> : IGraph<T>
    {
        protected LinkedList<T>[] _edgeList;
        protected T[] _vertexList;
        protected int _edgeCount;
        private int _currVertexCount;
        private readonly int _maxVertexCount;

        public AdjacencyList(int maxVertexCount)
        {
            _maxVertexCount = maxVertexCount;
            _edgeList = new LinkedList<T>[maxVertexCount];
            _vertexList = new T[maxVertexCount];
            _currVertexCount = 0;

            for (int i = 0; i < maxVertexCount; i++)
                _edgeList[i] = new LinkedList<T>();
        }

        public abstract void CreateEdge(T initial, T final);
        public abstract void RemoveEdge(T initial, T final);

        protected int GetVertexIndex(T val)
        {
            for (int i = 0; i < _vertexList.Length; i++)
                if (EqualityComparer<T>.Default.Equals(_vertexList[i], val))
                    return i;

            return -1;
        }

        public int AddVertex(T data)
        {
            _vertexList[_currVertexCount] = data;

            return _currVertexCount++;
        }

        public bool Adjacent(T initial, T final)
        {
            var index = GetVertexIndex(initial);
            return _edgeList[index].Contains(final);
        }

        protected void ConnectVertices(T start, T end)
        {
            int index = GetVertexIndex(start);

            if (index == -1)
                index = AddVertex(start);

            if (!_edgeList[index].Contains(end))
                _edgeList[index].AddFirst(end);
        }

        protected void RemoveVertex(T start, T end)
        {
            int index = GetVertexIndex(start);
            _edgeList[index].Remove(end);
        }
    }

    public class UndirectedAdjacenyList<T> : AdjacencyList<T>
    {
        public UndirectedAdjacenyList(int vertexCount) : base(vertexCount)
        {
        }

        public override void CreateEdge(T initial, T final)
        {
            ConnectVertices(initial, final);
            ConnectVertices(final, initial);

            _edgeCount++;
        }

        public override void RemoveEdge(T initial, T final)
        {
            RemoveVertex(initial, final);
            RemoveVertex(final, initial);

            _edgeCount--;
        }
    }

    public class DirectedAdjacencyList<T> : AdjacencyList<T>
    {
        public DirectedAdjacencyList(int vertexCount) : base(vertexCount)
        {
        }

        public override void CreateEdge(T initial, T final)
        {
            ConnectVertices(initial, final);
            _edgeCount++;
        }

        public override void RemoveEdge(T initial, T final)
        {
            RemoveVertex(initial, final);
            _edgeCount--;
        }
    }
}
