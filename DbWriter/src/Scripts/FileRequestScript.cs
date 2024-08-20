using DbWriter.src.Services;

namespace DbWriter.src.Scripts
{
    public class FileRequestScript : InteractionScript
    {
        public override void Interact(InteractionContext context)
        {
            context.Storage.Refresh();
            Console.WriteLine("Укажите путь файла для чтения");
            string? path = Console.ReadLine();
            if(path != string.Empty)
            {
                context.Storage.FilePath = path;
                context.Script = new ReadFileScript();
            }
            else
            {
                context.Script = new FileRequestScript();
            }
        }
    }
}
