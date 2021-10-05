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
using System.IO;
using Microsoft.Win32;
using LibMas;
using Lib_11;

namespace Пр_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int[] mas;
        private void Создать_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(kolstolb.Text, out int Count) == true)
            {
                Class.sozdatMas(out mas, Count);
                DataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
            }
            else MessageBox.Show("Неверное значение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Заполнить_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(nDiapoz.Text, out int nachDiapoz) == true && Int32.TryParse(kDiapoz.Text, out int konDiapoz) == true && Int32.TryParse(kolstolb.Text, out int Count) == true)
            {
                Class.zapolnitMas(out mas, nachDiapoz, konDiapoz, Count);
                DataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
            }
            else MessageBox.Show("Неверное значение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Рассчитать_Click(object sender, RoutedEventArgs e)
        {
            if (mas != null)
            {
                Class1.Raschet(mas, out int raznitsa);
                raznica.Text = raznitsa.ToString();
            }
            else MessageBox.Show("Некорректные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Очистить_Click(object sender, RoutedEventArgs e)
        {
            if (mas != null)
            {
                Class.OchistMas(ref mas);
                DataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
            }
        }

        private void Сохранить_Click(object sender, RoutedEventArgs e)
        {
            Class.saveMas(mas);
        }

        private void Открыть_Click(object sender, RoutedEventArgs e)
        {

            Class.openMas(out mas);
            DataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа №2\nВыполнила студентка группы ИСП-31 Кочеткова В.\nЗадание:Ввести n целых чисел(>0 или <0). Найти разницу чисел. Результат вывести на экран", "Доп.Информация", MessageBoxButton.OK, MessageBoxImage.Question);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int indexColumn = e.Column.DisplayIndex;
            mas[indexColumn] = Convert.ToInt32(((TextBox)e.EditingElement).Text);
        }
    }
}
