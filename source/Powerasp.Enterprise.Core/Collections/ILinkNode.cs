namespace Powerasp.Enterprise.Core.Collections
{
    public interface ILinkNode
    {
        ILinkNode Next { get; set; }

        object Value { get; set; }
    }
}