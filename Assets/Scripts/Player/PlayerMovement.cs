
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody myBody;
    PlayerAnimation playerAnim;
    private float Min_Xaxix = 1.8f, Max_Xaxix = 10.8f;
    private float Walk_Speed = 2.5f;
    private float Z_Walk_Speed = 1.9f;

    private float Rotation_y = -90f;
    public Transform EnemyTarget;
    PlayerDefence playerDefence;

    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        playerAnim = GetComponentInChildren<PlayerAnimation>();
        playerDefence = GetComponent<PlayerDefence>();
    }
    void Update()
    {
        RotatePlayer();
        WalkAnimation();
    }
    void FixedUpdate()
    {
        DetectMovement();
    }
    void DetectMovement()
    {
        if(playerDefence.isDefend) return;
        myBody.velocity = new Vector3(
            Input.GetAxisRaw(TagManager.Axis.HORIZONTAL_AXIS) *  (-Walk_Speed),
            myBody.velocity.y,
            Input.GetAxisRaw(TagManager.Axis.VERTICAL_AXIS) * (-Z_Walk_Speed));
        float X_Axix = transform.position.x;
        X_Axix = Mathf.Clamp(X_Axix, Min_Xaxix, Max_Xaxix);
        transform.position = new Vector3(X_Axix,transform.position.y, transform.position.z);
    }

    void RotatePlayer()
    {
        if (playerDefence.isDefend) return;
        if (Input.GetAxisRaw(TagManager.Axis.HORIZONTAL_AXIS) > 0)
        {
            transform.rotation = Quaternion.Euler(0f, Rotation_y, 0f);
        }
        else if(Input.GetAxisRaw(TagManager.Axis.HORIZONTAL_AXIS) < 0)
        {
            transform.rotation = Quaternion.Euler(0f,Mathf.Abs(Rotation_y),0f);
        }

        if (Input.GetAxisRaw(TagManager.Axis.VERTICAL_AXIS) > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if(Input.GetAxisRaw(TagManager.Axis.VERTICAL_AXIS) < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 360f, 0f);
        }        
    }

    void WalkAnimation()
    {
        if(Input.GetAxisRaw(TagManager.Axis.HORIZONTAL_AXIS) != 0 || Input.GetAxisRaw(TagManager.Axis.VERTICAL_AXIS) != 0)
        {
            playerAnim.Walk(true);
        }
        else
        {
            playerAnim.Walk(false);
            transform.LookAt(EnemyTarget.position);
        }
    }
}
