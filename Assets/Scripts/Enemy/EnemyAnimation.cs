using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator anim;
    private EnemyMovement enemyMovement;
    CameraShake cameraShake;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyMovement = GetComponentInParent<EnemyMovement>();
        cameraShake = GameObject.FindWithTag(TagManager.Tags.MAIN_CAMERA_TAG).GetComponent<CameraShake>();
    }

    public void Attack(int attack)
    {
        if (attack == 0)
        {
            anim.SetTrigger(TagManager.AnimationTags.ATTACK_1_TRIGGER);
        }
        else if (attack == 1)
        {
            anim.SetTrigger(TagManager.AnimationTags.ATTACK_2_TRIGGER);
        }
        else
        {
            anim.SetTrigger(TagManager.AnimationTags.ATTACK_3_TRIGGER);
        }
    }

    public void Idle()
    {
        anim.Play(TagManager.AnimationTags.IDLE_ANIMATION);
    }

    public void Walk(bool move)
    {
        anim.SetBool(TagManager.AnimationTags.MOVEMENT , move);
    }

    public void Hit()
    {
        anim.SetTrigger(TagManager.AnimationTags.HIT_TRIGGER);
    }

    public void KnockDown()
    {
        anim.SetTrigger(TagManager.AnimationTags.KNOCK_DOWN_TRIGGER );
    }

    public void StandUp() 
    {
        anim.SetTrigger(TagManager.AnimationTags.STAND_UP_TRIGGER);
    }

    public void Dead()
    {
        anim.SetTrigger(TagManager.AnimationTags.DEATH_TRIGGER);
    }

    public void PlayerKnocked()
    {
        enemyMovement.PlayerKnocked = false;       
    }
   
    public IEnumerator StandUPTimer()
    {
        yield return new WaitForSeconds(1.5f);
        StandUp();
    }

    public void ShakeCamera()
    {
        cameraShake.ShakeCamera = true;
    }
}
