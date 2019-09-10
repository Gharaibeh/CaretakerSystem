using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject model3D;
	// Use this for initialization
	void Start () {
	
	}

    void Update()
    {
        if (model3D)
            model3D.transform.Rotate(0,  Time.deltaTime  * -30, 0);
    }
    
    public GameObject[] allBluePrintBuildings;
    public GameObject[] allClickableBuildings;

    public void onBuildingSelection(GameObject building)
    {
        foreach(GameObject bld in allBluePrintBuildings)
            bld.SetActive(false);
        building.SetActive(true);
        model3D.SetActive(true);

    }
    public void onLevelSelection()
    {
        if (PlayerPrefs.GetString("username") == "Supervisor")
            Application.LoadLevel(3);
        else
            Application.LoadLevel(2);
    }
    public void onBackClicked()
    {
        foreach (GameObject bld in allBluePrintBuildings)
            bld.SetActive(true);

        foreach (GameObject bld in allClickableBuildings)
            bld.SetActive(false);

        model3D.SetActive(false);

    }
}
