using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float moveSpeed = 2f;
    private bool canAttack = true;
    private PlayerController player;

    void Start()
    {
        
        player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        
        if (player != null)
        {
            Moving();
        }
    }

    void Moving()
    {
        if (canAttack)
        {
            
            Vector2 targetPosition = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            transform.position = targetPosition;
        }
        else
        {
            
            Vector2 directionAway = (transform.position - player.transform.position).normalized;
            transform.position += (Vector3)(directionAway * moveSpeed * Time.deltaTime);
            
        }
    }

    void Attack()
    {
        moveSpeed=3f;
        Debug.Log("Attacking Player!");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canAttack)
        {
            Attack();
            canAttack = false;

            
            StartCoroutine(ResetAttackCooldown());
        }
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(2f);
        canAttack = true;
        moveSpeed=2f;
    }
}
