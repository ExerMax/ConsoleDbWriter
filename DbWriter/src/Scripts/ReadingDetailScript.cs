using DbWriter.src.Services;

namespace DbWriter.src.Scripts
{
    public class ReadingDetailScript : InteractionScript
    {
        public override void Interact(InteractionContext context)
        {
            Console.WriteLine("Детали чтения:");
            foreach (var item in context.Storage.Orders)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Для возвращения на прошлый экран введите b");
            Console.WriteLine("Введите другие знаки для выхода на главный экран");
            string str = Console.ReadLine();
            if (str == "b")
            {
                context.Script = new SuccessReadScript();
            }
            else
            {
                context.Script = new FileRequestScript();
            }
        }
    }
}
