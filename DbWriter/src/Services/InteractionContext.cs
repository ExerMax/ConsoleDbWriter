using DbWriter.src.Interfaces;
using DbWriter.src.Scripts;
using DbWriter.src.Structs;

namespace DbWriter.src.Services
{
    public class InteractionContext
    {
        public readonly IXmlParser _xmlParser;
        public readonly IDbWriter _dbWriter;
        public Storage storage = new Storage();
        public InteractionScript Script { get; set; }
        public InteractionContext(IXmlParser parser, IDbWriter writer)
        {
            _xmlParser = parser;
            _dbWriter = writer;
        }
        public void Request() => Script.Interact(this);
        public void Write()
        {
            storage.SuccessfulWrited = _dbWriter.Write(storage.orders);
        }
    }
}
