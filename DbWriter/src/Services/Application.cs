using DbWriter.src.Interfaces;

namespace DbWriter.src.Services
{
    public class Application
    {
        private readonly IInteractHandler _interactor;
        public Application(IInteractHandler interactor) 
        { 
            _interactor = interactor;
        }
        public void Run()
        {
            _interactor.Handle();
        }
    }
}
