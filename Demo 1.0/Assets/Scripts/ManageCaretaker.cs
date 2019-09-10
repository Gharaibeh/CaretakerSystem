using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageCaretaker : MonoBehaviour
{
    public InputField new_username;
    public InputField new_password;
    public InputField update_username;
    public InputField update_password;
    public GameObject updateGroup;
    public Dropdown caretakersList;

    private void Start()
    {
        updateList();
    }

    void updateList()
    {

        caretakersList.AddOptions(new List<string> { });
        var options = new List<string>();
        foreach (var user in AppSettings.caretakers.Keys)
        {
            options.Add(user);
        }
        caretakersList.AddOptions(options);
    }


    public void addCaretaker()
    {
        bool userExist = false;
        foreach (var user in AppSettings.caretakers.Keys)
        {
            if (user == new_username.text)
                userExist = true;
        }
        if (!userExist)
            AppSettings.caretakers.Add(new_username.text, new_password.text);
        caretakersList.ClearOptions();
        updateList();

    }

    public void updateCaretaker()
    {
        AppSettings.caretakers.Remove(caretakersList.options[caretakersList.value].text);
        AppSettings.caretakers.Add(update_username.text, update_password.text);
        updateGroup.SetActive(false);
        caretakersList.ClearOptions();
        updateList();
       

    }

    public void removeCaretaker()
    {
        AppSettings.caretakers.Remove(update_username.text);
        updateGroup.SetActive(false);
        caretakersList.ClearOptions();
        updateList();
       
    }
    public void selectToUpdate()
    {
        updateGroup.SetActive(true);
        caretakersList.ClearOptions();
        updateList();
        update_username.text = caretakersList.options[caretakersList.value].text;
        update_password.text = AppSettings.caretakers[caretakersList.options[caretakersList.value].text];
    }
}
