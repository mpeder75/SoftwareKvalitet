using Session_2_Lommeregner.Core;
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

namespace Session_2_Lommeregner;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly CalculatorEngine _engine;

    // Constructor Injection - CalculatorEngine injiceres
    public MainWindow(CalculatorEngine engine)
    {
        InitializeComponent();
        _engine = engine;
        UpdateDisplay();
    }

    private void Number_Click(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        _engine.EnterNumber(button.Content.ToString());
        UpdateDisplay();
    }

    private void Operator_Click(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        _engine.SetOperator(button.Content.ToString());
    }

    private void Equals_Click(object sender, RoutedEventArgs e)
    {
        _engine.Calculate();
        UpdateDisplay();
    }

    private void Clear_Click(object sender, RoutedEventArgs e)
    {
        _engine.Clear();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        DisplayText.Text = _engine.Display;
    }
}