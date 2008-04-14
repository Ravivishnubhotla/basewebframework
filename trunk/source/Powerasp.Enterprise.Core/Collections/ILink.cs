using System.Collections;

namespace Powerasp.Enterprise.Core.Collections
{
    public interface ILink : IList, ICollection, IEnumerable
    {
        void AddRange(ICollection collection);
    }
}