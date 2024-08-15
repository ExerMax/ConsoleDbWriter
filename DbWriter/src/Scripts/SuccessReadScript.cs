using DbWriter.src.Services;

namespace DbWriter.src.Scripts
{
    public class SuccessReadScript : InteractionScript
    {
        public override void Interact(InteractionContext context)
        {
            Console.WriteLine("Запись данных завершена");
            Console.WriteLine($"Заказов прочитано успешно:{context.storage.SuccessfulReaded}");
            Console.WriteLine($"Заказов записано успешно:{context.storage.SuccessfulReaded}");
            Console.WriteLine("Для просмотра детализации записи введите - d");
            string str = Console.ReadLine();
            if (str == "d") context.Script = new DetailingScreenScript();
            else context.Script = new FileRequestScript();
        }
    }
}
