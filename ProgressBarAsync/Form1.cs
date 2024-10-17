using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressBarAsync
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 0;

            var progress = new Progress<int>(percent =>
            {
                progressBar1.Value = percent;
            });
            await Task.Run(() => tarea(progress));
        }

        private void tarea(IProgress<int> progress)
        {
            for (int i = 0; i <= 100; i++)
            {
                //codigo para reportar tarea (simular la carga)
                Thread.Sleep(10);
                if (progress != null)
                    progress.Report(i);
            }
        }
    }
}
