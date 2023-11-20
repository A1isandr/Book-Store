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

namespace Book_Store
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

		private void Header_MouseDown(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void CloseWindowButton_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void MaxWindowButton_Click(object sender, RoutedEventArgs e)
		{
			WindowState = (WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized);
		}

		private void MinWindowButton_Click(object sender, RoutedEventArgs e)
		{
			WindowState = WindowState.Minimized;
		}

		private void MinMaxMenuButton_Click(object sender, RoutedEventArgs e)
		{
			StoreMenu.Visibility = Visibility.Collapsed;
			Main.ColumnDefinitions[1].Width = new GridLength(Width, GridUnitType.Pixel);
			/*if (StoreMenu.Width != 0)
			{
				StoreMenu.Width = 0;
			}
			else
			{
				StoreMenu.Width = Width / 4;
			}*/
		}
	}
}
