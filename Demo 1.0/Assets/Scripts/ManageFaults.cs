using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageFaults : MonoBehaviour
{
    public InputField new_fault;
     public InputField update_fault;
     public GameObject updateGroup;
    public Dropdown faultsList;

    private void Start()
    {
        updateList();
    }

    void updateList()
    {

        faultsList.AddOptions(new List<string> { });
        var options = new List<string>();
        foreach (var user in AppSettings.adminFaultsList)
        {
            options.Add(user);
        }
        faultsList.AddOptions(options);
    }


    public void addFault()
    {
        bool FaultTypeExist = false;
        foreach (var user in AppSettings.adminFaultsList)
        {
            if (user == new_fault.text)
                FaultTypeExist = true;
        }
        if (!FaultTypeExist)
            AppSettings.adminFaultsList.Add(new_fault.text);
        faultsList.ClearOptions();
        updateList();

    }

    public void updateFault()
    {
        AppSettings.adminFaultsList.Remove(faultsList.options[faultsList.value].text);
        AppSettings.adminFaultsList.Add(update_fault.text);
        updateGroup.SetActive(false);
        faultsList.ClearOptions();
        updateList();


    }

    public void removeFault()
    {
        AppSettings.adminFaultsList.Remove(update_fault.text);
        updateGroup.SetActive(false);
        faultsList.ClearOptions();
        updateList();

    }
    public void selectToUpdate()
    {
        updateGroup.SetActive(true);
        faultsList.ClearOptions();
        updateList();
        update_fault.text = faultsList.options[faultsList.value].text;
     }
}
