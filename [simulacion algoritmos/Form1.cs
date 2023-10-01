using _simulacion_algoritmos.Controllers;
using _simulacion_algoritmos.Models;
using System;

namespace _simulacion_algoritmos
{
    public partial class Form1 : Form
    {
        int[] array;
        public Form1()
        {
            InitializeComponent();
            
            Random random = new();
            int tamañoArray = 100000;
            array = new int[tamañoArray];
            int value = 1;
            for (int i = 0; i < tamañoArray; i++)
            {                 
                while (array.Any((x) => x == value)){
                    value = random.Next(1, 1000000);
                }
                array[i] = value;
            }
            Load();
        }

        private void Load()
        {
            List<Task<ResponseModel>> responseModelTaks = new();
            List<ResponseModel> responseModel = new();
            foreach(Algorithm algorith in AlgorithValues.GetValues())
            {
                Task<ResponseModel> coso;
                if (algorith == Algorithm.BubbleSort)
                {
                    coso = new(() => new MasterController(array.OrderBy(x=>x).ToArray(), 183).GetResponse(algorith));
                }
                else
                {
                    coso = new(() => new MasterController(array, 183).GetResponse(algorith));
                }                
                responseModelTaks.Add(coso);
                coso.Start();
            }

            while(responseModelTaks.Any((task) => !task.IsCompleted))
            {
            }
            
            foreach (Task<ResponseModel> response in responseModelTaks)
            {
                responseModel.Add(response.Result);
            }
        }

    }
}