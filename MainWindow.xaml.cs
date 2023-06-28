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
using static System.Net.Mime.MediaTypeNames;

namespace Cash
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string path = "C:\\Windows\\Temp";
        static int deletedFiles = 0;
        static int count = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Clean(object sender, EventArgs e)
        {
            ImageInformation.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Success.png"));

            Status.Text = "Очистка завершена!";

            System.IO.DirectoryInfo tempCatalog = new DirectoryInfo(path);

            foreach (FileInfo file in tempCatalog.GetFiles())
            {
                try
                {
                    file.Delete();
                    deletedFiles++;
                }
                catch { }
            }

            MessageBox.Show($"Удалено {deletedFiles} файлов!");
            deletedFiles = 0;

            foreach (DirectoryInfo dir in tempCatalog.GetDirectories())
            {
                try
                {
                    dir.Delete(true);
                    deletedFiles++;
                }
                catch { }
            }

            MessageBox.Show($"Удалено {deletedFiles} папок!");
            deletedFiles++;
        }

        private void Scan(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo tempCatalog = new DirectoryInfo(path);

            foreach (DirectoryInfo dir in tempCatalog.GetDirectories())
                count++;

            foreach (FileInfo file in tempCatalog.GetFiles())
                count++;

            if (count != 0)
            {
                ImageInformation.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Warning.png"));
                Status.Text = $"Обнаружено {count} файлов!";
            }
            else
            {
                ImageInformation.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Success.png"));
                Status.Text = $"Все чисто!";
            }
        }
    }
}
