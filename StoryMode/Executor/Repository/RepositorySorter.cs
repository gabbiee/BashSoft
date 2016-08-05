using Executor.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Executor.Repository
{
    using Contracts;
    public class RepositorySorter:IDataSorter
    {                                                
        public void OrderAndTake(Dictionary<string, double> studentsMarks,
          string comparison, int studentsToTake)
        {
            comparison = comparison.ToLower();
            if (comparison == "ascending")
            {
                this.PrintSortedStudents(studentsMarks.OrderBy(x => x.Value)
                                        .Take(studentsToTake)
                                        .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else if (comparison == "descending")
            {
                this.PrintSortedStudents(studentsMarks.OrderByDescending(x => x.Value)
                                        .Take(studentsToTake)
                                        .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else
            {                            
                throw new ArgumentException(ExceptionMessages.InvalidComparisonQuery);
            }
        }
                                  
        public void PrintSortedStudents(Dictionary<string, double> studentsSorted)
        {
            foreach (KeyValuePair<string, double> keyValuePair in studentsSorted)
            {
                OutputWriter.WriteMessageOnNewLine(string.Format($"{keyValuePair.Key} - {keyValuePair.Value}"));
            }
        }
    }
}
