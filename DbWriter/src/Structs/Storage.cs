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

        public void Refresh()
        {
            orders = new List<XOrder>();
            SuccessfulWrited = 0;
            SuccessfulReaded = 0;
            FilePath = "";
        }
    }
}
