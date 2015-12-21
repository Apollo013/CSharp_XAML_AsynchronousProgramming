using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsyncProgramming.Views
{
    /// <summary>
    /// Interaction logic for CancellationToken.xaml
    /// </summary>
    public partial class CancellationTokens : Page, INotifyPropertyChanged
    {

        private string outputText = "";


        public string OutPutText
        {
            get { return this.outputText; }
            set
            {
                if (this.outputText != value)
                {
                    this.outputText = value;
                    this.OnPropertyChanged();
                };
            }
        }



        #region 'INotifyPropertyChanged'

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string propName = null)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        #endregion


        public CancellationTokens()
        {
            InitializeComponent();
            this.DataContext = this;
            this.OutPutText = "Click button to run Task and wait 2 secs.";
        }

        private void btnRunTask_Click(object sender, RoutedEventArgs e)
        {            
            // Create a cancellation token source and obtain a cancellation token.
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken ct = cts.Token;

            // Create and start a long-running task.
            var task1 = Task.Run(() => { this.OutPutText = "Starting Task."; DoWork(ct); }, ct);

            

            // Cancel the task
            cts.Cancel();

            try
            {
                Thread.Sleep(2000);
                task1.Wait();
            }
            catch (AggregateException ae)
            {
                foreach (var innerException in ae.InnerExceptions)
                {
                    if (innerException is TaskCanceledException)
                    {
                        this.OutPutText = "The task was cancelled.";
                    }
                    else
                    {
                        // If it's any other kind of exception, re-throw it.
                        this.OutPutText = $"{innerException.Message}";
                    }
                }
            }
        }

        private void DoWork(CancellationToken token)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(500);
                // Throw an OperationCanceledException if cancellation was requested.
                token.ThrowIfCancellationRequested();
            }
        }

    }
}
