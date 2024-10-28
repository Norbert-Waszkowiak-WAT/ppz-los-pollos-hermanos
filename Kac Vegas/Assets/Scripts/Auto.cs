using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Auto : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;

    private AutoControls autoControls;
    private Vector2 movement;
    private Rigidbody2D rb;
   
    private SpriteRenderer mySpriteRender;

    public GameManager gameManager;
    private bool isDead = false;
    
    

    private void Awake()
    {
        autoControls = new AutoControls();
        rb = GetComponent<Rigidbody2D>();
       
        mySpriteRender = GetComponent<SpriteRenderer>();

       

    }

    private void OnEnable()
    {
        autoControls.Enable();

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
        movement = autoControls.Movement.Move.ReadValue<Vector2>();
        movement.x = 1;

    }
 

    private void Move()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("car") && !isDead)
        {


            isDead = true;  
            gameManager.gameOver();
            autoControls.Disable();

        }
    }

    
}
