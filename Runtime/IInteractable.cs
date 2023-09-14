
namespace Snowraph.InteractiveObjects
{
    public interface IInteractable
    {
        /// <summary>
        /// Interact with the Interactive object
        /// </summary>
        /// <param name="interactiveObject">The interactive object that interact with this object</param>
        void Interact(IInteractiveObject interactiveObject);

        /// <summary>
        /// Can this interactive object interact with the object in parameter
        /// </summary>
        /// <param name="interactiveObject">The interact object to test with</param>
        /// <returns>Return true if can interact</returns>
        bool CanInteract(IInteractiveObject interactiveObject);
    }
}
