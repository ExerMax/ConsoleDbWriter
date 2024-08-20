using DbWriter.src.Scripts;
using DbWriter.src.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbWriter.src.Interfaces
{
    public interface IInteractionContext
    {
        public IXmlParser XmlParser { get; }
        public IDbWriter DbWriter { get; }
        public Storage Storage { get; set; }
        public InteractionScript Script { get; set; }
        public void Request();
        public void Write();
    }
}
