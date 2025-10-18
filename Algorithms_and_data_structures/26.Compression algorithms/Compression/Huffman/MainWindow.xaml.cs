using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Microsoft.Win32;

namespace Compression
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            comboBox.Items.Add("Huffman algorithm");
            comboBox.Items.Add("RLE");

            comboBox.SelectedIndex = 0;
        }

        Huffman huffman = new();
        RLE rle = new();

        private void CompressBtn_Click(object sender, RoutedEventArgs e)
        {
            string source="";
            string destination="";

            var openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true && openFileDialog.FileName != string.Empty)
            {
                source = openFileDialog.FileName;
            }

            var saveFileDialog = new SaveFileDialog();

            if (comboBox.SelectedIndex == 0)
            {
                saveFileDialog.Filter = "Huffman compression file|*.huffman";
            }
            else
            {
                saveFileDialog.Filter = "RLE compression file|*.rle";
            }

            if (saveFileDialog.ShowDialog() == true && saveFileDialog.FileName != string.Empty)
            {
                destination = saveFileDialog.FileName;
            }

            var watch = new Stopwatch();
            watch.Start();

            if (comboBox.SelectedIndex == 0)
            {
                huffman.CompressInFile(source, destination);
            }
            else
            {
                rle.CompressInFile(source, destination);
            }
            
            watch.Stop();
            MessageBox.Show(watch.ElapsedMilliseconds.ToString());
        }

        private void DecompressBtn_Click(object sender, RoutedEventArgs e)
        {
            string source = "";
            string destination = "";

            var openFileDialog = new OpenFileDialog();

            if (comboBox.SelectedIndex == 0)
            {
                openFileDialog.Filter = "Huffman compression file|*.huffman";
            }
            else
            {
                openFileDialog.Filter = "RLE compression file|*.rle";
            }

            if (openFileDialog.ShowDialog() == true && openFileDialog.FileName != string.Empty)
            {
                source = openFileDialog.FileName;
            }

            var saveFileDialog = new SaveFileDialog();


            if (saveFileDialog.ShowDialog() == true && saveFileDialog.FileName != string.Empty)
            {
                destination = saveFileDialog.FileName;
            }

            var watch = new Stopwatch();
            watch.Start();

            if (comboBox.SelectedIndex == 0)
            {
                huffman.DecompressFromFile(source, destination);
            }
            else
            {
                rle.DecompressFromFile(source, destination);
            }

            watch.Stop();
            MessageBox.Show(watch.ElapsedMilliseconds.ToString());
        }

        private void ComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
