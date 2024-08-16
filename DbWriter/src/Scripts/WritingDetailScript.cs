using DbWriter.src.Services;

namespace DbWriter.src.Scripts
{
    public class WritingDetailScript : InteractionScript
    {
        public override void Interact(InteractionContext context)
        {
            Console.WriteLine("Детали записи:");
            Console.WriteLine("\n\nЗаписаные заказы:\n");

            foreach (var item in context.storage.orders)
            {
                if (item.Writed)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(item);
                }
            }
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\n\nНе записаные заказы:\n");
            foreach (var item in context.storage.orders)
            {
                if (!item.Writed)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
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
