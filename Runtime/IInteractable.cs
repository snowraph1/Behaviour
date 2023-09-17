namespace Snowraph.Behaviour
{
    public interface IInteractable
    {
        /// <summary>
        /// Interact with the behaviour
        /// </summary>
        /// <param name="behaviourController">The behaviour conroller that interacts with this object</param>
        void Interact(IBehaviourController behaviourController);

        /// <summary>
        /// Can this behaviour interact with the behaviour controller in parameter
        /// </summary>
        /// <param name="behaviourController">The behaviour controller to test with</param>
        /// <returns>Return true if can interact</returns>
        bool CanInteract(IBehaviourController behaviourController);
    }
}
