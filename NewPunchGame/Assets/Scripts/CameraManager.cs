using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Utilities;

public class CameraManager : MonoBehaviour
{
   public CameraFollow cameraFollow;
   public LookAtEnemey lookAtEnemy;
   public Transform[] numberOfEnemy;
   public Transform[] cameraTargetPoint;
   public Vector3 lastOffset;
   public int currentEnemy;

   public void SwitchCamera()
   {
      Invoke(nameof(MoveCameraToEnemy),0.5f);
   }

   public bool isLast;
   public void MoveCameraToEnemy()
   {
       if (numberOfEnemy.Length-1 > currentEnemy)
       {
           currentEnemy++;
       }

       if (numberOfEnemy.Length-1 == currentEnemy)
       {
           isLast = true;
       }
    
       cameraFollow.target = numberOfEnemy[currentEnemy];
       cameraFollow.smoothTime = 0.5f;
       Invoke(nameof(BackToMainPlayer),1.2f);
   }

   public void BackToMainPlayer()
   {
       cameraFollow.smoothTime = 0.35f;
       lookAtEnemy.target = numberOfEnemy[currentEnemy];
       cameraFollow.target = lookAtEnemy.gameObject.transform;

       if (isLast)
       {
           gameObject.transform.DORotate(new Vector3(36.7f, 16, 0), 0.2f);
           cameraFollow.offset = lastOffset;
       }
   }
   
}
