using System;
using System.Collections.Generic;
using System.Linq;

namespace LimitedList
{
    public class LimitedList<T>
    {
        private readonly List<T> list;
        private readonly int capacity;

        public int count => list.Count;
        public bool isFull => capacity <= count;


        public LimitedList(int capacity)
        {
            this.capacity = Math.Max(0, capacity);
            list = new List<T>(capacity);
           
        }


    }
}
