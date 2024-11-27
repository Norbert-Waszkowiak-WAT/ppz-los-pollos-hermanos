using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenAI : MonoBehaviour
{
   private enum State{
    Roaming
   }

   private State state;
   private ChickenPathFinding chickenPathFinding;

   private void Awake()
   {
    chickenPathFinding = GetComponent<ChickenPathFinding>();
    state=State.Roaming;

   }
   private void Start(){
    StartCoroutine(RoamingRoutine());


   }

   private IEnumerator RoamingRoutine()
   {
    while(state==State.Roaming){
        Vector2 roamPosition = GetRoamingPosition();
        chickenPathFinding.MoveTo(roamPosition);
        yield return new WaitForSeconds(1f);

    }

   }

   private Vector2 GetRoamingPosition(){
    return new Vector2(Random.Range(-1f,1f), Random.Range(-1f,1f)).normalized;
   }

   private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 roamPosition = GetRoamingPosition();
       chickenPathFinding.MoveTo(roamPosition);
    }

}
