using DbWriter.src.DTO;

namespace DbWriter.src.Interfaces
{
    public interface IXmlParser
    {
        public IEnumerable<XOrder> Read(string pathFile);
    }
}
