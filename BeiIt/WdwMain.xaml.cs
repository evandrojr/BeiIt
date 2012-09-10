using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace BeiIt
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class WdwMain : Window
    {
        bool loaded = false;

        public WdwMain()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                TextRange range;
                FileStream fStream;
                fStream = new FileStream(@"beiit.Xaml", FileMode.Open);
                range = new TextRange(RichTxt.Document.ContentStart, RichTxt.Document.ContentEnd);
                range.Load(fStream, DataFormats.Xaml);
                fStream.Close();
            }
            catch { }
            finally
            {
                loaded = true;
                RichTxt.SpellCheck.IsEnabled = true;
                Top = 30;
                Left = System.Windows.SystemParameters.PrimaryScreenWidth - Width;
            }
        }

        private void RichTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!loaded)
                return;
            TextRange range;
            FileStream fStream;
            range = new TextRange(RichTxt.Document.ContentStart, RichTxt.Document.ContentEnd);
            fStream = new FileStream(@"beiit.Xaml", FileMode.Create);
            range.Save(fStream, DataFormats.Xaml);
            fStream.Close();
        }
    }
}
