using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] float originalSpeed;
    [SerializeField] float speedReductionRatio = 0.5f;

    PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();

        originalSpeed = player.speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.speed *= speedReductionRatio;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.speed = originalSpeed;
        }
    }
}
