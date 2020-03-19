using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TreeViewVirtualization
{
  interface ITreeNode
  {
    string Key { get; set; }
    TreeNode Parent { get; set; }
    int Id { get; set; }
    bool IsExpanded { get; set; }
    ObservableCollection<ITreeNode> Children { get; set; }
    event PropertyChangedEventHandler PropertyChanged;
  }
}
