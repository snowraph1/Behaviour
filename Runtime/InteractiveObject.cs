
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Snowraph.InteractiveObjects
{
    public class InteractiveObject : MonoBehaviour, IInteractiveObject
    {
        #region Private Fields

        [SerializeField] private List<Component> _interactiveComponents = new List<Component>();

        #endregion

        #region IInteractiveObject Properties

        /// <summary>
        /// The list of component of the interactive object
        /// </summary>
        public List<Component> InteractiveComponents
        {
            get { return _interactiveComponents; }
        }

        /// <summary>
        /// The root GameObject of the interactive object
        /// </summary>
        public GameObject RootGameObject
        {
            get { return gameObject; }
        }

        /// <summary>
        /// The name of the interactive object
        /// </summary>
        public string Name
        {
            get { return gameObject.name; }
        }

        #endregion

        #region IInteractiveObject Methods

        /// <summary>
        /// Initialize the interactive object
        /// </summary>
        public virtual void Initialize()
        {
            InitializeComponents();
        }

        /// <summary>
        /// Despawn the interactive object
        /// </summary>
        public virtual void Despawn()
        {

        }

        /// <summary>
        /// Get an interactive component from the list of component
        /// </summary>
        /// <typeparam name="T">The type of the component</typeparam>
        /// <returns>The component or null</returns>
        public T GetInteractiveComponent<T>() where T : Component
        {
            for (int i = 0; i < _interactiveComponents.Count; i++)
            {
                if (_interactiveComponents[i].GetType() == typeof(T))
                {
                    return (T)_interactiveComponents[i];
                }
            }

            return null;
        }

        /// <summary>
        /// Get a list of component of the type passed from this intective object
        /// </summary>
        /// <typeparam name="T">The type of component</typeparam>
        /// <returns>The list or null if no component is found</returns>
        public List<T> GetInteractiveComponents<T>() where T : Component
        {
            List<T> components = new List<T>();

            for (int i = 0; i < _interactiveComponents.Count; i++)
            {
                if (_interactiveComponents[i].GetType() == typeof(T))
                {
                    components.Add((T)_interactiveComponents[i]);
                }
            }

            if (components.Count > 0)
            {
                return components;
            }else
            {
                return null;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Initialize components in the list
        /// </summary>
        private void InitializeComponents()
        {
            for (int i = 0; i < _interactiveComponents.Count; i++)
            {
                if (_interactiveComponents[i] is IInitializable)
                {
                    ((IInitializable)_interactiveComponents[i]).Initialize(this);
                };
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Used byt the InteractiveObjectEditor to update the component list with components in child objects.
        /// </summary>
        public void UpdateComponentList()
        {
            Component[] components = gameObject.GetComponentsInChildren<Component>();

            for (int i = 0; i < components.Length; i++)
            {
                if (components[i] is Transform ||
                    components[i] is Rigidbody ||
                    components[i] is Collider ||
                    components[i] is IInteractiveObject ||
                    components[i] is MeshRenderer ||
                    components[i] is MeshFilter ||
                    _interactiveComponents.Contains(components[i]) ||
                    components[i] is ParticleSystem ||
                    components[i] is ParticleSystemRenderer)
                {
                    continue;
                }

                _interactiveComponents.Add(components[i]);
            }

            //Cleaning the component list
            for (int i = _interactiveComponents.Count - 1; i >= 0; i--)
            {
                if (_interactiveComponents[i] == null)
                {
                    _interactiveComponents.RemoveAt(i);
                }
            }
        }

        #endregion
    }
}
