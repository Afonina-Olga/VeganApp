using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace VeganGO.Controls
{
    public partial class Menu : UserControl
    {
        private Button _activeButton;
        private static readonly SolidColorBrush ActiveMenuBrush = 
            new SolidColorBrush(Color.FromRgb(241, 232, 248));

        public Menu()
        {
            InitializeComponent();
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;

            var index = button.Name switch
            {
                "AboutMenuButton" => 0,
                "RecipesMenuButton" => 1,
                "ArticlesMenuButton" => 2,
                "UtilitiesMenuButton" => 3,
                _ => 0
            };

            MoveCursorMenu(index);
        }

        private void MoveCursorMenu(int index)
        {
            TrainsitionigContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, 58 * index + 1, 0, 0);
        }

        private void MenuButton_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Application.Current.MainWindow == null)
                return;

            var button = (ToggleButton)Application.Current.MainWindow.FindName("MenuToggleButton");

            if (button is { IsChecked: false })
            {
                AboutTooltip.Visibility = Visibility.Visible;
                ArticlesTooltip.Visibility = Visibility.Visible;
                RecipesTooltip.Visibility = Visibility.Visible;
                UtilitiesTooltip.Visibility = Visibility.Visible;
            }
            else
            {
                AboutTooltip.Visibility = Visibility.Collapsed;
                ArticlesTooltip.Visibility = Visibility.Collapsed;
                RecipesTooltip.Visibility = Visibility.Collapsed;
                UtilitiesTooltip.Visibility = Visibility.Collapsed;
            }
        }
    }
}