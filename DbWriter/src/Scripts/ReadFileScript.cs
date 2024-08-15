using DbWriter.src.Services;

namespace DbWriter.src.Scripts
{
    public class ReadFileScript : InteractionScript
    {
        public override void Interact(InteractionContext context)
        {
            Console.WriteLine("Идет чтение файла");

            var res = context._xmlParser.Read(context.storage.FilePath);

            if (res != null)
            {
                context.storage.SuccessfulReaded = res.Count();
                context.storage.orders = res;
                context.Write();
                context.Script = new SuccessReadScript();
            }
            else
            {
                context.Script = new ErrorScript("Не удалось прочитать файл");
            }
        }
    }
}
