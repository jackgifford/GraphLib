using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLib.Models
{
    interface IGraph<T>
    {
        void CreateEdge(T initial, T final);
        void RemoveEdge(T initial, T final);
        bool Adjacent(T initial, T final);
    }
}
