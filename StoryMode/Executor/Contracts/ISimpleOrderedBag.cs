namespace Executor.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface ISimpleOrderedBag<T> : IEnumerable<T>
         where T : IComparable<T>
    {
        bool Remove(T element);

        int Capacity { get; }

        void Add(T element);

        void AddAll(ICollection<T> elements);

        int Size { get; }

        string JoinWith(string joiner);
    }
}
