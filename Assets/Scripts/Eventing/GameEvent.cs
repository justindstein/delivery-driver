using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameEvent")]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> listeners;

    public void Awake()
    {
        this.listeners = new List<GameEventListener>();
    }

    public void Raise()
    {
        for (int i = 0; i < listeners.Count; i++)
        {
            this.listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(GameEventListener listener)
    {
        if (!this.listeners.Contains(listener))
            this.listeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener)
    {
        if (this.listeners.Contains(listener))
            this.listeners.Remove(listener);
    }
}
