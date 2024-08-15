using DbWriter.src.Services;

namespace DbWriter.src.Scripts
{
    public class ErrorScript : InteractionScript
    {
        private readonly string _message;

        public ErrorScript() 
        { 
            _message = string.Empty;
        }
        public ErrorScript(string message)
        {
            _message = message;
        }

        public override void Interact(InteractionContext context)
        {
            Console.WriteLine($"Возникла ошибка {_message}");
            Console.WriteLine("Для продолжения нажмите любую клавишу");
            Console.ReadLine();
            context.Script = new FileRequestScript();
        }
    }
}
