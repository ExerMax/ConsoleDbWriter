using DbWriter.src.Interfaces;
using DbWriter.src.Scripts;

namespace DbWriter.src.Services
{
    public class Interactor : IInteractHandler
    {
        private readonly InteractionContext _context;

        public Interactor(InteractionContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            _context.Script = new FileRequestScript();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- DB Writer ---\n");
                _context.Request();
            }
        }
    }
}
