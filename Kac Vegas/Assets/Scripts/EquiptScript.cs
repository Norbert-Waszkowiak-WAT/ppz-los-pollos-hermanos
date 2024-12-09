using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EquiptScript : MonoBehaviour
{
    public Transform PlayerTransform;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    


    public void UnequipObject(GameObject weapon)
    {
        PlayerTransform.DetachChildren();
        

        weapon.transform.position = new Vector2(weapon.transform.position.x, weapon.transform.position.y);
        weapon.GetComponent<Rigidbody2D>().isKinematic = false;
    }

    public void EquipObject(GameObject weapon)
    {
        weapon.GetComponent<Rigidbody2D>().isKinematic = true;
        weapon.transform.position = PlayerTransform.transform.position;
        weapon.transform.rotation = PlayerTransform.transform.rotation;
        weapon.transform.SetParent(PlayerTransform);
    }


}