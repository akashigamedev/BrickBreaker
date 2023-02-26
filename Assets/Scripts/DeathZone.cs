using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeathZone : MonoBehaviour
{
    public event EventHandler OnDeathRecieved;

    void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.TryGetComponent<Ball>(out Ball ball);
        if (ball != null)
        {
            // Notify GameManager To Enable Death Screen
            OnDeathRecieved?.Invoke(this, EventArgs.Empty);
        }
    }
}
