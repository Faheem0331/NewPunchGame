using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateArm : MonoBehaviour
{
    public GameObject myPrefab;
    public Transform targetPosition;
    public float delay;
    public float remainingTime;
    public bool play;

    public void Start()
    {
        remainingTime = delay;
    }

    public void FixedUpdate()
    {
        if (play)
        {
           Invoke(nameof(GenerateArmAfterDelay),0.04f);
        }
     
    }

    public void GenerateArmAfterDelay()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.fixedTime;
        }
        else
        {
            remainingTime = delay;
            SpawnGameObject();
           
        } 
    }

    public GameObject lastObj;
    public GameObject currentObj;
    public bool firstTime;
    public void SpawnGameObject()
    {
        var tempObject= Instantiate(myPrefab, targetPosition.position, Quaternion.identity);
        tempObject.transform.parent = gameObject.transform;
        currentObj = tempObject;
        AssignTargetToLastOne(currentObj);
    }

    public void AssignTargetToLastOne(GameObject current)
    {
        if (firstTime)
        {
            lastObj.GetComponent<LookAtEnemey>().target = current.transform;
            lastObj = currentObj;
        }
        else
        {
            lastObj = current;
        }
        firstTime = true;
    }
}
