using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class AdminController : MonoBehaviour {

    public GameObject redCilrcule;
    public int faultCount;

    public Text faultTime;
    public Text caretakerName;
    public Text faultType;
    public InputField faultComment;

    // Use this for initialization
    void Start () {
        faultCount = -1;


    }
	
	// Update is called once per frame
	public void showAllFaults ()
    {

        foreach (Fault _fault in AppSettings.allFaults)
        {
            Instantiate(redCilrcule , _fault.faultPos , Quaternion.identity);
        }

    }

    public void resetAll()
    {
        Application.LoadLevel(3);
    }
    GameObject TempNode;
    public void showNextFault()
    {
        Destroy(TempNode);
        faultCount++;
        faultCount = faultCount % AppSettings.allFaults.Count;
        previousBtn.interactable = true;

        TempNode = Instantiate(redCilrcule, AppSettings.allFaults[faultCount].faultPos, Quaternion.identity) as GameObject;
        faultComment.text = AppSettings.allFaults[faultCount].faultComment.ToString();
        faultType.text ="Fault type : " + AppSettings.allFaults[faultCount].faultType.ToString();
        faultTime.text = AppSettings.allFaults[faultCount].faultTime.ToString();
        caretakerName.text = AppSettings.allFaults[faultCount].caretakerName.ToString();

    }

    public Button previousBtn, nextBtn;
    public void showPreviousFault()
    {
        Destroy(TempNode);
         faultCount--;
        if(faultCount == -1)
        {

            previousBtn.interactable = false;
            return;
        }
        else
            previousBtn.interactable = true;

        faultCount = faultCount % AppSettings.allFaults.Count;

        TempNode = Instantiate(redCilrcule, AppSettings.allFaults[faultCount].faultPos, Quaternion.identity) as GameObject;
        faultComment.text = AppSettings.allFaults[faultCount].faultComment.ToString();
        faultType.text = "Fault type : " + AppSettings.allFaults[faultCount].faultType.ToString();
        faultTime.text = AppSettings.allFaults[faultCount].faultTime.ToString();
        caretakerName.text = AppSettings.allFaults[faultCount].caretakerName.ToString();

     }












    public void backToMenu()
    {
        Application.LoadLevel(0);
    }
}
