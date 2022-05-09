using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] Vector3 moveDirection;
    const string HORIZONTAL = "Horizontal";
    const string VERTICAL = "Vertical";
    float h;
    float v;

    [SerializeField] Camera cam;
    [SerializeField] Transform aim;
    [SerializeField] float aimDistance = 2.5f;
    Vector2 facingDirection;

    [SerializeField] Transform bulletPrefab;
    [SerializeField] bool gunIsLoad = true;
    [Range(0, 50)] [SerializeField] float fireRate = 1;

    [SerializeField] int health = 5;

    private void Update()
    {
        Move();
        AimControll();

        if (Input.GetMouseButton(0) && gunIsLoad)
        {
            gunIsLoad = false;
            float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Instantiate(bulletPrefab, transform.position, rotation);
            StartCoroutine(LoadGun());
        }

    }

    void Move()
    {
        h = Input.GetAxisRaw(HORIZONTAL);
        v = Input.GetAxisRaw (VERTICAL);
        moveDirection.x = h;
        moveDirection.y = v;

        transform.position += moveDirection.normalized * speed * Time.deltaTime;
    }

    void AimControll()
    {
        facingDirection = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        aim.position = transform.position + (Vector3)facingDirection.normalized * aimDistance;
    }

    IEnumerator LoadGun()
    {
        yield return new WaitForSeconds(1 / fireRate);
        gunIsLoad = true;
    }

    public void TakeDamage()
    {
        health--;
        if (health == 0) Debug.Log("Game Over");
    }
}
