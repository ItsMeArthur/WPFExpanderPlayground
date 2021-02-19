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

namespace WPFExpanderPlayground
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isGridSizeInit = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void FirstExpanderChanged(object sender, RoutedEventArgs e)
        {
            if (!FirstExpander.IsExpanded && !SecondExpander.IsExpanded)
            {
                FirstExpander.IsExpanded = true;
            }

            RedefineBoundaries();
        }

        private void SecondExpanderChanged(object sender, RoutedEventArgs e)
        {
            if (!FirstExpander.IsExpanded && !SecondExpander.IsExpanded)
            {
                SecondExpander.IsExpanded = true;
            }

            RedefineBoundaries();
        }

        private void GridSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (!isGridSizeInit && RootGrid.RowDefinitions[1].ActualHeight > 0)
            {
                isGridSizeInit = true;
                FirstExpander.IsExpanded = true;
                SecondExpander.IsExpanded = true;
            }

            RedefineBoundaries();
        }

        /// <summary>
        /// Redefine the max boundaries of each expander in relation to the container (RootGrid).
        /// </summary>
        private void RedefineBoundaries()
        {
            var expandersArea = RootGrid.RowDefinitions[1].ActualHeight;

            if (expandersArea > 0)
            {
                FirstExpander.MaxHeight = !SecondExpander.IsExpanded ? expandersArea - SecondExpander.MinHeight : (0.6) * expandersArea;
                SecondExpander.MaxHeight = !FirstExpander.IsExpanded ? expandersArea - FirstExpander.MinHeight : (0.4) * expandersArea;
            }
        }
    }
}
