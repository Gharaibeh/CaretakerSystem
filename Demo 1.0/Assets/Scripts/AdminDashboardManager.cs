using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdminDashboardManager : MonoBehaviour
{
    public Text timer;

    public void Update()
    {
        timer.text = System.DateTime.Now.ToString();
    }

    
}
