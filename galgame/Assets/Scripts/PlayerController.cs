using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody2D rb;

    private float moveX, moveY;

    private Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputSection();
    }
    private void FixedUpdate()
    {
        playerMove();
    }
    private void inputSection()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX,moveY);
    }
    private void playerMove()
    {
        rb.velocity = new Vector2(moveDirection.x* moveSpeed, moveDirection.y * moveSpeed);
    }
}
