namespace Snowraph.Behaviour
{
    public interface IInitializable
    {
        /// <summary>
        /// Used to initialize behaviour components
        /// </summary>
        /// <param name="behaviourController">The behaviour controller the initialization comes from</param>
        void Initialize(IBehaviourController behaviourController);
    }
}
