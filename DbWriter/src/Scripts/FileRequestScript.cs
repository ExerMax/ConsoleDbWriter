using DbWriter.src.Services;

namespace DbWriter.src.Scripts
{
    public class FileRequestScript : InteractionScript
    {
        public override void Interact(InteractionContext context)
        {
            context.storage.FilePath = "";
            Console.WriteLine("Укажите путь файла для чтения");
            context.storage = new Structs.Storage();
            string? path = Console.ReadLine();
            if(path != string.Empty)
            {
                context.storage.FilePath = path;
                context.Script = new ReadFileScript();
            }
            else
            {
                context.Script = new FileRequestScript();
            }
        }
    }
}
