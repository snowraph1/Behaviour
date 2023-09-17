
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Snowraph.Behaviour
{
    public class BehaviourController : MonoBehaviour, IBehaviourController
    {
        #region Private Fields

        [SerializeField] private List<Component> _behaviourComponents = new List<Component>();

        #endregion

        #region IBehaviourObject Properties

        /// <summary>
        /// The list of component of the behaviour controller
        /// </summary>
        public List<Component> BehaviourComponents
        {
            get { return _behaviourComponents; }
        }

        /// <summary>
        /// The root GameObject of the behaviour controller
        /// </summary>
        public GameObject RootGameObject
        {
            get { return gameObject; }
        }

        /// <summary>
        /// The name of the behaviour controller
        /// </summary>
        public string Name
        {
            get { return gameObject.name; }
        }

        #endregion

        #region IBehaviourObject Methods

        /// <summary>
        /// Initialize the behaviour controller
        /// </summary>
        public virtual void Initialize()
        {
            InitializeComponents();
        }

        /// <summary>
        /// Despawn the behaviour controller
        /// </summary>
        public virtual void Despawn()
        {

        }

        /// <summary>
        /// Get an behaviour component from the list of component
        /// </summary>
        /// <typeparam name="T">The type of the component</typeparam>
        /// <returns>The component or null</returns>
        public T GetBehaviourComponent<T>() where T : Component
        {
            for (int i = 0; i < _behaviourComponents.Count; i++)
            {
                if (_behaviourComponents[i].GetType() == typeof(T))
                {
                    return (T)_behaviourComponents[i];
                }
            }

            return null;
        }

        /// <summary>
        /// Get a list of component of the type passed from this intective object
        /// </summary>
        /// <typeparam name="T">The type of component</typeparam>
        /// <returns>The list or null if no component is found</returns>
        public List<T> GetBehaviourComponents<T>() where T : Component
        {
            List<T> components = new List<T>();

            for (int i = 0; i < _behaviourComponents.Count; i++)
            {
                if (_behaviourComponents[i].GetType() == typeof(T))
                {
                    components.Add((T)_behaviourComponents[i]);
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
            for (int i = 0; i < _behaviourComponents.Count; i++)
            {
                if (_behaviourComponents[i] is IInitializable)
                {
                    ((IInitializable)_behaviourComponents[i]).Initialize(this);
                };
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Used byt the BehaviourObjectEditor to update the component list with components in child objects.
        /// </summary>
        public void UpdateComponentList()
        {
            Component[] components = gameObject.GetComponentsInChildren<Component>();

            for (int i = 0; i < components.Length; i++)
            {
                if (components[i] is Transform ||
                    components[i] is Rigidbody ||
                    components[i] is Collider ||
                    components[i] is IBehaviourController ||
                    components[i] is MeshRenderer ||
                    components[i] is MeshFilter ||
                    _behaviourComponents.Contains(components[i]) ||
                    components[i] is ParticleSystem ||
                    components[i] is ParticleSystemRenderer)
                {
                    continue;
                }

                _behaviourComponents.Add(components[i]);
            }

            //Cleaning the component list
            for (int i = _behaviourComponents.Count - 1; i >= 0; i--)
            {
                if (_behaviourComponents[i] == null)
                {
                    _behaviourComponents.RemoveAt(i);
                }
            }
        }

        #endregion
    }
}
