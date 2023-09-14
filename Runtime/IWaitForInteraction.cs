using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snowraph.InteractiveObjects
{
    public interface IWaitForInteraction
    {
        /// <summary>
        /// Start the wait for an interaction
        /// </summary>
        /// <param name="interactiveObject">The interactive object that called the wait for interaction</param>
        void WaitForInteraction(IInteractiveObject interactiveObject);

        /// <summary>
        /// Stop the wait for an interaction
        /// </summary>
        /// <param name="interactiveObject">The interactive object that called the stop for interaction</param>
        void StopWaitForInteraction(IInteractiveObject interactiveObject);
    }
}
