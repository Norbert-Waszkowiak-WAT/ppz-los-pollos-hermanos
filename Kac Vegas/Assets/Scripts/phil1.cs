using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phil1 : MonoBehaviour
{
    private Animator myAnimator;
    private Vector3 lastPos;

    void Awake()
    {
        lastPos = transform.position;
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (CharMoved())
        {
            myAnimator.SetFloat("moveX", 1);
            myAnimator.SetFloat("moveY", 1);
        }
        else
        {
            myAnimator.SetFloat("moveX", 0);
            myAnimator.SetFloat("moveY", 0);
        }
    }

    bool CharMoved()
    {
        Vector3 displacement = transform.position - lastPos;
        lastPos = transform.position;

      
        if (displacement.magnitude > 0.01f) 
        {
            Debug.Log("Moving");
            return true;
        }

        return false;
    }
}




