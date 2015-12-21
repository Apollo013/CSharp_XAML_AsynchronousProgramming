using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
    /// Interaction logic for FileIO.xaml
    /// </summary>
    public partial class FileIO : Page
    {
        public FileIO()
        {
            InitializeComponent();
        }

        private void btnWriteFile_Click(object sender, RoutedEventArgs e)
        {
            WriteFile();
        }

        private void btnReadFile_Click(object sender, RoutedEventArgs e)
        {
            ReadFile();
        }

        public async void WriteFile()
        {
            string filePath = @"SampleFile.txt";
            string text = txtContents.Text;

            await WriteTextAsync(filePath, text);
        }

        private async Task WriteTextAsync(string filePath, string text)
        {
            byte[] encodedText = Encoding.Unicode.GetBytes(text);

            using (FileStream sourceStream = new FileStream(filePath, FileMode.Truncate, FileAccess.Write, FileShare.None,  bufferSize: 4096))
            {
                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
            };
        }

        public async void ReadFile()
        {
            string filePath = @"SampleFile.txt";

            if (File.Exists(filePath) == false)
            {
                MessageBox.Show(filePath + " not found", "File Error", MessageBoxButton.OK);
            }
            else
            {
                try
                {
                    string text = await ReadTextAsync(filePath);
                    txtContents.Text = text;
                }
                catch (Exception ex)
                {
                    //Debug.WriteLine(ex.Message);
                }
            }
        }

        private async Task<string> ReadTextAsync(string filePath)
        {
            using (FileStream sourceStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096))
            {
                StringBuilder sb = new StringBuilder();

                byte[] buffer = new byte[0x1000];
                int numRead;
                while ((numRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    string text = Encoding.Unicode.GetString(buffer, 0, numRead);
                    sb.Append(text);
                }

                return sb.ToString();
            }
        }

    }
}
