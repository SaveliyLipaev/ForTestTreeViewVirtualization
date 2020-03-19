using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TreeViewVirtualization.Annotations;

namespace TreeViewVirtualization
{
  class TreeNode : ITreeNode, INotifyPropertyChanged
  {
    public string Key { get; set; }
    public TreeNode Parent { get; set; }
    public int Id { get; set; }

    public TreeNode(string key, TreeNode parent, int id)
    {
      Key = key;
      Parent = parent;
      Id = id;
      Children = new ObservableCollection<ITreeNode>();
    }

    private bool _isExpanded;
    public bool IsExpanded
    {
      get
      {
        return _isExpanded;
      }
      set
      {
        if (_isExpanded != value)
        {
          _isExpanded = value;
          OnPropertyChanged();
        }

        if (_isExpanded && Parent != null)
        {
          Parent.IsExpanded = true;
        }
      }
    }

    private ObservableCollection<ITreeNode> _children;
    public ObservableCollection<ITreeNode> Children
    {
      get
      {
        return _children;
      }
      set
      {
        _children = value;
        OnPropertyChanged();
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
