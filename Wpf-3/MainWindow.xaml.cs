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
            List<string> styles = new List<string>() { "Светлая тема", "Темная тема" };
            ComboBox0.ItemsSource = styles;
            ComboBox0.SelectedIndex = 0;
            ComboBox0.SelectionChanged += ChangedTheme;
        }

        private void ChangedTheme(object sender, SelectionChangedEventArgs e)
        {
            int styleindex = ComboBox0.SelectedIndex;
            Uri uri = new Uri("Light.xaml", UriKind.Relative);
            if (styleindex==1)
            {
                uri = new Uri("Dark.xaml", UriKind.Relative);
            }
            ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource);

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
