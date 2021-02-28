using System.Collections.Generic;
using UnityEngine;

namespace Sharped.Utilities
{
    public class AdvancedMonobehaviour : MonoBehaviour
    {
        public List<AdvancedCoroutine> activeCoroutines;
    
        protected virtual void Start()
        {
            activeCoroutines = new List<AdvancedCoroutine>();
        }
    
        /// <summary>
        /// Creates an AdvancedCoroutine with the specified parameters.
        /// Under the hood it also adds the Coroutine to the activeCoroutines list
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="coroutineName"></param>
        /// <param name="callback"></param>
        protected void CreateCoroutine(float duration,bool useUnscaled = false, string coroutineName = null, System.Action callback = null)
        {
            AdvancedCoroutine coroutine = AdvancedCoroutine.Create(this, duration,useUnscaled, coroutineName, callback, CleanCallback);
            activeCoroutines.Add(coroutine);
        }
    
        /// <summary>
        /// Method used to remove a Coroutine by its name.
        /// Useful when you need to stop something running 
        /// </summary>
        /// <param name="coroutineName"></param>
        protected void RemoveCoroutine(string coroutineName)
        {
            AdvancedCoroutine foundCoroutine = activeCoroutines.Find((c) => c.CoroutineName == coroutineName);
            if (foundCoroutine != null)
            {
                activeCoroutines.Remove(foundCoroutine);
            }
        }
    
        /// <summary>
        /// Checks if the given Coroutine is running
        /// </summary>
        /// <param name="coroutineName"></param>
        /// <returns></returns>
        protected bool CheckRunning(string coroutineName)
        {
            AdvancedCoroutine found = activeCoroutines.Find((c) => c.CoroutineName == coroutineName);
            if (found != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    
        //Used to CleanCallback from list
        void CleanCallback(AdvancedCoroutine coroutine)
        {
            activeCoroutines.Remove(coroutine);
        }
    }

}
