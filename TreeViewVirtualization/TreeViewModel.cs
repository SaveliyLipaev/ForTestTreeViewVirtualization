using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TreeViewVirtualization.Annotations;

namespace TreeViewVirtualization
{
  class TreeViewModel : INotifyPropertyChanged
  {
    private TreeNode _rootNode = new TreeNode("ROOT", null, 0);

    private ObservableCollection<TreeNode> _treeNodes = new ObservableCollection<TreeNode>();
    public ObservableCollection<TreeNode> TreeNodes
    {
      get
      {
        return _treeNodes;
      }
      set
      {
        if (_treeNodes != value)
        {
          _treeNodes = value;
          OnPropertyChanged();
        }
      }
    }

    private TreeNode _mySelectedItem;
    public TreeNode MySelectedItem
    {
      get
      {
        return _mySelectedItem;
      }
      set
      {
        if (_mySelectedItem != value)
        {
          _mySelectedItem = value;
          OnPropertyChanged();
        }
      }
    }

    public TreeViewModel()
    {
      int id = 1;
      TreeNodes.Add(_rootNode);
      for (var i = 0; i < 2000; ++i)
      {
        _rootNode.Children.Add(new TreeNode(i.ToString(), _rootNode, ++id));
      }

      foreach (var child in _rootNode.Children)
      {
        for (var i = 0; i < 2000; ++i)
        {
          child.Children.Add(new TreeNode(i.ToString(), (TreeNode)child, ++id));
        }
      }

      _rootNode.IsExpanded = true;
    }

    public ICommand ClickCommand => new RelayCommand<object>(click);

    private void click(object obj)
    {
      ITreeNode selected = TreeNodes.FirstOrDefault()?.Children.FirstOrDefault(node => node.Id == 1500 && node.Parent != null && node.Children != null && node.Children.Any());
      selected = selected.Children[500];
      if (selected != null)
      {
        MySelectedItem = selected as TreeNode;
      }
    }


    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
