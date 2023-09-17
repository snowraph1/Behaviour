namespace Snowraph.InteractiveObjects
{
    public interface IInitializable
    {
        /// <summary>
        /// Used to initialize interactive components
        /// </summary>
        /// <param name="interactiveObject">The interactive object the initialization comes from</param>
        void Initialize(IInteractiveObject interactiveObject);
    }
}
