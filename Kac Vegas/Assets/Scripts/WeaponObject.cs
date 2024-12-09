using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Weapons/WeaponObject")]

public class WeaponObject : ScriptableObject
{
   [SerializeField] private int atk;
   [SerializeField] private int speed;
   [SerializeField] private int manna;
  

   public int Atk => atk;
   public int Speed => speed;
   public int Manna => manna;


}

