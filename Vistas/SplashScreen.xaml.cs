using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using Vistas;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para Splashcreen.xaml
    /// </summary>
    public partial class Splashcreen : Window
    {
        DispatcherTimer dT = new DispatcherTimer();

        public Splashcreen()
        {
            InitializeComponent();

            dT.Tick += new EventHandler(dt_tick);
            dT.Interval = new TimeSpan(0, 0, 2);
            dT.Start();
        }

        private void dt_tick(object sender, EventArgs e)
        {
            MainWindow db = new MainWindow();
            db.Show();
            dT.Stop();
            this.Close();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;

            worker.RunWorkerAsync();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                (sender as BackgroundWorker).ReportProgress(i);
                Thread.Sleep(100);
            }
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbStatus.Value = e.ProgressPercentage;
        }

    }
}

