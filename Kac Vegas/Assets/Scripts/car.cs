using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    private Vector2 movement;
    private Rigidbody2D rb;



    private void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();

    }
    private void FixedUpdate()
    {
        Move();


    }

    private void Update()
    {
        AutoInput();


    }


    private void AutoInput()
    {
       
        movement.x = 1;

    }
    private void Move()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

}
