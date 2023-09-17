using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snowraph.Behaviour
{
    public interface IWaitForInteraction
    {
        /// <summary>
        /// Start the wait for an interaction
        /// </summary>
        /// <param name="behaviourController">The behaviour controller that called the wait for interaction</param>
        void WaitForInteraction(IBehaviourController behaviourController);

        /// <summary>
        /// Stop the wait for an interaction
        /// </summary>
        /// <param name="behaviourController">The behaviour controller that called the stop for interaction</param>
        void StopWaitForInteraction(IBehaviourController behaviourController);
    }
}
