using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float speed = 5;

    private void Start()
    {
        Destroy(gameObject, 5);
    }

    private void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }
}