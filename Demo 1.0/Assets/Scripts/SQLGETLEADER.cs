using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SQLGETLEADER : MonoBehaviour {

	public Image profilePic;
	// Use this for initialization
	void Start () {
		StartCoroutine (fun2 ());
	}
	IEnumerator fun1(){
		WWW url = new WWW("http" + "://graph.facebook.com/" + "100000856506709" + "/picture?type=large");
		yield return url;
		print (url.text);
		Texture2D texture = new Texture2D(url.texture.width, url.texture.height, TextureFormat.DXT1, false);
		// assign the downloaded image to sprite
		url.LoadImageIntoTexture(texture);
		Rect rec = new Rect(0, 0, texture.width, texture.height);
		Sprite spriteToUse = Sprite.Create(texture, rec, new Vector2(2.5f, 2.5f), 1000);
		profilePic.sprite = spriteToUse;
 
		url.Dispose();
		url = null;
	
	}


	Dictionary <string,string>TempList;
	public string[] inform ;
	IEnumerator fun2(){
		
		TempList = new Dictionary<string, string> ();
		
		WWW url = new WWW("http://127.0.0.1/game1/page2.php");
		yield return url;
		print (url.text);
		inform = url.text.Split("#"[0]);
		
		for (int i=1; i<inform.Length-1; i++) {
			string str1 = inform [i].Substring(0,inform[i].IndexOf('*'));
			string str2 = inform [i].Substring(inform[i].IndexOf('*')+1,inform[i].Length - inform[i].IndexOf('*')-1);
			print(str1+"    "+str2);
			TempList.Add (str1 , str2);
			
			
		}
		
	}
	
	
	
}
