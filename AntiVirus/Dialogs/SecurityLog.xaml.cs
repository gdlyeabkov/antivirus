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
using System.Windows.Shapes;

namespace AntiVirus.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для SecurityLog.xaml
    /// </summary>
    public partial class SecurityLog : Window
    {
        public SecurityLog()
        {
            InitializeComponent();

            // CreateSecurityLogHanler();

            GetLogsHandler();

        }

        private void CloseProgrammHandler(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void ToggleProgrammHandler(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
        }

        private void CancelHandler(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CreateSecurityLogHanler()
        {
            DateTime now = DateTime.Now;
            string parsedDate = now.Day.ToString() + "." + now.Month.ToString() + "." + now.Year.ToString() + "T" + now.Hour.ToString() + ":" + now.Minute.ToString() + ":" + now.Second;
            string logDataHeader = "Проверка файлов";
            int threatsCount = 0;
            string logDataDesc = "Обнаружено " + threatsCount.ToString() + " угроз";
            string logDataSeparator = "%";
            string logData = logDataHeader + logDataSeparator + logDataDesc;
            string log = logData + "@" + parsedDate;
            debug.Text = log;
            Stream myStream;
            bool isLogExists = File.ReadAllLines(@"C:\antivirus_logs\logs.txt").Length >= 1;
            if ((myStream = File.Open(@"C:\antivirus_logs\logs.txt", FileMode.Append)) != null)
            {
                using (StreamWriter sw = new StreamWriter(myStream))
                {
                    string separator = "";
                    if (isLogExists)
                    {
                        separator = "\n";
                    }
                    sw.Write(separator + log);
                }
            }
        }

        // private void GetLogsHandler(object sender, MouseEventArgs e)
        private void GetLogsHandler()
        {
            Stream myStream;
            if ((myStream = File.Open(@"C:\antivirus_logs\logs.txt", FileMode.Open)) != null)
            {

                myStream.Close();
                string file_text = File.ReadAllText(@"C:\antivirus_logs\logs.txt");
                string[] rawLogs = file_text.Split(new Char[] { '\n' });
                securityLogs.RowDefinitions.RemoveRange(1, 7);
                bool isDisplayLogs = rawLogs.ToList().TrueForAll((rawLog) => rawLog.Length >= 5);
                if (isDisplayLogs) {
                    foreach (string rawLog in rawLogs)
                    {
                        RowDefinition row = new RowDefinition();
                        row.Height = new GridLength(35);
                        securityLogs.RowDefinitions.Insert(securityLogs.RowDefinitions.Count - 1, row);
                        Border cellBorder = new Border();
                        cellBorder.BorderBrush = Brushes.Gray;
                        cellBorder.BorderThickness = new Thickness(1);
                        cellBorder.Background = Brushes.White;
                        Grid.SetRow(cellBorder, securityLogs.RowDefinitions.IndexOf(row));
                        Grid.SetColumn(cellBorder, 0);
                        StackPanel cell = new StackPanel();
                        cell.Orientation = Orientation.Horizontal;
                        cell.VerticalAlignment = VerticalAlignment.Center;
                        TextBlock cellDetails = new TextBlock();
                        cell.Children.Add(cellDetails);
                        StackPanel logInfo = new StackPanel();
                        TextBlock logDesc = new TextBlock();
                        string[] logMeta = rawLog.Split(new Char[] { '@' });
                        logDesc.Text = logMeta[0].Split(new Char[] { '%' })[0];
                        logInfo.Children.Add(logDesc);
                        logDesc = new TextBlock();
                        logDesc.Text = logMeta[0].Split(new Char[] { '%' })[1];
                        logInfo.Children.Add(logDesc);
                        cell.Children.Add(logInfo);
                        cellBorder.Child = cell;
                        securityLogs.Children.Add(cellBorder);
                        Border cellDateBorder = new Border();
                        cellDateBorder.Background = Brushes.White;
                        cellDateBorder.BorderThickness = new Thickness(1);
                        cellDateBorder.BorderBrush = Brushes.Gray;
                        Grid.SetRow(cellDateBorder, securityLogs.RowDefinitions.IndexOf(row));
                        Grid.SetColumn(cellDateBorder, 1);
                        StackPanel cellDate = new StackPanel();
                        cellDate.VerticalAlignment = VerticalAlignment.Center;
                        TextBlock cellDateItem = new TextBlock();
                        cellDateItem.Text = logMeta[1].Split(new Char[] { 'T' })[0];
                        cellDate.Children.Add(cellDateItem);
                        cellDateItem = new TextBlock();
                        cellDateItem.Text = logMeta[1].Split(new Char[] { 'T' })[1];
                        cellDate.Children.Add(cellDateItem);
                        cellDateBorder.Child = cellDate;
                        securityLogs.Children.Add(cellDateBorder);
                        /*logsDate
                        logsType*/
                    }
                }

            }
                
        }

    }
}
