using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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



    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
