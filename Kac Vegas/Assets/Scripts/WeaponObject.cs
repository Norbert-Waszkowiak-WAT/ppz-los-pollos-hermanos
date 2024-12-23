using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Weapons/WeaponObject")]

public class WeaponObject : ScriptableObject
{
   [SerializeField] private int atk;
   [SerializeField] private float speed;
   [SerializeField] private int manna;
   [SerializeField] public GameObject bullet;
  

   public int Atk => atk;
   public float Speed => speed;
   public int Manna => manna;
   public GameObject Bullet => bullet;


   
}

