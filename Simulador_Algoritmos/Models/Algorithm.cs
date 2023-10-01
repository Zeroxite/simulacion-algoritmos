using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _simulacion_algoritmos.Models
{
    public enum Algorithm
    {
        SequentialSearch,
        BinarySearch,
        BubbleSort,
        QuickSort,
        InsertionSort
    }

    public class AlgorithValues
    {
        public static List<Algorithm> GetValues()
        {
            return new List<Algorithm>
            {                
                Algorithm.SequentialSearch,
                Algorithm.BinarySearch,
                Algorithm.BubbleSort,
                Algorithm.QuickSort,
                Algorithm.InsertionSort
            };
        }
    }
}
