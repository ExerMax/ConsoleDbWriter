using DbWriter.src.DTO;

namespace DbWriter.src.Interfaces
{
    public interface IDbWriter
    {
        public int Write(IEnumerable<XOrder> orders);
    }
}
