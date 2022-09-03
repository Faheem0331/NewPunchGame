using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public static PlayerAnimationController Instance;
    public Animator playerAnimation;
    public GameObject rightPunch;
    public GameObject leftPunch;
    public Transform targetPosition;
    public Transform movingGlove;
    public Transform gloveTargetPosition;
    public GameObject tempArm;
    public CameraManager cameraManager;
    public bool isEnemyDie;
    public GenerateArm generateArm;
    public bool nowRemove;
    public bool playerReachedAfterDeath;

    public void Awake()
    {
        Instance = this;
    }

    public void PlayerAnimationPlay(int index)
    {
        playerReachedAfterDeath = false;
        switch (index)
        {
            case 0:
                playerAnimation.SetBool("IsRightPunch",true);
                StartCoroutine(NormalAnimation(0,1));
                break;
            case 1:
                playerAnimation.SetBool("IsLeftPunch",true);
                StartCoroutine(NormalAnimation(1,1));
                break;
            case 2:
                playerAnimation.SetBool("IsMovingForword",true);
                movingGlove.transform.DORotate(new Vector3(0,0,0), 0);
               movingGlove.transform.GetChild(0).gameObject.SetActive(false);
                StartMovingToTargetPoint();
               playerReachedAfterDeath = true;
               // NormalAnimation(2, 0.3f);
                break;
        }
    }

    public IEnumerator NormalAnimation(int index,float animationDelay)
    {
        yield return new WaitForSeconds(animationDelay);
        switch (index)
        {
            case 0:
                playerAnimation.SetBool("IsRightPunch",false);
                break;
            case 1:
                playerAnimation.SetBool("IsLefttPunch",true);
                break;
            case 2:
                playerAnimation.SetBool("IsLanding",true);
                playerAnimation.SetBool("IsMovingForword",false);
                break;
            case 3:
                playerAnimation.SetBool("IsLanding",false);
                break;
        }
        
    }

    public void StartMovingToTargetPoint()
    {
        gameObject.transform.DOMove(targetPosition.position, 0.3f).OnComplete((() =>
        {
            cameraManager.SwitchCamera();
            playerAnimation.SetBool("IsLanding",true);
            playerAnimation.SetBool("IsMovingForword",false);
            generateArm.firstTime = false;
            isEnemyDie = false;
            playerReachedAfterDeath = false;
            movingGlove.transform.DORotate(new Vector3(0,0,0), 0);
           StartCoroutine(NormalAnimation(3, 0.15f));
        }));
    }
    

    public void CurrentPunchOff(int index,bool flag)
    {
        switch (index)
        {
            case 0:
                rightPunch.SetActive(flag);
                if (!flag)
                { 
                    Invoke(nameof(ActiveTempArm),0.15f);
                }
                else
                {
                    DeActiveTempArm();
                }
              
                break;
            case 1:
                leftPunch.SetActive(flag);
                break;
        }
    }

    public void ActiveTempArm()
    {
        tempArm.SetActive(true);
    }
    public void DeActiveTempArm()
    {
        tempArm.SetActive(false);
    }
    public void AssignTargetPosition()
    {
       isEnemyDie = false;
        movingGlove.transform.DOMove(gloveTargetPosition.position, 0);
    }
    
    
}
