using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    PlayerDefence playerDefence;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerDefence = GetComponentInParent<PlayerDefence>();
    }

    public void Walk(bool move)
    {
        anim.SetBool(TagManager.AnimationTags.MOVEMENT, move);
    }

    public void Kick1()
    {
        anim.SetTrigger(TagManager.AnimationTags.KICK_1_TRIGGER);
    }
    
    public void Kick2()
    {
        anim.SetTrigger(TagManager.AnimationTags.KICK_2_TRIGGER);
    }

    public void Punch1()
    {
        anim.SetTrigger(TagManager.AnimationTags.PUNCH_1_TRIGGER);
    }

    public void Punch2()
    {
        anim.SetTrigger(TagManager.AnimationTags.PUNCH_2_TRIGGER);
    }
    
    public void Punch3()
    {
        anim.SetTrigger(TagManager.AnimationTags.PUNCH_3_TRIGGER);
    }

    public void Dead()
    {
        anim.SetTrigger(TagManager.AnimationTags.DEATH_TRIGGER);
    }

    public void Defence()
    {
        anim.SetTrigger(TagManager.AnimationTags.DEFENCE_ANIMATION);
    }

    public void Play_Defence()
    {
        if(playerDefence.isDefend)
        anim.speed = 0f;
    }
}
