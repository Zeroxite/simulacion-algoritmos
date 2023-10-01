using _simulacion_algoritmos.Controllers;
using _simulacion_algoritmos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Simulador_Algoritmos
{
    public partial class Form1 : Form
    {
        int[] array;
        public Form1()
        {
            InitializeComponent();           
        }

        private void Load()
        {
            List<Task<ResponseModel>> responseModelTaks = new List<Task<ResponseModel>>();
            List<ResponseModel> responseModel = new List<ResponseModel>();
            foreach (Algorithm algorith in AlgorithValues.GetValues())
            {
                Task<ResponseModel> coso;
                if (algorith == Algorithm.BinarySearch)
                {
                    coso = new Task<ResponseModel>(() => new MasterController(array.OrderBy(x => x).ToArray(), 800).GetResponse(algorith));
                }
                else
                {
                    coso = new Task<ResponseModel>(() => new MasterController(array, 800).GetResponse(algorith));
                }
                responseModelTaks.Add(coso);
                coso.Start();
            }

            while (responseModelTaks.Any((task) => !task.IsCompleted))
            {
            }

            foreach (Task<ResponseModel> response in responseModelTaks)
            {
                responseModel.Add(response.Result);
            }
            chart1.Series.Clear();
            Series serie = chart1.Series.Add("MiSerie");

            foreach (ResponseModel item in responseModel)
            {
                serie.Points.AddXY(item.Algorithm.ToString(), item.Time);
            }

    

            // Configurar el tipo de gráfico (por ejemplo, de barras)
            serie.ChartType = SeriesChartType.Bar;

            // Puedes personalizar el gráfico más según tus necesidades
            chart1.ChartAreas[0].AxisX.Title = "Algoritmo";
            chart1.ChartAreas[0].AxisY.Title = "Ms";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Random random = new Random();
                int tamañoArray = Convert.ToInt32(textBox1.Text);
                array = new int[tamañoArray];
                int value = 1;
                for (int i = 0; i < tamañoArray; i++)
                {
                    // while (array.Any((x) => x == value))
                    // {
                    value = random.Next(1, 10000000);
                    // }
                    array[i] = value;
                }
                Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Valor incorrecto.");
            }            
        }
    }
}
