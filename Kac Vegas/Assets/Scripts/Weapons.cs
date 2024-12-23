using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
   public WeaponObject weaponObject;
   private bool canShoot = true;

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

   IEnumerator MoveBullet(GameObject bullet, Vector3 target)
{
    while (bullet != null && Vector3.Distance(bullet.transform.position, target) > 0.1f)
    {
        bullet.transform.position = Vector3.MoveTowards(bullet.transform.position, target, 4f * Time.deltaTime);
        yield return null;
    }

    Destroy(bullet); 
}
public void Attacking()
{
    if(canShoot==true)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    mousePos.z = 0;

    GameObject bulletInstance = Instantiate(weaponObject.bullet, transform.position, Quaternion.identity);
    StartCoroutine(MoveBullet(bulletInstance, mousePos));
    StartCoroutine(ShootingCooldown());
    }
    

}
IEnumerator ShootingCooldown()
    {
        canShoot=false;
        yield return new WaitForSeconds(weaponObject.Speed);
        canShoot=true;
        
    }





}
