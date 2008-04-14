using Powerasp.Enterprise.Core.Collections;

namespace Powerasp.Enterprise.Core.Collections
{
    public interface ITree
    {
        ITreeNode[] Find(object obj, TreeTraversal traversal);
        ITreeNode[] Traversal(TreeTraversal traversal);

        ITreeNode Root { get; }
    }
}