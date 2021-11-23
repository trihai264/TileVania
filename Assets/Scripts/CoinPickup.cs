using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] int pointForCoin = 100;

    bool wasCollected = false;
    void OnTriggerEnter2D(Collider2D other)
    {
            if(other.tag == "Player" && !wasCollected)
        {
            wasCollected = false;
            FindObjectOfType<GameSession>().AddScore(pointForCoin);
            Destroy(gameObject);
        }
    }
}
