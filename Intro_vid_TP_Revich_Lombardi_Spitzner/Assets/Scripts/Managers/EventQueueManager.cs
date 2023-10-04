using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventQueueManager : MonoBehaviour
{
    #region SINGLETON

    public static EventQueueManager instance;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        instance = this;
    }

    #endregion

    public Queue<ICommand> EventQueue => _eventQueue;
    private Queue<ICommand> _eventQueue = new();

    private void Update()
    {
        while (_eventQueue.Count > 0)
        {
            ICommand command = _eventQueue.Dequeue();
            command.Do();
        }
    }

    public void AddEvent(ICommand command) => _eventQueue.Enqueue(command);
}