using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AdminLevelManager : MonoBehaviour
{

    public Text timer;
    public void buildingSelection(int i)
    {
        AppSettings.buildingChoice = i;
        // Application.LoadLevel(i + 4);
        
    }
    public void Update()
    {
        timer.text = System.DateTime.Now.ToString();
    }
}
