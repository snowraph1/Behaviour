using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snowraph.Behaviour
{
    public interface IBehaviourController
    {
        /// <summary>
        /// The name of the Behaviour object
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The root GameObject of the Behaviour object
        /// </summary>
        GameObject RootGameObject { get; }

        /// <summary>
        /// The list of component of the Behaviour object
        /// </summary>
        List<Component> BehaviourComponents { get; }

        /// <summary>
        /// Get an Behaviour component from the list of component
        /// </summary>
        /// <typeparam name="T">The type of the component</typeparam>
        /// <returns>The component or null</returns>
        T GetBehaviourComponent<T>() where T : Component;

        /// <summary>
        /// Get a list of component of the type passed from this intective object
        /// </summary>
        /// <typeparam name="T">The type of component</typeparam>
        /// <returns>The list or null if no component is found</returns>
        List<T> GetBehaviourComponents<T>() where T : Component;

        /// <summary>
        /// Initialize the Behaviour object
        /// </summary>
        void Initialize();

        /// <summary>
        /// Despawn the Behaviour object
        /// </summary>
        void Despawn();
    }
}
