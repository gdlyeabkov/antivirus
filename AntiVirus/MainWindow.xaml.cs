using System;
using System.Collections.Generic;
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

namespace AntiVirus
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
    }
}
