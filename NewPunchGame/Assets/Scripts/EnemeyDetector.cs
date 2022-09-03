using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyDetector : MonoBehaviour
{
    public Animator currentAnimation;
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.tag = "Untagged";
            other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            currentAnimation = other.gameObject.GetComponent<Animator>();
            currentAnimation.SetBool("IsDead", true);
            var o = other.gameObject;
            PlayerAnimationController.Instance.targetPosition = o.transform;
            PlayerAnimationController.Instance.isEnemyDie = true;
            StartCoroutine(HideEnemyObject(o));
            Invoke(nameof(StartMovingToTarget), 0.2f);
        }
    }

    public IEnumerator HideEnemyObject(GameObject obj)
    {
        yield return new WaitForSeconds(1f);
        obj.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        obj.SetActive(false);
    }
    public void StartMovingToTarget()
    {
        PlayerAnimationController.Instance.PlayerAnimationPlay(2);
    }
}
