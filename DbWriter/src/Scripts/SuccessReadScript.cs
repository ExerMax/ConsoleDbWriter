using DbWriter.src.Services;

namespace DbWriter.src.Scripts
{
    public class SuccessReadScript : InteractionScript
    {
        public override void Interact(InteractionContext context)
        {
            Console.WriteLine("Запись данных завершена");
            Console.WriteLine($"Заказов прочитано успешно:{context.Storage.SuccessfulReaded}");
            Console.WriteLine($"Заказов записано успешно:{context.Storage.SuccessfulWrited}");
            Console.WriteLine("Для просмотра детализации чтения введите - rd");
            Console.WriteLine("Для просмотра детализации записи введите - wd");
            string str = Console.ReadLine();
            if (str == "rd") context.Script = new ReadingDetailScript();
            else if (str == "wd") context.Script = new WritingDetailScript();
            else context.Script = new FileRequestScript();
        }
    }
}
