using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snowraph.InteractiveObjects
{
    public interface IInteractiveObject
    {
        /// <summary>
        /// The name of the interactive object
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The root GameObject of the interactive object
        /// </summary>
        GameObject RootGameObject { get; }

        /// <summary>
        /// The list of component of the interactive object
        /// </summary>
        List<Component> InteractiveComponents { get; }

        /// <summary>
        /// Get an interactive component from the list of component
        /// </summary>
        /// <typeparam name="T">The type of the component</typeparam>
        /// <returns>The component or null</returns>
        T GetInteractiveComponent<T>() where T : Component;

        /// <summary>
        /// Get a list of component of the type passed from this intective object
        /// </summary>
        /// <typeparam name="T">The type of component</typeparam>
        /// <returns>The list or null if no component is found</returns>
        List<T> GetInteractiveComponents<T>() where T : Component;

        /// <summary>
        /// Initialize the interactive object
        /// </summary>
        void Initialize();

        /// <summary>
        /// Despawn the interactive object
        /// </summary>
        void Despawn();
    }
}
