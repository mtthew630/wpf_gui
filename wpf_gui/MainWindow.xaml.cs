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
using Microsoft.Win32;
using System.IO;

namespace wpf_gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            workoutWindow sample = new workoutWindow();
            sample.Show();
        }

        private void WarmupClicked(object sender, RoutedEventArgs e)
        {

        }

        private void SelectClicked(object sender, RoutedEventArgs e)
        {
            // display filepath user wants to save recordings to
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "MyWorkout"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension
            string fileText = "My workout"; // Default file content
            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                File.WriteAllText(dlg.FileName, fileText);
                // Save document
                string filename = dlg.FileName;
                MessageBox.Show(filename);
            }
        }
        private void RecordClicked(object sender, RoutedEventArgs e)
        {
            
        }

        private void StopRClicked(object sender, RoutedEventArgs e)
        {

        }

        private void PlayClicked(object sender, RoutedEventArgs e)
        {
            
        }

        private void StopPClicked(object sender, RoutedEventArgs e)
        {

        }

        private void BrowseClicked(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new OpenFileDialog();

            bool? response = openFileDialog.ShowDialog();

            if(response == true)
            {
                string filepath = openFileDialog.FileName;
                MessageBox.Show(filepath);
            }
        }
    }
}
