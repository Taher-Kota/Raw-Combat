using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPointsOnOff : MonoBehaviour
{
    public GameObject Left_Hand, Right_Hand , Left_Leg , Right_Leg;
    
    public void Left_Hand_On()
    {
        Left_Hand.SetActive(true);
    } 
    public void Left_Hand_Off()
    {
        if (Left_Hand.activeInHierarchy)
        {
            Left_Hand.SetActive(false);
        }        
    }

    public void Right_Hand_On()
    {
        Right_Hand.SetActive(true);
    }
    public void Right_Hand_Off()
    {
        if (Right_Hand.activeInHierarchy)
        {
            Right_Hand.SetActive(false);
        }
    }

    public void Left_Leg_On()
    {
        Left_Leg.SetActive(true);
    }
    public void Left_Leg_Off()
    {
        if (Left_Leg.activeInHierarchy)
        {
            Left_Leg.SetActive(false);
        }
    }

    public void Right_Leg_On()
    {
        Right_Leg.SetActive(true);
    }
    public void Right_Leg_Off()
    {
        if (Right_Leg.activeInHierarchy)
        {
            Right_Leg.SetActive(false);
        }
    }

    public void Tag_LeftArm()
    {
        Left_Hand.tag = TagManager.Tags.LEFT_ARM_TAG;
    }
    public void UnTag_LeftArm()
    {
        Left_Hand.tag = TagManager.Tags.UNTAGGED_TAG;
    }

    public void Tag_LeftLeg()
    {
        Left_Leg.tag = TagManager.Tags.LEFT_LEG_TAG;
    }
    public void UnTag_LeftLeg()
    {
        Left_Leg.tag = TagManager.Tags.UNTAGGED_TAG;
    }
}
