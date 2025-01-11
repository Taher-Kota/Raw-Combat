using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComboState
{
    NONE,
    PUNCH1,
    PUNCH2,
    PUNCH3,
    KICK1,
    KICK2,
}
public class PlayerAttack : MonoBehaviour
{
    PlayerAnimation playerAnim;
    ComboState comboState = ComboState.NONE;
    float current_combo_timer;
    float default_combo_timer = .4f;
    bool ResetTimer = false;
    bool CanAttack = true;
    EnemyMovement enemyMovement;
    
    private void Awake()
    {
        playerAnim = GetComponentInChildren<PlayerAnimation>();       
    }

    void Start()
    {
        enemyMovement = GameObject.Find("Enemy").GetComponent<EnemyMovement>();
        current_combo_timer = default_combo_timer;
    }

    void Update()
    {
        if (CanAttack && !enemyMovement.PlayerKnocked)
        {
            ComboAttack();
            ResetCombo();
        }
    }

    void ComboAttack()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (comboState == ComboState.PUNCH3 ||
                comboState == ComboState.KICK1 ||
                comboState == ComboState.KICK2)
                return;

            comboState++;
            ResetTimer = true;
            current_combo_timer = default_combo_timer;

            if (comboState == ComboState.PUNCH1)
            {
                playerAnim.Punch1();
            }
            if (comboState == ComboState.PUNCH2)
            {
                playerAnim.Punch2();
            }
            if (comboState == ComboState.PUNCH3)
            {                
                playerAnim.Punch3();
                StartCoroutine(waitfornextAttack());
            }
        } // for punch

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (comboState == ComboState.KICK2 ||
               comboState == ComboState.PUNCH3)
                return;

            if (comboState == ComboState.NONE ||
                comboState == ComboState.PUNCH1 ||
                comboState == ComboState.PUNCH2)
            {
                comboState = ComboState.KICK1;
            }
            else if (comboState == ComboState.KICK1)
            {
                comboState++;
            }

            ResetTimer = true;
            current_combo_timer = default_combo_timer;

            if (comboState == ComboState.KICK1)
            {
                playerAnim.Kick1();
            }
            if (comboState == ComboState.KICK2)
            {                
                playerAnim.Kick2();
                StartCoroutine(waitfornextAttack());
            }
        }// for kick
    }

    void ResetCombo()
    {
        if (ResetTimer)
        {
            current_combo_timer -= Time.deltaTime;

            if (current_combo_timer < 0)
            {
                ResetTimer = false;
                current_combo_timer = default_combo_timer;
                comboState = ComboState.NONE;                
            }
        }
    }

    IEnumerator waitfornextAttack()
    {
        CanAttack = false;
        yield return new WaitForSeconds(.5f);
        CanAttack = true;        
    }
}
