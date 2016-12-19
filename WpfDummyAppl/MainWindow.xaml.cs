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

namespace WpfDummyAppl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Car[] carArray;
        public MainWindow()
        {
            InitializeComponent();
            carArray = new[] {
            new Car { Brand = "Toyota", Model = "Tacoma", Color = "White", Cost = "20000.00" },
            new Car { Brand = "Toyota", Model = "Corolla", Color = "Grey", Cost = "150000.00" },
            new Car { Brand = "Toyota", Model = "Camry", Color = "Red", Cost = "25000.00" },
            new Car { Brand = "Ford", Model = "Fusion", Color = "White", Cost = "20000.00" }
            };
        }
    
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = comboBox.SelectedItem as ComboBoxItem;
            
            textBox.Text = item.Content.ToString();
            
            
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = "Writing to ListBox";
            listBox.Items.Add(textBox.Text);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            clearGrid();

            var col1 = new DataGridTextColumn { Header = "Brand" };
            var col2 = new DataGridTextColumn { Header = "Model" };
            var col3 = new DataGridTextColumn { Header = "Color" };
            var col4 = new DataGridTextColumn { Header = "Cost" };
            col1.Binding = new Binding("Brand");
            col2.Binding = new Binding("Model");
            col3.Binding = new Binding("Color");
            col4.Binding = new Binding("Cost");
            dataGrid.Columns.Add(col1);
            dataGrid.Columns.Add(col2);
            dataGrid.Columns.Add(col3);
            dataGrid.Columns.Add(col4);
            
            dataGrid.ItemsSource = carArray;
        }
        
        public void clearGrid()
        {
            dataGrid.ItemsSource = null;
            dataGrid.Columns.Clear();
            dataGrid.Items.Clear();
            dataGrid.Items.Refresh();
            textBox.Text = string.Empty;
            comboBox.SelectedIndex = -1;
            comboBox.Items.Refresh();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            clearGrid();
        }

        private void btnTreeView_Click(object sender, RoutedEventArgs e)
        {
            //TreeViewItem item = new TreeViewItem();
            //item.Header = "Computer";
            //item.ItemsSource = new string[] { "Monitor", "CPU", "Mouse" };

            //// ... Create a second TreeViewItem.
            //TreeViewItem item2 = new TreeViewItem();
            //item2.Header = "Outfit";
            //item2.ItemsSource = new string[] { "Pants", "Shirt", "Hat", "Socks" };

            //// ...  add both items.
            //treeView.Items.Add(item);
            //treeView.Items.Add(item2);
        }
        private void TreeView_Loaded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = new TreeViewItem();
            item.Header = "Computer";
            TreeViewItem subitem1 = new TreeViewItem();
            TreeViewItem subitem2 = new TreeViewItem();
            subitem1.Header = "Notebooks";
            subitem2.Header = "Desktops";
            subitem1.ItemsSource = new string[] { "Monitor", "CPU", "Mouse" };
            subitem2.ItemsSource = new string[] { "Monitor", "CPU", "Mouse" };

            item.Items.Add(subitem1);
            item.Items.Add(subitem2);



            // ... Create a second TreeViewItem.
            TreeViewItem item2 = new TreeViewItem();
            item2.Header = "Outfit";
            item2.ItemsSource = new string[] { "Pants", "Shirt", "Hat", "Socks" };

            // ...  add both items.
            treeView.Items.Add(item);
            treeView.Items.Add(item2);
        }

    }
    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Cost { get; set; }
    }
}
