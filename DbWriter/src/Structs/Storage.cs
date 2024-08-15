using DbWriter.src.DTO;

namespace DbWriter.src.Structs
{
    public struct Storage
    {
        public string FilePath { get; set; } = "";
        public int SuccessfulReaded = 0;
        public int SuccessfulWrited = 0;
        public IEnumerable<XOrder> orders;

        public Storage() { }
    }
}
