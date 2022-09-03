using System;
using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class PathCreat : MonoBehaviour
{
    public PathCreator pathCreator;
    public float delay;
    public float reamingTime;


    public void Update()
    {
        if (reamingTime > 0)
        {
            reamingTime -= Time.deltaTime;
        }
        else
        {
            pathCreator.TriggerPathUpdate();
            reamingTime = delay;
        }
    }
}
