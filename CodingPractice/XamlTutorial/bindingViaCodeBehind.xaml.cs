using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace XamlTutorial
{
	/// <summary>
	/// Interaction logic for bindingViaCodeBehind.xaml
	/// </summary>
	public partial class bindingViaCodeBehind : Window
	{
		public bindingViaCodeBehind()
		{
			InitializeComponent();

			Binding binding = new Binding("Text");
			binding.Source = "txtValue";
			lblValue.SetBinding(TextBlock.TextProperty, binding );
		}
	}
}
