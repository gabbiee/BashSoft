namespace Executor.Contracts
{
    using System;

    public interface Student:IComparable<Student>
    {
        string UserName { get; }

        void EnrollInCourse(Course course);

        void SetMarkOnCourse(string courseName, params int[] scores);

        string GetMarkForCourse(string courseName);

    }
}
