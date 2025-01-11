using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    public GameObject Enemy;
    EnemyMovement enemyMovement;

    private void Awake()
    {
        enemyMovement = Enemy.GetComponent<EnemyMovement>();
    }
    private void Update()
    {
        Respawn();
    }

    void Respawn()
    {
        if (!Enemy.activeInHierarchy)
        {
            Enemy.transform.position = gameObject.transform.position;
            enemyMovement.enabled = true;
            Enemy.layer = 6;           
            Enemy.SetActive(true);
        }
    }
}
