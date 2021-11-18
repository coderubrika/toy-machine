using UltEvents;

namespace Assets.Scripts
{
    public class UltEventHolderSafe : UltEventHolder
    {
        public virtual void InvokeSafe()
        {
            Event.InvokeSafe();
        }
    }
}