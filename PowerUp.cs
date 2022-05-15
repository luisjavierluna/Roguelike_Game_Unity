using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType
    {
        fireRateIncrease,
        healthIncrease
    }

    public PowerUpType powerUpType;

    private void Start()
    {
        Destroy(gameObject, 20);
    }
}
