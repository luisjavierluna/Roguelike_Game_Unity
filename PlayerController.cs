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

    private void Update()
    {
        h = Input.GetAxisRaw(HORIZONTAL);
        v = Input.GetAxisRaw (VERTICAL);
        moveDirection.x = h;
        moveDirection.y = v;
        transform.position += moveDirection.normalized * speed * Time.deltaTime;

        facingDirection = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        aim.position = transform.position + (Vector3)facingDirection.normalized * aimDistance;
    }


}
