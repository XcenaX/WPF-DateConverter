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

namespace DateConverter
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		double unixTime;
		DateTime convertedDate;

		public MainWindow()
		{
			InitializeComponent();

			
		}



		private void ConvertButtonClick(object sender, RoutedEventArgs e)
		{
			string buffer = toConvert.Text ;

				try
				{
					fromConvert.Text = "";
					var convertedDate = Convert.ToDateTime(buffer);
					fromConvert.Text = convertedDate.ToString();
				}
				catch (FormatException)
				{
					fromConvert.Text = "Не вверный формат ввода!!!";
				}
		}

		public static DateTime SecondsToDateTime(double seconds)
		{
			// Unix timestamp is seconds past epoch
			System.DateTime convertDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
			convertDate = convertDate.AddSeconds(seconds).ToLocalTime();
			return convertDate;
		}


		private void toConvertGotFocus(object sender, RoutedEventArgs e)
		{
			if (toConvert.Text == "Введите время в ДД.ММ.ГГГГ")
			{
				toConvert.Text = "";
			}
			else if(toConvert.Text == "")
			{
				toConvert.Text = "Введите время в ДД.ММ.ГГГГ";
			}
		}

		private void FromConvertButtonClick(object sender, RoutedEventArgs e)
		{
			fromConvert.Text = "";
			string date = toConvert.Text;

			var parsedDate = date.Split('.', ' ');
			if (parsedDate.Count() < 3)
			{
				fromConvert.Text = "Не вверный формат ввода!!!";
			}
			else
			{
				fromConvert.Text = "";
				fromConvert.Text = parsedDate[0] + " " + parsedDate[1] + " " + parsedDate[2];
			}
		}

		private void FromSecondsButtonClick(object sender, RoutedEventArgs e)
		{
			double seconds;
			bool isPars=double.TryParse(toConvert.Text,out seconds);
			if (isPars == true)
			{
				DateTime dateBuffer=SecondsToDateTime(seconds);
				fromConvert.Text = dateBuffer.ToString();
			}
			else
			{
				fromConvert.Text = "Не вверный формат ввода!!!";
			}
		}
	}
}

