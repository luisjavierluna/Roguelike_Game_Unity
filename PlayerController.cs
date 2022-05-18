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
    [Range(0, 50)] [SerializeField] float fireRate = 1;
    [SerializeField] bool gunIsLoad = true;

    [SerializeField] int health = 5;

    [SerializeField] bool invulnerable;
    [SerializeField] float invulnerableTime = 2;
    [SerializeField] float blinkRate = 0.01f;

    [SerializeField] SpriteRenderer spriteRenderer;

    private void Update()
    {
        Move();
        AimControll();

        if (Input.GetMouseButton(0) && gunIsLoad)
        {
            Shoot();
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

    void Shoot()
    {
        gunIsLoad = false;
        float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Instantiate(bulletPrefab, transform.position, rotation);
        StartCoroutine(LoadGun());
    }

    public void TakeDamage()
    {
        if (invulnerable) return;
        invulnerable = true;
        StartCoroutine(MakeVulnerableAgain());
        fireRate = 15;
        health--;
        if (health == 0) Debug.Log("Game Over");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PowerUp"))
        {
            switch (collision.GetComponent<PowerUp>().powerUpType)
            {
                case PowerUp.PowerUpType.fireRateIncrease:
                    fireRate++;
                    break;
                case PowerUp.PowerUpType.healthIncrease:
                    health += 3;
                    break;
            }
            Destroy(collision.gameObject, 0.01f);
        }
    }

    IEnumerator MakeVulnerableAgain()
    {
        StartCoroutine(BlinkRoutine());
        yield return new WaitForSeconds(invulnerableTime);
        invulnerable = false;
    }

    IEnumerator BlinkRoutine()
    {
        int t = 10;

        while (t > 0)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(t * blinkRate);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(t * blinkRate);
            t--;
        }
    }
}
