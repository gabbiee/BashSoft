namespace Executor.Contracts
{
    using System.Collections.Generic;

    public interface IDataSorter
    {
        void PrintSortedStudents(Dictionary<string, double> studentsSorted);
    }
}
