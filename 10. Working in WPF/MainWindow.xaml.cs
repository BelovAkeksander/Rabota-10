using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace YourNamespace
{
    public partial class MainWindow : Window
    {
        private int[,] resourceMap;
        private Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            GenerateResources();
        }

        private void GenerateResources()
        {
            int rows = 10; // Количество строк
            int columns = 10; // Количество столбцов
            resourceMap = new int[rows, columns];
            gridResources.Children.Clear(); // Очистка сетки перед добавлением новых меток

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    resourceMap[i, j] = random.Next(100); // Значения от 0 до 99
                    var label = new Label
                    {
                        Content = resourceMap[i, j],
                        Background = new SolidColorBrush(Color.FromRgb((byte)(resourceMap[i, j] * 2.55), 0, (byte)(255 - resourceMap[i, j] * 2.55))),
                        Margin = new Thickness(1),
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center
                    };
                    gridResources.Children.Add(label);
                }
            }
        }

        private void btnCheckResources_Click(object sender, RoutedEventArgs e)
        {
            int depth = 5; // Заданная глубина для проверки
            bool hasResources = false;

            for (int j = 0; j < resourceMap.GetLength(1); j++)
            {
                if (resourceMap[depth, j] > 50) // Порог значения ресурсов
                {
                    hasResources = true;
                    break;
                }
            }

            txtResult.Text = hasResources ? $"Ресурсы найдены на глубине {depth}" : $"Ресурсы на глубине {depth} не найдены";
        }
    }
}
