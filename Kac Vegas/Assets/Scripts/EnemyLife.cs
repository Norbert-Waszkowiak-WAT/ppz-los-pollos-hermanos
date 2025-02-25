using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
   
    public int hp;

    ContactFilter2D filter;
    
    private Bullet bullet;
    

    void Awake()
    {
        filter = new ContactFilter2D();
        filter.SetLayerMask(LayerMask.GetMask("Deafult"));
        filter.useLayerMask = true;
    }
    void Start()
    {
       
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
       
    }
    void Update()
    {
        if( hp<0)
        {
            Destroy(gameObject);
        }
        
    }


    public void TakingDamage(int a)
    {
        hp = this.hp- a;
    }
    /*void OnCollisionEnter2D(Collision2D collision)
    { 
        bullet = null;
        
    if (collision.gameObject.CompareTag("Bullet"))
    {
        Debug.Log("life");
        Collider2D collider2D = Physics2D.OverlapCircle(transform.position, 3f, filter.layerMask);

        if (collider2D != null && collider2D.GetComponent<Bullet>() !=null)
        {
            Debug.Log("life 222");
            bullet = collider2D.GetComponent<Bullet>();
            TakingDamage(bullet.weaponObject.Atk);
            Debug.Log("damage");
            Destroy(bullet.gameObject);

            Debug.Log("lifee 333");
        }

        
    }
    
    }*/


    void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Bullet"))
    {
        
        
       
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();

        if (bullet != null)
        {
            
            TakingDamage(bullet.weaponObject.Atk);
            
        }

       
        Destroy(collision.gameObject);
        
    }
}


}
