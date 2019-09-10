using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public GameObject loadingImage;
	bool isLoading;
 	// Use this for initialization
	void Start () {
	
	}
	
	 void Update()
	{
		if (isLoading)
			loadingImage.transform.Rotate (0,0,-3);
	}

    public InputField usernameInput;
    public InputField passwordInput;
    public void userLogin()
	{
		if (usernameInput.text == "" || passwordInput.text == "")
			return;
		else {
			loadingImage.SetActive(true);
            PlayerPrefs.SetString("username", usernameInput.text);
            PlayerPrefs.SetString("password", passwordInput.text);
            isLoading = true;

			StartCoroutine (startLoading ());
		}
	}
	IEnumerator startLoading()
	{
 		yield return new WaitForSeconds(5);
        if ((PlayerPrefs.GetString("username") == "Supervisor" || PlayerPrefs.GetString("username") == "Caretaker")
            && PlayerPrefs.GetString("password") == "123456")
            Application.LoadLevel(1);
        else
            Application.LoadLevel(Application.loadedLevel);
       
	}
}
