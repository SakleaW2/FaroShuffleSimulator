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
using System.Windows.Shapes;

namespace FaroShuffleSimulator
{
    public partial class MainWindow : Window
    {
        private CardManager manager;
        public MainWindow()
        {
            InitializeComponent();
            manager = new CardManager();
            UpdateList();
        }
        private void UpdateList(IEnumerable<Card>? cards = null)
        {
            CardListBox.ItemsSource = cards ?? manager.CurrentCards;
        }

        private void Shuffle_Click(object sender, RoutedEventArgs e)
        {
            manager.Shuffle();
            UpdateList();
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            manager.SortByName();
            UpdateList();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            manager.Reset();
            UpdateList();
        }

        private void ShowAll_Click(object sender, RoutedEventArgs e)
        {
            UpdateList();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var query = SearchBox.Text.Trim();
            if (!string.IsNullOrEmpty(query))
            {
                var results = manager.SearchByName(query);
                UpdateList(results);
            }
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
