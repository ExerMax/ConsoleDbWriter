using DbWriter.src.Services;

namespace DbWriter.src.Scripts
{
    public class ReadFileScript : InteractionScript
    {
        public override void Interact(InteractionContext context)
        {
            Console.WriteLine("Идет чтение файла");

            var res = context.XmlParser.Read(context.Storage.FilePath);

            if (res != null)
            {
                context.Storage.SuccessfulReaded = res.Count();
                context.Storage.Orders = res;
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
