using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heartbeat : MonoBehaviour
{
    public static Heartbeat Instance { get; private set; }
    
    const float TURN_DELAY = 1;
    private float turnTimer;

    public bool isPaused { get; private set; }

    private List<IHeartbeats> heartbeatSubscribers = new List<IHeartbeats>();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        isPaused = true;
    }

    private void Start()
    {
        turnTimer = TURN_DELAY;
    }

    private void FixedUpdate()
    {
        if (!isPaused)
        {
            HeartbeatTimer();
        }
    }

    void HeartbeatTimer()
    {
        if (turnTimer > 0)
        {
            turnTimer -= Time.deltaTime;
        }
        else
        {
            Heartbeats();
            turnTimer = TURN_DELAY;
        }
    }

    #region Heartbeats
    void Heartbeats()
    {
        //Debug.Log("Thump");

        /*
        foreach (IHeartbeats subscriber in heartbeatSubscribers)
        {
            if (subscriber != null)
            {
                subscriber.OnHeartbeat();
            }
        }
        */

        List<IHeartbeats> tempSubscribers = new List<IHeartbeats>(heartbeatSubscribers);
        foreach (IHeartbeats subscriber in tempSubscribers)
        {
            if (subscriber != null)
            {
                subscriber.OnHeartbeat();
            }
        }
    }

    public void Subscribe(IHeartbeats subscriber)
    {
        heartbeatSubscribers.Add(subscriber);
    }

    public void Unsubscribe(IHeartbeats subscriber)
    {
        heartbeatSubscribers.Remove(subscriber);
    }
    #endregion

    public void PauseHeartbeat(bool newVal)
    {
        isPaused = newVal;
    }
}
