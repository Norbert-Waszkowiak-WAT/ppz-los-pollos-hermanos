using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
   public WeaponObject weaponObject;

   private Rigidbody2D rig;
   

   void Awake()
   {
      rig = GetComponent<Rigidbody2D>();

   }


 void Update()
{
    
    Vector3 mousePos = Input.mousePosition;
    Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane));

  
    Vector3 direction = worldMousePos - transform.position;
    float angleRad = Mathf.Atan2(direction.y, direction.x);
    float angleDeg = angleRad * Mathf.Rad2Deg;

    SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();


    if (worldMousePos.x < transform.position.x)
    {
        
        spriteRenderer.flipX = true;

        
        transform.rotation = Quaternion.Euler(0f, 0f, angleDeg + 180f);
    }
    else
    {
       
        spriteRenderer.flipX = false;

        
        transform.rotation = Quaternion.Euler(0f, 0f, angleDeg);
    }
}


}
