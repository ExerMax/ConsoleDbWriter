using DbWriter.src.Services;

namespace DbWriter.src.Scripts
{
    public class DetailingScreenScript : InteractionScript
    {
        public override void Interact(InteractionContext context)
        {
            Console.WriteLine("Детали записи:");
            foreach(var item in context.storage.orders)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Нажмите любую клавишу для выхода на главный экран");
            Console.Read();
            context.Script = new FileRequestScript();
        }
    }
}
