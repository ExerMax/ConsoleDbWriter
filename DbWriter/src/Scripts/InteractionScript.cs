using DbWriter.src.Services;

namespace DbWriter.src.Scripts
{
    public abstract class InteractionScript
    {
        public abstract void Interact(InteractionContext context);
    }
}
