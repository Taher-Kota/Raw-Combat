using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUniversal : MonoBehaviour
{
    public float Health;
    public bool isPlayer, CharacterDied;
    EnemyAnimation enemyAnim;
    PlayerAnimation playerAnim;
    EnemyMovement enemyMovement;
    PlayerMovement playerMovement;
    PlayerAttack playerAttack;
    PlayerDefence playerDefence;
    float DeactivateTimer;
    UIManager UiManager;

    private void Awake()
    {
        enemyMovement = GameObject.Find("Enemy").GetComponent<EnemyMovement>();
        if (gameObject.CompareTag(TagManager.Tags.ENEMY_TAG))
        {
            enemyAnim = GetComponentInChildren<EnemyAnimation>();
            DeactivateTimer = 2.5f;
        }
        if (gameObject.CompareTag(TagManager.Tags.PLAYER_TAG))
        {
            DeactivateTimer = 3f;
            playerAnim = GetComponentInChildren<PlayerAnimation>();
            playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
            playerAttack = GameObject.Find("Player").GetComponent<PlayerAttack>();
            UiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
            playerDefence = GetComponent<PlayerDefence>();
        }
    }

    private void OnEnable()
    {
        if (gameObject.CompareTag(TagManager.Tags.ENEMY_TAG))
        {
            Health = 70f;
            CharacterDied = false;
        }
    }

    public void ApplyDamage(float damage, bool knockdown)
    {
        if (CharacterDied || (isPlayer && playerDefence.isDefend)) return;
        //if (isPlayer && playerDefence.isDefend) return;

        Health -= damage;
        if (isPlayer) UiManager.Health_Display(Health);
        if (Health <= 0)
        {
            CharacterDied = true;
            if (isPlayer)
            {
                playerAnim.Dead();
                enemyMovement.enabled = false;
                playerMovement.enabled = false;
                playerAttack.enabled = false;
                Invoke("DeactivateCharacter", DeactivateTimer);
            }
            else
            {
                enemyAnim.Dead();
                enemyMovement.enabled = false;
                gameObject.layer = 0;
                Invoke("DeactivateCharacter", DeactivateTimer);
            }
        }

        if (!isPlayer)
        {
            if (knockdown)
            {
                if (Random.Range(0, 3) == 1)
                {
                    enemyMovement.PlayerKnocked = true;
                    enemyAnim.KnockDown();
                }
            }
            else
            {
                if (Random.Range(0, 3) >= 1)
                {
                    enemyAnim.Hit();
                }
            }
        }
    }

    void DeactivateCharacter()
    {
        gameObject.SetActive(false);
    }
}
