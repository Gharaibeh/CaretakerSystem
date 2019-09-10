using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStatus : MonoBehaviour
{
    public GameObject[] disableBtn;
    public GameObject[] enableBtn;
    bool status;
    public void ButtonEnabler()
    {
        foreach (GameObject btn in disableBtn)
            btn.SetActive(status);

        foreach (GameObject btn in enableBtn)
            btn.SetActive(!status);

        status = !status;

    }
}
