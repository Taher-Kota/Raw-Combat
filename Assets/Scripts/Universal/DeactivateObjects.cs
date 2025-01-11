using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateObjects : MonoBehaviour
{
    void Start()
    {
        Invoke("DeactivateHitEffect",2f);
    }

    void DeactivateHitEffect()
    {
        gameObject.SetActive(false);
    }
}
