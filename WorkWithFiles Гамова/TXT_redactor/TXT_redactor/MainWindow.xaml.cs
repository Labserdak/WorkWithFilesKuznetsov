using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Documents;

namespace TXT_redactor
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = filter;
            if (sfd.ShowDialog() == true)
            {
                TextRange doc = new TextRange(Text.Document.ContentStart, Text.Document.ContentEnd);
                using (FileStream fs = File.Create(sfd.FileName))
                {
                    if (Path.GetExtension(sfd.FileName).ToLower() == ".txt")
                        doc.Save(fs, DataFormats.Text);
                }
            }
        }
        private void Load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = filter;
            if (ofd.ShowDialog() == true)
            {
                TextRange doc = new TextRange(Text.Document.ContentStart, Text.Document.ContentEnd);
                using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                {
                    if (Path.GetExtension(ofd.FileName).ToLower() == ".txt")
                        doc.Load(fs, DataFormats.Text);
                }
            }
        }

        private void Text_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
