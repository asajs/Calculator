using System.Windows;

namespace Calculator
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

		private void Compute_Click(object sender, RoutedEventArgs e)
		{
			Output.Text = Math.PerformMath.DoMath(Input.Text);
		}
	}
}
