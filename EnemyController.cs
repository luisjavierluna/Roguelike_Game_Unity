using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] int health = 1;
    [SerializeField] float speed = 5;

    [SerializeField] Transform player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
    }

    private void Update()
    {
        Vector2 direction = player.position - transform.position;
        transform.position += (Vector3)direction.normalized * speed * Time.deltaTime;
    }

    public void TakeDamage()
    {
        health--;
        if (health == 0)
        {
            Destroy(gameObject, 0.1f);
        }
    }


}