using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupEnabelerDisabler : MonoBehaviour
{
    public GameObject[] enableGroup;
    public GameObject[] disableGroup;

    public GameObject leftBtn;
    public Color onReleaseColor;
    public Color onClickColor;
    bool pressed;
    public void enableObjecs()
    {
        pressed = !pressed;

        if (pressed)
        {
            leftBtn.GetComponent<Image>().color = onClickColor;
            foreach (GameObject obj in enableGroup)
            {
                obj.SetActive(true);
            }
        }

        if (!pressed) {
            leftBtn.GetComponent<Image>().color = onReleaseColor;
            foreach (GameObject obj in enableGroup)
            {
                obj.SetActive(false);
            }
        }
    }
     

}
