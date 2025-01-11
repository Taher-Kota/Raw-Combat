using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDefence : MonoBehaviour
{
    PlayerAnimation playerAnim;
    Animator playerAnimator;
    public bool isDefend;
    void Awake()
    {
        playerAnim = GetComponentInChildren<PlayerAnimation>();
        playerAnimator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        Check_Defend();
    }

    void Check_Defend()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerAnim.Defence();
            isDefend = true;
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            isDefend= false;
            playerAnimator.speed = 1f;
        }
    }
}
