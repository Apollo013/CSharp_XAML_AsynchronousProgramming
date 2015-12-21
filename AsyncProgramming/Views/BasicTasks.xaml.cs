using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AsyncProgramming.Views
{
    /// <summary>
    /// Interaction logic for BasicTasks.xaml
    /// </summary>
    public partial class BasicTasks : Page, INotifyPropertyChanged
    {
        #region Fields
        
        private string dateDisplay = "";
        private string timeDisplay = "";
        private string datetimeDisplay = "";
        
        #endregion

        #region Properties

        public string DateDisplay
        {
            get { return this.dateDisplay; }
            set
            {
                if (this.dateDisplay != value)
                {
                    this.dateDisplay = value;
                    this.OnPropertyChanged();
                };
            }
        }

        public string TimeDisplay
        {
            get { return this.timeDisplay; }
            set
            {
                if (this.timeDisplay != value)
                {
                    this.timeDisplay = value;
                    this.OnPropertyChanged();
                };
            }
        }

        public string DateTimeDisplay
        {
            get { return this.datetimeDisplay; }
            set
            {
                if (this.datetimeDisplay != value)
                {
                    this.datetimeDisplay = value;
                    this.OnPropertyChanged();
                };
            }
        }

        #endregion

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

        public BasicTasks()
        {
            InitializeComponent();
            this.DataContext = this;
            this.DateDisplay = "Click for date (1 sec wait)";
            this.TimeDisplay = "Click for time (1 sec wait)";
            this.DateTimeDisplay = "Click for date/time (1 sec wait)";
        }

        #region Methods

        private void DisplayDate()
        {
            // 1 Second delay just to simulate some work being performed
            Thread.Sleep(1000);
            this.DateDisplay = "Today's Date is : " + DateTime.Now.ToShortDateString();
        }

        private void DisplayDateTime()
        {
            // 1 Second delay just to simulate some work being performed
            Thread.Sleep(1000);
            this.DateTimeDisplay = DateTime.Now.ToString();
        }

        #endregion

        #region Event Handlers

        private void btnDisplayDate_Click(object sender, RoutedEventArgs e)
        {
            Task t1 = new Task(new Action(DisplayDate));
            t1.Start();
        }

        private void btnDisplayTime_Click(object sender, RoutedEventArgs e)
        {
            Task t2 = new Task(delegate { this.TimeDisplay = DateTime.Now.ToShortTimeString(); });
            // 1 Second delay just to simulate some work being performed
            Thread.Sleep(1000);
            t2.Start();
        }

        private void btnDisplayDateTime_Click(object sender, RoutedEventArgs e)
        {
            Task t3 = new Task(() => DisplayDateTime());
            t3.Start();
        }

        private void btnContinuation_Click(object sender, RoutedEventArgs e)
        {
            // 1 Second delay just to simulate some work being performed
            Thread.Sleep(1000);

            // Creating a Task Continuation
            // Create a task that returns a string.
            Task<string> t1 = new Task<string>(() => { return "Hello"; });

            // Create the continuation task. 
            // The delegate takes the result of the antecedent task as an argument.
            Task<string> t2 = t1.ContinueWith((antecedent) => { return String.Format($"{antecedent.Result} World !!"); });

            t1.Start();

            txtContinuation.Text = t2.Result;
        }

        private void btnNestedTask_Click(object sender, RoutedEventArgs e)
        {
            var parent = Task.Factory.StartNew(() =>
            {
                //txtNestedTask1.Text = "Outer task starting…";
                Dispatcher.BeginInvoke(new Action(() => { txtNestedTask1.Text = "Outer task starting…"; }));
                var child = Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(1000);
                    Dispatcher.BeginInvoke(new Action(() => { txtNestedTask2.Text = "Inner task starting…"; }));
                    Thread.Sleep(1000);
                    Dispatcher.BeginInvoke(new Action(() => { txtNestedTask3.Text = "Inner task ending…"; }));                    
                });
            });
            
            parent.Wait();
            Dispatcher.BeginInvoke(new Action(() => { txtNestedTask4.Text = "Outer task ending…"; }));
            
        }

        #endregion

    }
}
