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
using System;
using System.Runtime.InteropServices;
using System.Diagnostics;


unsafe struct lib
{
    [DllImport("C:\\Users\\Matthew\\Desktop\\2022-2023\\CSCE_483\\wiifit_windows\\x64\\Debug\\dll1.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public extern static void stop_recording();
    [DllImport("C:\\Users\\Matthew\\Desktop\\2022-2023\\CSCE_483\\wiifit_windows\\x64\\Debug\\dll1.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public extern static void stop_replay();
    [DllImport("C:\\Users\\Matthew\\Desktop\\2022-2023\\CSCE_483\\wiifit_windows\\x64\\Debug\\dll1.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public extern static void run_render_thread();
    
    [DllImport("C:\\Users\\Matthew\\Desktop\\2022-2023\\CSCE_483\\wiifit_windows\\x64\\Debug\\dll1.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public extern static void start_recording([In, Out, MarshalAs(UnmanagedType.LPStr)] string s);
    [DllImport("C:\\Users\\Matthew\\Desktop\\2022-2023\\CSCE_483\\wiifit_windows\\x64\\Debug\\dll1.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]

    public extern static void start_replay([In, Out, MarshalAs(UnmanagedType.LPStr)] string s);

    //------------
    //[DllImport("lib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    //public extern static void m_memcpy(void* dst, void* src, int n);
    // public extern static [In,Out,MarshalAs(UnmanagedType.LPStr)]string m_gets();

}

namespace wpf_gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///
    
    public partial class MainWindow : Window
    {
        string read_from = null;
        string write_to = null; 
        public MainWindow()
        {
            lib.run_render_thread();
            InitializeComponent();
        }

        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            workoutWindow sample = new workoutWindow();
            sample.Show();
        }

        private void WarmupClicked(object sender, RoutedEventArgs e)
        {
            lib.start_replay("C:\\csce483\\wpf_gui\\wpf_gui\\recordings\\Warmup.txt");
        }


        private void SquatClicked(object sender, RoutedEventArgs e)
        {
            lib.start_replay("C:\\csce483\\wpf_gui\\wpf_gui\\recordings\\Squats.txt");
        }

        private void ShoulderClicked(object sender, RoutedEventArgs e)
        {
            lib.start_replay("C:\\csce483\\wpf_gui\\wpf_gui\\recordings\\shoulderPress.txt");
        }

        private void LegClicked(object sender, RoutedEventArgs e)
        {
            lib.start_replay("C:\\csce483\\wpf_gui\\wpf_gui\\recordings\\LegRaises.txt");
        }

        private void LateralClicked(object sender, RoutedEventArgs e)
        {
            lib.start_replay("C:\\csce483\\wpf_gui\\wpf_gui\\recordings\\LateralRaises.txt");
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
                //MessageBox.Show(filename);
                write_to = filename;
            }
        }
        private void RecordClicked(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("RecordClicked");
            lib.start_recording(write_to);
        }

        private void StopRClicked(object sender, RoutedEventArgs e)
        {
            lib.stop_recording();
        }

        private void PlayClicked(object sender, RoutedEventArgs e)
        {
            lib.start_replay(read_from);   
        }

        private void StopPClicked(object sender, RoutedEventArgs e)
        {
            lib.stop_replay();
        }

        private void BrowseClicked(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new OpenFileDialog();

            bool? response = openFileDialog.ShowDialog();

            if(response == true)
            {
                string filepath = openFileDialog.FileName;
                //MessageBox.Show(filepath);
                read_from = filepath;
            }
        }

        private void PlaybackSpeed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int val = Convert.ToInt32(e.NewValue);
            string msg = String.Format("Current value: {0}", val);
            this.textBlock1.Text = msg;
        }

    }
}
