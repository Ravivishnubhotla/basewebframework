namespace Powerasp.Enterprise.Core.Collections
{
    public interface ITreeNode
    {
        ITreeNode GetNode(int index);
        int IndexOf(ITreeNode node);
        void RemoveAll();

        int Degree { get; }

        int Depth { get; }

        ITreeNode FirstChild { get; }

        bool IsLeafe { get; }

        bool IsRoot { get; }

        ITreeNode this[int index] { get; }

        ITreeNode LastChild { get; }

        int Level { get; }

        ITreeNode NextSibling { get; }

        ITreeNode Parent { get; set; }

        ITreeNode PreviousSibling { get; }

        ITreeNode Root { get; }

        object Value { get; }
    }
}