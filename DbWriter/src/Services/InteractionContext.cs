using DbWriter.src.Interfaces;
using DbWriter.src.Scripts;
using DbWriter.src.Structs;

namespace DbWriter.src.Services
{
    public class InteractionContext
    {
        public readonly IXmlParser XmlParser;
        public readonly IDbWriter DbWriter;
        public Storage Storage;
        public InteractionScript Script { get; set; }
        public InteractionContext(IXmlParser parser, IDbWriter writer)
        {
            XmlParser = parser;
            DbWriter = writer;
            Storage = new Storage();
        }
        public void Request() => Script.Interact(this);
        public void Write()
        {
            Storage.SuccessfulWrited = DbWriter.Write(Storage.Orders);
        }
    }
}
