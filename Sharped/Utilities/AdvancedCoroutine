using System.Collections;
using UnityEngine;

namespace Sharped.Utilities
{ 
    
    [System.Serializable]
public class AdvancedCoroutine
{
    bool isRunning;
    string coroutineName;
    System.Action CallBack;
    System.Action<AdvancedCoroutine> cleanCallback;

    public bool IsRunning { get => isRunning; }
    public string CoroutineName { get => coroutineName;}

    //This is used to create new AdvancedCoroutine from the AdvancedMonobehaviour Class.
    public static AdvancedCoroutine Create(MonoBehaviour gameObject, float duration, bool useUnscaled = false, string coroutineName = null, System.Action callback = null, System.Action<AdvancedCoroutine> cleanCallback = null)
    {
        AdvancedCoroutine timer = new AdvancedCoroutine(gameObject, duration, useUnscaled, coroutineName, callback, cleanCallback);

        return timer;
    }

    //Constructor for AdvancedCoroutines
    public AdvancedCoroutine(MonoBehaviour gameObject, float duration, bool useUnscaled = false, string coroutineName = null, System.Action callback = null, System.Action<AdvancedCoroutine> cleanCallback = null)
    {
        this.CallBack = callback;
        this.cleanCallback = cleanCallback;
        this.coroutineName = coroutineName;
        if (!useUnscaled)
            gameObject.StartCoroutine(TimerCoroutine(duration));
        else if (useUnscaled)
            gameObject.StartCoroutine(TimerCoroutineUnscaled(duration));

    }

    //Real Coroutine that gets invoked under the hood
    IEnumerator TimerCoroutine(float time)
    {
        isRunning = true;
        float timePassed = 0f;
        while (timePassed < time)
        {
            timePassed += Time.deltaTime;
            yield return null;
        }
        CallBack?.Invoke();
        cleanCallback(this);
        isRunning = false;
    }

    IEnumerator TimerCoroutineUnscaled(float time)
    {
        isRunning = true;
        float timePassed = 0f;
        while (timePassed < time)
        {
            timePassed += Time.unscaledDeltaTime;
            yield return null;
        }
        CallBack?.Invoke();
        cleanCallback(this);
        isRunning = false;
    }
}

}
