namespace Executor.DataStructures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;

    public class SimpleSortedList<T> : ISimpleOrderedBag<T>
         where T : IComparable<T>
    {
        private const int DefaultSize = 16;

        private T[] innerCollection;
        private int size;
        private IComparer<T> comparison;

        private void InitializeInnerCollection(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException("Capacity cannot be negative!");
            }
            this.innerCollection = new T[capacity];
        }

        public int Capacity
        {
            get { return this.innerCollection.Length; }
        }

        public SimpleSortedList(int capacity, IComparer<T> comparison)
        {
            this.InitializeInnerCollection(capacity);
            this.size = 0;
            this.comparison = comparison;

        }

        public SimpleSortedList(int size)
            : this(size, Comparer<T>.Create((x, y) => x.CompareTo(y)))
        {

            this.size = 0;

        }


        public SimpleSortedList(IComparer<T> comparison)
          : this(DefaultSize, comparison)
        {

        }

        public SimpleSortedList()
           : this(DefaultSize, Comparer<T>.Create((x, y) => x.CompareTo(y)))
        {

        }




        public int Size
        {
            get { return size; }
        }


        public bool Remove(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }

            bool hasBeenRemoved = false;
            int indexOfRemovedElement = 0;

            for (int i = 0; i < this.Size; i++)
            {
                if (this.innerCollection[i].Equals(element))
                {
                    indexOfRemovedElement = i;
                    this.innerCollection[i] = default(T);
                    hasBeenRemoved = true;
                    break;

                }
            }

            if (hasBeenRemoved)
            {
                for (int i = indexOfRemovedElement; i < this.Size - 1; i++)
                {
                    this.innerCollection[i] = this.innerCollection[i + 1];
                   
                }
                this.size--;
                this.innerCollection[this.size - 1] = default(T);
            }

            return hasBeenRemoved;
        }

        public void Add(T element)
        {

            if (element == null)
            {
                throw new ArgumentNullException();
            }

            if (size >= innerCollection.Length)
            {
                Resize();
            }

            this.innerCollection[size] = element;
            this.size++;
            Array.Sort(this.innerCollection, 0, size, comparison);
        }

        public void AddAll(ICollection<T> elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException();
            }

            if (this.Size + elements.Count >= this.innerCollection.Length)
            {
                this.MultiResize(elements);
            }

            foreach (var element in elements)
            {
                this.innerCollection[Size] = element;
                this.size++;

            }

            Array.Sort(this.innerCollection, 0, size, comparison);
        }

        private void MultiResize(ICollection<T> elements)
        {
            int newSize = this.innerCollection.Length * 2;

            while (this.Size + elements.Count >= newSize)
            {
                newSize *= 2;
            }

            T[] newCollection = new T[newSize];
            Array.Copy(this.innerCollection, newCollection, size);
            this.innerCollection = newCollection;
        }

        public string JoinWith(string joiner)
        {
            if (joiner == null)
            {
                throw new ArgumentNullException();
            }


            var sb = new StringBuilder();

            foreach (var el in this)
            {
                sb.Append(el);
                sb.Append(joiner);

            }

            sb.Remove(sb.Length - joiner.Length, joiner.Length);
            return sb.ToString();
        }


        private void Resize()
        {
            T[] newCollection = new T[this.size * 2];
            Array.Copy(innerCollection, newCollection, Size);
            innerCollection = newCollection;
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Size; i++)
            {
                yield return this.innerCollection[i];
            }
        }
    }
}
