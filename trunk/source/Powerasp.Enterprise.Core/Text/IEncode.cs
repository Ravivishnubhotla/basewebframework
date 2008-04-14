namespace Powerasp.Enterprise.Core.Text
{
    public interface IEncode
    {
        string Decode(string s);
        string Encode(string s);
    }
}