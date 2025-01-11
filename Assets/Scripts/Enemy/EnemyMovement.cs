
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody myBody;
    EnemyAnimation enemyAnim;
    public Transform PlayerTarget;
    private float speed = 1.8f, AttackDistance = 1.5f ,chase_after_attack = 1f, current_Attack_Time,default_attack_time = 1.5f;
    bool FollowPlayer, CanAttackPlayer;
    public bool PlayerKnocked;
    Animator EnemyAnimator;


    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        enemyAnim = GetComponentInChildren<EnemyAnimation>();
        FollowPlayer = true;
        EnemyAnimator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        current_Attack_Time = default_attack_time;
    }

    private void Update()
    {
        AttackPlayer();
    }
    void FixedUpdate()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (!FollowPlayer) return;

        if (Vector3.Distance(PlayerTarget.position, transform.position) > AttackDistance)
        {
            transform.LookAt(PlayerTarget.position);
            myBody.velocity = transform.forward * speed;

            if(myBody.velocity.sqrMagnitude != 0)
            {
                enemyAnim.Walk(true);
            }
        }
        else 
        {
            enemyAnim.Walk(false);
            FollowPlayer = false;
            CanAttackPlayer = true;
        }
    }

    void AttackPlayer()
    {
        if(!CanAttackPlayer || PlayerKnocked) return;
        transform.LookAt(PlayerTarget.position);
        current_Attack_Time += Time.deltaTime;

        if(current_Attack_Time >= default_attack_time)
        {
            enemyAnim.Attack(Random.Range(0, 3));
            current_Attack_Time = 0f;
            default_attack_time = Random.Range(.5f, 2.5f);            
        }
        if (Vector3.Distance(transform.position, PlayerTarget.position) >= AttackDistance + chase_after_attack)
        {            
            FollowPlayer = true;
            CanAttackPlayer = false;
        }
    }
}
