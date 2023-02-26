using UnityEngine;
using System;

public class Brick : MonoBehaviour
{
    [SerializeField] int points = 100;
    public class OnScoreUpdated_EventArgs : EventArgs
    {
        public int _points;
        public bool isCoinDrop;
    }
    public static event EventHandler<OnScoreUpdated_EventArgs> OnScoreUpdated;
    bool coinDrop = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        int chanceToDropGold = UnityEngine.Random.Range(0, 100);
        if (chanceToDropGold > 40)
        {
            coinDrop = true;
        }
        OnScoreUpdated?.Invoke(this, new OnScoreUpdated_EventArgs() { _points = points, isCoinDrop = coinDrop });
        gameObject.SetActive(false);
    }
}
