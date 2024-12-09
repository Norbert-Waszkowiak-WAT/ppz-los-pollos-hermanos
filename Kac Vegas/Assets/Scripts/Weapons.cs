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
      Vector3 ScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
      float angleRad = Mathf.Atan2(mousePos.y - transform.position.y,mousePos.x - transform.position.x);
      float angleDef = (360 / Mathf.PI) * angleRad-90;
      transform.rotation = Quaternion.Euler(0f,0f, angleDef);
   }
}
