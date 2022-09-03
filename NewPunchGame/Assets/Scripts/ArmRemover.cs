using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRemover : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Glove"))
        {
            if (PlayerAnimationController.Instance.nowRemove)
            {
                Destroy(gameObject);
            }
           
        }

        if (other.gameObject.CompareTag("tempArm"))
        {
            Destroy(gameObject);
        }
    } 
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Glove"))
        {
            if (PlayerAnimationController.Instance.nowRemove)
            {
                Destroy(gameObject);
            }
           
        }
    }

    public void Update()
    {
        if (PlayerAnimationController.Instance.playerReachedAfterDeath)
        {
            Destroy(gameObject);
        }
    }
}
