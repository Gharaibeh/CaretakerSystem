using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageCases : MonoBehaviour
{
    public Dropdown contractorList;
    public InputField contractor_email;
    public InputField case_details;

    public SendCaseContractor _send;
    private void Start()
    {
       fillUpList();
    }

    void fillUpList()
    {

        contractorList.AddOptions(new List<string> { });
        var options = new List<string>();
        foreach (var user in AppSettings.allContractors)
        {
            options.Add(user.contractorName);
        }
        contractorList.AddOptions(options);

    }



    public void selectToUpdate()
    {
        int index = AppSettings.allContractors.FindIndex(x => x.contractorName == contractorList.options[contractorList.value].text);
        contractor_email.text = AppSettings.allContractors[index].email;
    }
    public void SendBtn()
    {
        _send.sendReport(contractorList.options[contractorList.value].text, case_details.text , contractor_email.text);
    }
}
