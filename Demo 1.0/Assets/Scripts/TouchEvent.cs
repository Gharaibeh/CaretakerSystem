using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using Hasan;
public class TouchEvent : MonoBehaviour {
 	public Camera HudCam;
	int count;
	Vector2 faultPos;
	Hasan.Touch touch;
	// Use this for initialization
	GameObject redPoint;
	public GameObject redCilrcule;
	bool isDrawing;
	public Text faultTypes;
	public Text faultComment;
	public GameObject pannel;
 	  Fault newFault;

     public Dropdown faultType;
    public InputField faultCommentInputField;


    void Start () {
		isDrawing = false;

        //PlayerPrefs.SetString("date time", (string) DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss").ToString());
        //Debug.Log(PlayerPrefs.GetString("date time"));
    }
    // Update is called once per frame
    void Update () {
		 
		if (!isDrawing) {
			count = Hasan.Input.touchCount;
		
			if (UnityEngine.Input.GetKeyDown (KeyCode.Y))
				AppearMenu ();


			if (count > 0)
			if ((touch.phase == TouchPhase.Began)) 
			if (Hasan.Input.GetTouch (0).phase == TouchPhase.Began) {
				
				var touchPos = Hasan.Input.GetTouch (0).position;
				var createPos = HudCam.ScreenToWorldPoint (touchPos);
				if (createPos.x > -6.0f) {
						faultPos = createPos;

					 redPoint = Instantiate (redCilrcule, new Vector3 (createPos.x, createPos.y, -1), Quaternion.identity) as GameObject;
					AppearMenu ();
					isDrawing = true;
						newFault = new Fault();
						newFault.faultTime = DateTime.Now;
						newFault.faultPos = faultPos;
				}
 			} 
		}
				
	}
    public float floaa;
    public Transform toPosition;
    public Transform originalPosition;
    void AppearMenu()
	{
		iTween.MoveTo (pannel, toPosition.position, 2);
	}


	public void resetPoint()
	{

        faultType.itemText.text = "Door";
         faultCommentInputField.text = "";


        iTween.MoveTo(pannel, originalPosition.position, 2);
        Destroy(redPoint);
		isDrawing = false;

	}



	public void saveFault()
	{
		newFault.caretakerName = PlayerPrefs.GetString("userName");
		newFault.faultType = faultTypes.text;
		newFault.faultComment = faultComment.text;

        AppSettings.allFaults.Add (newFault);


        resetPoint();


    }
    public void backToMenu()
    {
        Application.LoadLevel(0);
    }

			
			
			
		 
	 
}
