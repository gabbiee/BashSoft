namespace Executor.Contracts
{
    using System;
    using System.Collections.Generic;
    using Repository;

    public interface Course:IComparable<Course>
  {
       string Name { get; }

        Dictionary<string, Student> GetStudentByName();

        void EnrollStudent(Student student);
  }
}
