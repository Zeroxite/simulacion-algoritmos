using _simulacion_algoritmos.Contracts;
using _simulacion_algoritmos.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _simulacion_algoritmos.Controllers
{
    internal class MasterController : IAlgorithmResponse
    {
        private int parameter;
        public int Parameter { get => parameter; set => parameter = value; }   
        private readonly int[] array;

        public MasterController(int[] array, int parameter)
        {
            this.array = array;
            this.parameter = parameter;
        }

        public ResponseModel GetResponse(Algorithm algorithm)
        {            
             Stopwatch stopwatch = new Stopwatch();
             stopwatch.Start();                   
                 switch (algorithm)
                 {
                    case Algorithm.SequentialSearch:
                        AlgorithmsController.SequentialSearch(array, parameter);
                        break;
                    case Algorithm.BinarySearch:                    
                       AlgorithmsController.BinarySearch(array, parameter);
                       break;
                    case Algorithm.QuickSort:
                        AlgorithmsController.QuickSort(array);
                        break;
                    case Algorithm.BubbleSort:
                         AlgorithmsController.BubbleSort(array);
                         break;
                    case Algorithm.InsertionSort:
                        AlgorithmsController.InsertionSort(array);
                        break;
                 };
             stopwatch.Stop();
             return new ResponseModel() { Algorithm = algorithm, Time = stopwatch.ElapsedMilliseconds  };            
        }
    }
}
