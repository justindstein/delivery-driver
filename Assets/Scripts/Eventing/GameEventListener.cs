using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    public GameEvent gameEvent;
    public UnityEvent response;

    public void OnEventRaised()
    {
        response.Invoke();
    }

    private void OnEnable()
    {
        this.gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        this.gameEvent.UnregisterListener(this);
    }
}
