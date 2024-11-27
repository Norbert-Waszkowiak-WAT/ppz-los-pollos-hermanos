using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class ChickenPathFinding : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f; 
   
   private Rigidbody2D rig;
   private Vector2 moveDir;
   private SpriteRenderer mySprite;


    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        rig.MovePosition(rig.position+ moveDir*(moveSpeed* Time.fixedDeltaTime));


    }

    public void MoveTo(Vector2 targetPosition)
    {
        moveDir = targetPosition;
    
        mySprite.flipX = moveDir.x < 0;



    }

   
}
