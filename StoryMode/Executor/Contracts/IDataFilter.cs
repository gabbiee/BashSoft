namespace Executor.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IDataFilter
    {
        void PrintFilteredStudents(Dictionary<string, double> studentsWithMarks,
            Predicate<double> givenFilter,
            int studentsToTake);


    }
}
