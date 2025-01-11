
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public Image HealthUI;

    public void Health_Display(float value)
    {
        value /= 100;
        if(value < 0)
        {
            value = 0;
        }
        HealthUI.fillAmount = value;
    }
}
