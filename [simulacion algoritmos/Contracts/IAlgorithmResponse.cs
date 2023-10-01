using _simulacion_algoritmos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _simulacion_algoritmos.Contracts
{
    internal interface IAlgorithmResponse
    {
        int Parameter { get; set; }
        public ResponseModel GetResponse(Algorithm algorithm);
    }
}
