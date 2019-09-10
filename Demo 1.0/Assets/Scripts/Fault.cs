using UnityEngine;
using System.Collections;

public class Fault : MonoBehaviour {
 
    public enum FaultStatus
    {
        open,
        fixing,
        escalated,
        closed
    }
    public int faultId;
	public System.DateTime faultTime;
    public string buildingNo;
    public string floorNo;
    public string caretakerName;
	public Vector2 faultPos;
	public string faultType;
	public string faultComment;
    public string faultImage;
    public FaultStatus faultStatus;
}
