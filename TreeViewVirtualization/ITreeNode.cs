using System.Collections.ObjectModel;

namespace TreeViewVirtualization
{
  interface ITreeNode
  {
    ObservableCollection<ITreeNode> Children { get; set; }
    string Key { get; set; }
  }
}
