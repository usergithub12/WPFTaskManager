using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WPFTaskManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            var proc = Process.GetProcesses();

            List<string> info = new List<string>();
            foreach (var item in proc)
            {
                
                foreach (ProcessThread ths in item.Threads)
                {
                    
                    try
                    {

                    info.Add($"{item.ProcessName} {ths.Id} {ths.PriorityLevel} {ths.StartTime} ");
                    }
                    catch (Exception)
                    {

                  
                    }
                }

            }
            lb_processes.ItemsSource = info;//proc.Select(a=>a.ProcessName);
        }

        private void Btn_Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.ShowDialog();
            tb_openFile.Text = openFile.FileName;
        }
    }
}
