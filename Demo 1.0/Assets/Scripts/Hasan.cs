using UnityEngine;
using System.Collections;



namespace Hasan
{
public class Input
{
	private static Vector2 lastPos;
	private static InputType Type;
	private static Touch tempPos = new Touch();
	private static int framNum = 0;
    public static int touchCount
    {
        get
        {
            if(UnityEngine.Input.touchCount > 0){
            	Type = InputType.MTouch;
            	return UnityEngine.Input.touchCount;
            }else if(UnityEngine.Input.GetMouseButtonDown(0) || UnityEngine.Input.GetMouseButtonDown(1) ||UnityEngine.Input.GetMouseButton(0) || UnityEngine.Input.GetMouseButton(1) || UnityEngine.Input.GetMouseButtonUp(0) || UnityEngine.Input.GetMouseButtonUp(1) ){
            	Type = InputType.Mouse;
                return 1;
            }else {
            	Type = InputType.NoInput;
                return 0;
            }
        }
    }
   
   
    public static Touch GetTouch(int ID)
    {
    	
       
       if(Type == InputType.Mouse){
       
			if(UnityEngine.Input.GetMouseButtonDown(ID)){
				tempPos.phase = UnityEngine.TouchPhase.Began;
				lastPos = (Vector2)UnityEngine.Input.mousePosition;
			}else if(UnityEngine.Input.GetMouseButton(ID))
				tempPos.phase = UnityEngine.TouchPhase.Moved;
			if(UnityEngine.Input.GetMouseButtonUp(ID))
				tempPos.phase = UnityEngine.TouchPhase.Ended;
       
       		if(framNum != UnityEngine.Time.frameCount){
				tempPos.deltaPosition = (Vector2)UnityEngine.Input.mousePosition - lastPos;
       		}
			//tempPos.deltaPosition = new Vector2(UnityEngine.Input.GetAxis ("Mouse X"), UnityEngine.Input.GetAxis ("Mouse Y"));
			tempPos.position = lastPos = UnityEngine.Input.mousePosition;
			

				
			tempPos.fingerId =  ID;
			tempPos.tapCount =  1;
			
		}else if(Type == InputType.MTouch){
			
			tempPos.deltaPosition = UnityEngine.Input.GetTouch(ID).deltaPosition;
			tempPos.position =  UnityEngine.Input.GetTouch(ID).position;
			tempPos.phase =  UnityEngine.Input.GetTouch(ID).phase;	
			tempPos.fingerId =  UnityEngine.Input.GetTouch(ID).fingerId;	
			tempPos.tapCount =  UnityEngine.Input.GetTouch(ID).tapCount;
       	
		}
		framNum = UnityEngine.Time.frameCount;
        return tempPos;
    }

}


public struct Touch
    {
		public Vector2 deltaPosition;
        public Vector2 position;
        public TouchPhase phase;
        public int fingerId;
        public int tapCount;
    }
    
    
public enum InputType
	{
		MTouch,
		Mouse,
		NoInput
	}

}