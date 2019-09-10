using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageContractors : MonoBehaviour
{
    public InputField new_contractorName;
    public InputField new_contractorEmail;
    public InputField new_contractorType;
    public InputField new_contractorMobile;

    public InputField update_contractorName;
    public InputField update_contractorEmail;
    public InputField update_contractorType;
    public InputField update_contractorMobile;

     
    public GameObject updateGroup;
    public Dropdown ContractorsList;

    private void Start()
    {
        updateList();
    }

    void updateList()
    {

       // ContractorsList.AddOptions(new List<string> { });
        var options = new List<string>();
        Contractor temp = new Contractor();
        foreach (var user in AppSettings.allContractors)
        {
            options.Add(user.contractorName);
        }
        ContractorsList.AddOptions(options);
    }


    public void addContractor()
    {
        bool ContractorExist = false;
        foreach (var user in AppSettings.allContractors)
        {
            if (user.contractorName == new_contractorName.text)
                ContractorExist = true;
        }
        if (!ContractorExist)
        {
            Contractor temp = new Contractor();
            temp.contractorName = new_contractorName.text;
            temp.contractorType = new_contractorType.text;
            temp.email = new_contractorEmail.text;
            temp.mobile = new_contractorMobile.text;
            AppSettings.allContractors.Add(temp);
         }

         ContractorsList.ClearOptions();
         updateList();

        new_contractorName.text = "";
        new_contractorType.text = "";
        new_contractorEmail.text = "";
        new_contractorMobile.text = "";

    }
    public void updateContractor()
    {
        int index = AppSettings.allContractors.FindIndex(x => x.contractorName == ContractorsList.options[ContractorsList.value].text);
        AppSettings.allContractors.RemoveAt(index);

        Contractor _temp = new Contractor();
        _temp.contractorName = update_contractorName.text;
        _temp.contractorType = update_contractorType.text;
        _temp.email = update_contractorEmail.text;
        _temp.mobile = update_contractorMobile.text;

        AppSettings.allContractors.Add(_temp);
        updateGroup.SetActive(false);
        ContractorsList.ClearOptions();
        updateList();


    }

    public void removeContractor()
    {
        int index = AppSettings.allContractors.FindIndex(x => x.contractorName == ContractorsList.options[ContractorsList.value].text);
        AppSettings.allContractors.RemoveAt(index);

        updateGroup.SetActive(false);
        ContractorsList.ClearOptions();
        updateList();

    }
    public void selectToUpdate()
    {
        updateGroup.SetActive(true);
        int index = AppSettings.allContractors.FindIndex(x => x.contractorName == ContractorsList.options[ContractorsList.value].text);         
        ContractorsList.ClearOptions();
        updateList();
 
        update_contractorName.text = AppSettings.allContractors[index].contractorName;
        update_contractorEmail.text = AppSettings.allContractors[index].email;
        update_contractorType.text = AppSettings.allContractors[index].contractorType;
        update_contractorMobile.text = AppSettings.allContractors[index].mobile;
    }
}
