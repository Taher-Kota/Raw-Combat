using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUniversal : MonoBehaviour
{
    public float radius;
    public int damage;
    public LayerMask CollisionLayer;
    public GameObject Hit_FX;
    public bool isKick1;
    private SoundUniversal soundUniversal;

    private void Awake()
    {
        soundUniversal = GetComponentInParent<SoundUniversal>();
    }

    void Update()
    {
        CollisionDetection();
    }

    void CollisionDetection()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, CollisionLayer);

        if (hit.Length > 0)
        {
            if (hit[0].gameObject.name == "Enemy")
            {
                Vector3 hit_pos = hit[0].transform.position;
                if (!isKick1)
                {
                    hit_pos.y += 1.5f;
                }
                else
                {
                    hit_pos.y += .35f;
                }

                if (hit[0].transform.forward.x > 0)
                {
                    hit_pos.x += .3f;                    
                }
                else if(hit[0].transform.forward.x < 0)
                {
                    hit_pos.x -= .3f;                    
                }
                Instantiate(Hit_FX, hit_pos, Quaternion.identity);

                if (gameObject.CompareTag(TagManager.Tags.LEFT_ARM_TAG) ||
                    gameObject.CompareTag(TagManager.Tags.LEFT_LEG_TAG)){
                    soundUniversal.Punch3_Sound();
                    hit[0].GetComponent<HealthUniversal>().ApplyDamage(damage, true);
                }
                else
                {
                    soundUniversal.Punch1_Sound();
                    hit[0].GetComponent<HealthUniversal>().ApplyDamage(damage, false);
                }
                gameObject.SetActive(false);
            }

            if (hit[0].gameObject.name == "Player")
            {
                Vector3 hit_pos = hit[0].transform.position;
                hit_pos.y += 1.5f;

                if (hit[0].transform.forward.x > 0)
                {
                    hit_pos.x += .3f;
                }
                else if (hit[0].transform.forward.x < 0)
                {
                    hit_pos.x -= .3f;
                }
                Instantiate(Hit_FX, hit_pos, Quaternion.identity);

                if (gameObject.CompareTag(TagManager.Tags.LEFT_ARM_TAG) ||
                   gameObject.CompareTag(TagManager.Tags.LEFT_LEG_TAG))
                {
                    soundUniversal.Punch3_Sound();
                    hit[0].GetComponent<HealthUniversal>().ApplyDamage(damage, false);
                }
                else
                {
                    hit[0].GetComponent<HealthUniversal>().ApplyDamage(damage, false);
                }

                gameObject.SetActive(false);
            }
        }
    }
}
