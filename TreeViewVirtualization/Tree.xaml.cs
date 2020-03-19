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

namespace TreeViewVirtualization
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class Tree : Window
  {
    public Tree()
    {
      InitializeComponent();
      DataContext = new TreeViewModel();
    }

    private void EventSetter_OnHandler(object sender, RoutedEventArgs e)
    {
      // ignore checking, assume original source is treeviewitem
      var treeViewItem = (TreeViewItem)e.OriginalSource;
      if ((treeViewItem.DataContext as ITreeNode).Id == 0)
      {
        return;
      }
      var count = VisualTreeHelper.GetChildrenCount(treeViewItem);

      for (int i = count - 1; i >= 0; --i)
      {
        var childItem = VisualTreeHelper.GetChild(treeViewItem, i);
        ((FrameworkElement)childItem).BringIntoView();
      }

      // do NOT call BringIntoView on the actual treeviewitem - this negates everything
      //treeViewItem.BringIntoView(); }; }
    }
  }
}
