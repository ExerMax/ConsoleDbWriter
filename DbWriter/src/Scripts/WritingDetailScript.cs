using DbWriter.src.Services;

namespace DbWriter.src.Scripts
{
    public class WritingDetailScript : InteractionScript
    {
        public override void Interact(InteractionContext context)
        {
            Console.WriteLine("Детали записи:");
            Console.WriteLine("\n\nЗаписаные заказы:\n");

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var item in context.Storage.Orders)
            {
                if (item.Writed)
                {
                    Console.WriteLine(item);
                }
            }
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\n\nНе записаные заказы:\n");

            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var item in context.Storage.Orders)
            {
                if (!item.Writed)
                {
                    Console.WriteLine(item);
                }
            }
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Для возвращения на прошлый экран введите b");
            Console.WriteLine("Введите другие знаки для выхода на главный экран");
            string str = Console.ReadLine();

            if(str == "b")
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
