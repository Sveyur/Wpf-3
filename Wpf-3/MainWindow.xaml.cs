using Microsoft.Win32;
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

namespace Wpf_3
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
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             
            string fontName = ComboBox1.SelectedItem.ToString();
            if (textBox != null)
            {
                textBox.FontFamily = new FontFamily(fontName);
            }
        }
        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            string fontName2 = ComboBox2.SelectedItem.ToString();
            if (textBox != null)
            {
                textBox.FontSize = double.Parse(fontName2);
            }
        }
        private void Button1_Clic(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                if (textBox.FontWeight == FontWeights.Normal)
                    textBox.FontWeight = FontWeights.Bold;
                else
                    textBox.FontWeight = FontWeights.Normal;
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                if (textBox.FontStyle == FontStyles.Normal)
                    textBox.FontStyle = FontStyles.Italic;
                else
                    textBox.FontStyle = FontStyles.Normal;
            }
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                if (textBox.TextDecorations == null)
                    textBox.TextDecorations = TextDecorations.Underline;
                else
                    textBox.TextDecorations = null;
            }
        }       

        private void RadioButton1_Click_1(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Black;

            }
        }

        private void RadioButton2_Click(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Red;

            }
        }        

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt| Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }       

        private void CommandBinding_Executed_2(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt| Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
            }
        }       

         private void CommandBinding_Executed_1(object sender, ExecutedRoutedEventArgs e)
         {
             Application.Current.Shutdown();
         }

       
    }
}
