using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Interaction logic for AsyncCallbacks.xaml
    /// </summary>
    public partial class AsyncCallbacks : Page
    {
        public AsyncCallbacks()
        {
            InitializeComponent();
            btnTaskRun.PreviewMouseDown += new MouseButtonEventHandler(InitiateTask);
            btnAsyncCall.PreviewMouseDown += new MouseButtonEventHandler(InitiateTask);
            btnAsyncCall_UIBlock.PreviewMouseDown += new MouseButtonEventHandler(InitiateTask);
            btnAsyncCall_ReturnValue.PreviewMouseDown += new MouseButtonEventHandler(InitiateTask);
            btnAsyncCall_InvokeCallback.PreviewMouseDown += new MouseButtonEventHandler(InitiateTask);
        }

        private void InitiateTask(object sender, MouseButtonEventArgs e)
        {
            txtOutput.Text = "Running Task";
        }

        private void CompleteTask(string msg)
        {
            Thread.Sleep(1000);
            txtOutput.Text = msg + " Completed";
        }



        private void btnTaskRun_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() => { txtOutput.Dispatcher.BeginInvoke(new Action(() => CompleteTask("Task.Run"))); });
        }



        private async void btnAsyncCall_Click(object sender, RoutedEventArgs e)
        {
            Task<string> t1 = Task.Run<string>(() =>
            {
                return "Async Call";
            });

            CompleteTask(await t1);
        }



        private void btnAsyncCall_UIBlock_Click(object sender, RoutedEventArgs e)
        {
            Task<string> t1 = Task.Run<string>(() =>
            {
                Thread.Sleep(2000);
                return "Async Call With UI Block";
            });

            CompleteTask(t1.Result);
        }



        private async void btnAsyncCall_ReturnValue_Click(object sender, RoutedEventArgs e)
        {
            CompleteTask(await ReturnValue());
        }

        private async Task<string> ReturnValue()
        {
            var result = await Task.Run<string>(() =>
            {
                Thread.Sleep(2000);
                return "Async Call With Return Value";
            });

            return result;
        }



        private async void btnAsyncCall_InvokeCallback_Click(object sender, RoutedEventArgs e)
        {
            await MethodToInvokeCallBack(CallBackMethod);
        }

        public async Task MethodToInvokeCallBack(Action<string> callback)
        {
            var result = await Task.Run(() =>
            {
                Thread.Sleep(2000);
                return "Async Call Invoke Callback";
            });

            await Task.Run(() => callback(result));
        }

        private void CallBackMethod(string msg)
        {
            Dispatcher.BeginInvoke(new Action(() => { txtOutput.Text = msg + " Completed"; }));
        }

        private async void btnCheckUrl_Click(object sender, RoutedEventArgs e)
        {
            string url = txtUrl.Text;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = await Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, request) as HttpWebResponse;
            lblResult.Content = String.Format("The URL returned the following status code: {0}", response.StatusCode);
        }

        private async void btnErrorHandler2_Click(object sender, RoutedEventArgs e)
        {
            string url = txtUrl2.Text;
            using (WebClient client = new WebClient())
            {
                try
                {
                    string data = await client.DownloadStringTaskAsync(url);
                    lblResult2.Content = data.ToString();
                }
                catch (WebException ex)
                {
                    lblResult2.Content = ex.Message;
                }
            }
        }


        private void btnUnobservedTaskException_Click(object sender, RoutedEventArgs e)
        {
            string url = txtUrl3.Text;

            TaskScheduler.UnobservedTaskException += new EventHandler<UnobservedTaskExceptionEventArgs>(TaskScheduler_UnobservedTaskException);

            RunTask();

            Thread.Sleep(2000);

            GC.Collect();
            GC.WaitForPendingFinalizers();

        }

        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() => { lblResult3.Content = "Caught! " + e.Exception.Message; }));
            e.SetObserved();
        }

        private void RunTask()
        {
            Task<int> task = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1000); // emulate some calculation
                lblResult3.Content = "Before Exception!";
                throw new Exception();
                return 1;
            });
        }

    }
}
