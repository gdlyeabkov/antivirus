using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Speech.Synthesis;
using System.IO;

namespace AntiVirus
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public BackgroundWorker worker;
        public SpeechSynthesizer debugger;

        public MainWindow()
        {
            InitializeComponent();

            debugger = new SpeechSynthesizer();

            worker = new BackgroundWorker();
            worker.DoWork += delegate
            {
                SearchViruses();
            };

        }

        private void SelectTabHandler(object sender, MouseButtonEventArgs e)
        {
            Border currentTab = ((Border)(sender));
            TextBlock currentTabLabel = ((TextBlock)(currentTab.Child));
            foreach (Border tab in tabs.Children)
            {
                tab.BorderThickness = new Thickness(0, 0, 0, 0);
            }
            currentTab.BorderThickness = new Thickness(0, 0, 0, 5);

            asideTabs.SelectedIndex = ((StackPanel)(currentTab.Parent)).Children.IndexOf(currentTab);

            capabilities.SelectedIndex = ((StackPanel)(currentTab.Parent)).Children.IndexOf(currentTab);

        }

        private void GetSecurityReport(object sender, MouseButtonEventArgs e)
        {
            TextBlock toggler = ((TextBlock)(sender));
            string tabParam = toggler.DataContext.ToString();
            int tabNumber = Int32.Parse(tabParam);
            breadcrumb.Text = tabParam + "/2";
            toggler.Foreground = System.Windows.Media.Brushes.Gray;
            TextBlock otherToggler = null;
            notifications.Children.RemoveAt(1);
            if (tabNumber == 1)
            {
                otherToggler = ((TextBlock)(breadcrumbs.Children[breadcrumbs.Children.IndexOf(toggler) + 2]));
                StackPanel tabBody = new StackPanel();
                tabBody.Width = 500;
                tabBody.Margin = new Thickness(15, 15, 15, 15);
                tabBody.Orientation = Orientation.Horizontal;
                TextBlock tabBodyIcon = new TextBlock();
                tabBodyIcon.Margin = new Thickness(0, 0, 50, 0);
                tabBodyIcon.Text = "⚠";
                tabBodyIcon.FontSize = 36;
                tabBody.Children.Add(tabBodyIcon);
                StackPanel tabBodyAside = new StackPanel();
                TextBlock tabBodyAsideCountThreatsLabel = new TextBlock();
                tabBodyAsideCountThreatsLabel.Text = "4";
                tabBodyAsideCountThreatsLabel.FontSize = 18;
                tabBodyAsideCountThreatsLabel.Foreground = System.Windows.Media.Brushes.Gray;
                tabBodyAsideCountThreatsLabel.Margin = new Thickness(0, 0, 0, 15);
                tabBodyAside.Children.Add(tabBodyAsideCountThreatsLabel);
                TextBlock tabBodyAsideThreatLabel = new TextBlock();
                tabBodyAsideThreatLabel.Text = "Небезопасные веб-сайты заблокированы";
                tabBodyAsideThreatLabel.FontSize = 18;
                tabBodyAsideThreatLabel.Foreground = System.Windows.Media.Brushes.Gray;
                tabBodyAside.Children.Add(tabBodyAsideThreatLabel);
                tabBody.Children.Add(tabBodyAside);
                notifications.Children.Add(tabBody);
            }
            else if (tabNumber == 2)
            {
                otherToggler = ((TextBlock)(breadcrumbs.Children[breadcrumbs.Children.IndexOf(toggler) - 2]));
                StackPanel tabBody = new StackPanel();
                tabBody.Width = 500;
                tabBody.Margin = new Thickness(15, 15, 15, 15);
                tabBody.Orientation = Orientation.Horizontal;
                TextBlock tabBodyIcon = new TextBlock();
                tabBodyIcon.Margin = new Thickness(0, 0, 50, 0);
                tabBodyIcon.Text = "🔍";
                tabBodyIcon.FontSize = 36;
                tabBody.Children.Add(tabBodyIcon);
                StackPanel tabBodyAside = new StackPanel();
                TextBlock tabBodyAsideCountThreatsLabel = new TextBlock();
                tabBodyAsideCountThreatsLabel.Text = "26.11.2021";
                tabBodyAsideCountThreatsLabel.FontSize = 18;
                tabBodyAsideCountThreatsLabel.Foreground = System.Windows.Media.Brushes.Gray;
                tabBodyAsideCountThreatsLabel.Margin = new Thickness(0, 0, 0, 15);
                tabBodyAside.Children.Add(tabBodyAsideCountThreatsLabel);
                TextBlock tabBodyAsideThreatLabel = new TextBlock();
                tabBodyAsideThreatLabel.Text = "Последняя проверка";
                tabBodyAsideThreatLabel.FontSize = 18;
                tabBodyAsideThreatLabel.Foreground = System.Windows.Media.Brushes.Gray;
                tabBodyAside.Children.Add(tabBodyAsideThreatLabel);
                tabBody.Children.Add(tabBodyAside);
                notifications.Children.Add(tabBody);
            }
            otherToggler.Foreground = System.Windows.Media.Brushes.Blue;
        }

        private void ActivateTabHandler(object sender, MouseButtonEventArgs e)
        {
            TextBlock tabLabel = ((TextBlock)(sender));
            string tabLabelParam = tabLabel.DataContext.ToString();
            int tabLabelNumber = Int32.Parse(tabLabelParam);
            tabsToggler.SelectedIndex = tabLabelNumber - 1;
            if (tabLabelNumber == 1)
            {
                ((TextBlock)(tabsLabels.Children[0])).Foreground = System.Windows.Media.Brushes.Blue;
                ((TextBlock)(tabsLabels.Children[1])).Foreground = System.Windows.Media.Brushes.Gray;
            }
            else if (tabLabelNumber == 2)
            {
                ((TextBlock)(tabsLabels.Children[0])).Foreground = System.Windows.Media.Brushes.Gray;
                ((TextBlock)(tabsLabels.Children[1])).Foreground = System.Windows.Media.Brushes.Blue;
            }
        }

        private void ToggleTabHandler(object sender, MouseButtonEventArgs e)
        {
            StackPanel arrowLabel = ((StackPanel)(sender));
            string arrowLabelParam = arrowLabel.DataContext.ToString();
            int arrowLabelNumber = Int32.Parse(arrowLabelParam);
            if (arrowLabelNumber == 1)
            {
                ((StackPanel)(arrowLabel.Parent)).Children[0].Visibility = Visibility.Hidden;
                ((StackPanel)(arrowLabel.Parent)).Children[2].Visibility = Visibility.Visible;

                tabsToggler.SelectedIndex = 0;
                ((TextBlock)(tabsLabels.Children[0])).Foreground = System.Windows.Media.Brushes.Blue;
                ((TextBlock)(tabsLabels.Children[1])).Foreground = System.Windows.Media.Brushes.Gray;

            }
            else if (arrowLabelNumber == 2)
            {
                ((StackPanel)(arrowLabel.Parent)).Children[0].Visibility = Visibility.Visible;
                ((StackPanel)(arrowLabel.Parent)).Children[2].Visibility = Visibility.Hidden;

                tabsToggler.SelectedIndex = 1;
                ((TextBlock)(tabsLabels.Children[0])).Foreground = System.Windows.Media.Brushes.Gray;
                ((TextBlock)(tabsLabels.Children[1])).Foreground = System.Windows.Media.Brushes.Blue;

            }
        }

        private void CloseProgrammHandler(object sender, MouseButtonEventArgs e)
        {
            worker.RunWorkerAsync();
            /*debugger.Speak("закрываюсь пора искать");*/
            this.Close();
        }

        private void ToggleProgrammHandler(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
        }

        private void HoverHeaderIconHandler(object sender, MouseEventArgs e)
        {
            TextBlock headerIcon = ((TextBlock)(sender));
            headerIcon.Foreground = Brushes.Black;
        }

        private void HoutHeaderIconHandler(object sender, MouseEventArgs e)
        {
            foreach (TextBlock headerIcon in headerIcons.Children)
            {
                headerIcon.Foreground = Brushes.Gray;
            }
        }

        private void GoToMyAccountHandler(object sender, MouseButtonEventArgs e)
        {
            Dialogs.AccountDetailsDialog dialog = new Dialogs.AccountDetailsDialog();
            dialog.Show();
        }

        private void GoToAboutHandler(object sender, MouseButtonEventArgs e)
        {
            Dialogs.AboutDialog dialog = new Dialogs.AboutDialog();
            dialog.Show();
        }

        private void GoToHelpHandler(object sender, MouseButtonEventArgs e)
        {
            Dialogs.HelpDialog dialog = new Dialogs.HelpDialog();
            dialog.Show();
        }

        private void GoToSecurityLogHandler(object sender, MouseButtonEventArgs e)
        {
            Dialogs.SecurityLog dialog = new Dialogs.SecurityLog();
            dialog.Show();
        }

        private void OpenPasswordsManagementHandler(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = @"https://www.truekey.com/promo/mcafee#?&lang=ru&lcid=1049&langid=79&culture=ru-RU&rcode=WSS16028&version=18.8&wuiv=12.0&build=18.8.126&affid=1357-57&resellerid=1&ContentIterationID=7.5.109&OCVersion=3.0&OCEnable=1&CommonBuild=1&GCB=1&pef=1&jeulaversion=eula_v2020h2&AWVersion=4.0&domain=ru.mcafee.com&ClientOSV=17&ocsku=1357-57-48951&EulaState=1&EulaDt=20211102&bsn=5CD130F0BW&hres=1920&vres=1080&coreui_enabled=1&coreui_version=1&EulaTrackingStatus=0&OldEulaDt=20211102&mcafeesku=1357-57-48951&entitlementdatetime=20211211173333&defaultSKUused=0&partnersku=1357-57-48951&stpcheck=1&LaunchPoint=34&pkgs=431_1357-57_ru-ru_1__20211202_23_2&hardware_id=0999790f11ff4315548670fbed59eb0e&windows_id=_{1193EF54-5197-45BD-85F5-E4E2D4AB4839}&os_country=RU&os_culture=ru&rtmui_lcid=1049&cui=be8cf5799c9246d6a8a411eb0f6c8302-503f8085e862&cdi=be8cf5799c9246d6a8a411eb0f6c8302-503f8085e862&sessionId=58E798DD-1F22-4EA4-86F3-EE0D12C53319&segid=&segtyid=&segmenttypeconfigid=&mc_installation_at=1635853090&installsrc=CLIENT:WSS,TP:TK-CoreUIShortCut",
                UseShellExecute = true
            });
        }

        private void OpenInternetProtectionHandler(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = @"https://www.mcafee.com/consumer/ru-ru/microsite/WA/how-it-works.html?lang=ru&lcid=1049&langid=79&culture=ru-RU&rcode=WSS16028&version=18.8&wuiv=12.0&build=18.8.126&affid=1357-57&resellerid=1&ContentIterationID=7.5.109&OCVersion=3.0&OCEnable=1&CommonBuild=1&GCB=1&pef=1&jeulaversion=eula_v2020h2&AWVersion=4.0&domain=ru.mcafee.com&ClientOSV=17&ocsku=1357-57-48951&EulaState=1&EulaDt=20211102&bsn=5CD130F0BW&hres=1920&vres=1080&coreui_enabled=1&coreui_version=1&EulaTrackingStatus=0&OldEulaDt=20211102&mcafeesku=1357-57-48951&entitlementdatetime=20211211173333&defaultSKUused=0&partnersku=1357-57-48951&stpcheck=1&LaunchPoint=34&pkgs=431_1357-57_ru-ru_1__20211202_23_2&hardware_id=79752d643f233370373f8fd9b4c4cdf75f4a4d55560b04436269422c55550579625b4b425b51545640376d1d2f035651&windows_id=d24e3caecaf3d7e1faeb65b2af4bd0243008455d58017163666c097f505f0361635a313041590772107e1d100f5322000d155b4b47551c&os_country=RU&os_culture=ru&rtmui_lcid=1049&cui=be8cf5799c9246d6a8a411eb0f6c8302-503f8085e862&cdi=be8cf5799c9246d6a8a411eb0f6c8302-503f8085e862&sessionId=86BFEBE6-AA13-4F60-9563-15370D7E1DDE&segid=&segtyid=&segmenttypeconfigid=",
                UseShellExecute = true
            });
        }

        private void DragWindowHandler(object sender, DragEventArgs e)
        {
            e.Handled = true;
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                this.Top = e.GetPosition(this).Y;
                this.Left = e.GetPosition(this).X;
            }
        }

        private void SearchVirusesHandler(object sender, EventArgs e)
        {
            /*worker.RunWorkerAsync();
            debugger.Speak("закрываюсь пора искать");*/
        }

        private void SearchViruses()
        {
            debugger.Speak("Ищу вирус и пишу в логи");
            string[] possibleViruses = Directory.GetFiles(@"C:\antivirus_logs");
            int threats = 0;
            foreach (string possibleViruse in possibleViruses)
            {
                string possibleVirusContent = File.ReadAllText(possibleViruse);
                bool isVirusFound = possibleVirusContent.ToLower().Contains("родион") || possibleVirusContent.ToLower().Contains("rodion");
                if (isVirusFound)
                {
                    string[] possibleVirusDetections = possibleVirusContent.Split(new Char[] { '\n', ' ' });
                    foreach (string possibleVirusDetection in possibleVirusDetections)
                    {
                        bool isVirusDetection = possibleVirusDetection.ToLower().Contains("родион") || possibleVirusDetection.ToLower().Contains("rodion");
                        if (isVirusDetection)
                        {
                            threats++;
                        }
                    }
                }
            }
            CreateSecurityLogHanler(threats);
        }

        private void CreateSecurityLogHanler(int threats = 0)
        {
            DateTime now = DateTime.Now;
            string parsedDate = now.Day.ToString() + "." + now.Month.ToString() + "." + now.Year.ToString() + "T" + now.Hour.ToString() + ":" + now.Minute.ToString() + ":" + now.Second;
            string logDataHeader = "Проверка файлов";
            int threatsCount = threats;
            string logDataDesc = "Обнаружено " + threatsCount.ToString() + " угроз";
            string logDataSeparator = "%";
            string logData = logDataHeader + logDataSeparator + logDataDesc;
            string log = logData + "@" + parsedDate;
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

    }
}
