using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _simulacion_algoritmos.Models
{
    internal class ResponseModel
    {
        private float time;
        private Algorithm algorithm;

        public float Time { get => time; set => time = value; }
        public Algorithm Algorithm { get => algorithm; set => algorithm = value; }
    }
}
