using UnityEngine.UI;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class COFeed : MonoBehaviour
{

		public GameObject							content;
		public GameObject							livefeedItemPrefab;
		public float                               livefeedItemHeight;
		public Texture2D[]							photos;
		public Image   								feedtemplate;
		public int									numItems;

		// Use this for initialization
		void Start ()
		{
		StartCoroutine (fun2 ());


		
	}
	public struct UserInfo{

		public   string userName;
		public   string usreFacebookID;
		public   string userScore;

	};
	List <UserInfo>TempList;

	public string[] inform ;
	IEnumerator fun2(){
		
		TempList = new List<UserInfo> ();
		
		WWW url = new WWW("http://127.0.0.1/game1/page2.php");
		yield return url;
		print (url.text);
		inform = url.text.Split("#"[0]);
		
		for (int i=1; i<inform.Length-1; i++) {
			string str1 = inform [i].Substring(0,inform[i].IndexOf('*'));
			string str2 = inform [i].Substring(inform[i].IndexOf('*')+1, inform[i].LastIndexOf('*')-inform[i].IndexOf('*')-1);
			string str3 = inform [i].Substring(inform[i].LastIndexOf('*')+1,inform[i].Length - inform[i].LastIndexOf('*')-1);
			print(str1+"___"+str2+"___"+str3);
			UserInfo uInfo = new UserInfo();
			uInfo.userName = str2;
			uInfo.usreFacebookID = str1;
			uInfo.userScore = str3;

			TempList.Add (uInfo);
			
			
		}
		 numItems = TempList.Count;
		foreach (UserInfo pair in TempList)
			StartCoroutine (fun1 (pair));

		
	}
	IEnumerator fun1(UserInfo T){
		WWW url = new WWW("http" + "://graph.facebook.com/" + T.usreFacebookID + "/picture?type=large");
		yield return url;
 		Texture2D texture = new Texture2D(url.texture.width, url.texture.height, TextureFormat.DXT1, false);
		// assign the downloaded image to sprite
		url.LoadImageIntoTexture(texture);
		Rect rec = new Rect(0, 0, texture.width, texture.height);
		Sprite spriteToUse = Sprite.Create(texture, rec, new Vector2(2.5f, 2.5f), 1000);

		Debug.Log ("AddFeedItem");
		GameObject tempFeedItem = Instantiate (livefeedItemPrefab) as GameObject;
		tempFeedItem.name = "feeditem ";
		//setting parent.
		
		tempFeedItem.transform.parent = content.transform;
		tempFeedItem.transform.localPosition = new Vector3 (0.0f, livefeedItemHeight , 0.0f);
		tempFeedItem.transform.localScale = new Vector3 (2.0f, 2.0f, 1.0f);
		
		//COLivefeedItem livefeedScript = tempFeedItem.GetComponent<COLivefeedItem>();
		
		//Debug.Log("AddFeedItem script");
		
		GameObject newsimageObject = tempFeedItem.transform.Find ("newsimage").gameObject;
		
		Image newsImage = newsimageObject.GetComponent<Image> ();
		
		 
		newsImage.sprite = spriteToUse;
		
		tempFeedItem.transform.Find ("newstext").gameObject.GetComponent<Text> ().text = T.userName;
 
 		tempFeedItem.transform.Find ("score").gameObject.GetComponent<Text> ().text = T.userScore;
		
		url.Dispose();
		url = null;
		
	}
	
		IEnumerator CreateItems ()
		{
				Debug.Log ("CreateItems");
				//Debug.Log (feedtemplate.rectTransform.localScale);
				feedtemplate.rectTransform.localScale = new Vector3 (3f, livefeedItemHeight * numItems, 3f);

				for (int i=0; i<numItems; i++) {
						AddFeedItem (i);
				}

				yield return null;
		}

		private void AddFeedItem (int index)
		{
				Debug.Log ("AddFeedItem");
				GameObject tempFeedItem = Instantiate (livefeedItemPrefab) as GameObject;
				tempFeedItem.name = "feeditem " + index;
				//setting parent.

				tempFeedItem.transform.parent = content.transform;
				tempFeedItem.transform.localPosition = new Vector3 (0.0f, livefeedItemHeight * index, 0.0f);
				tempFeedItem.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);

				//COLivefeedItem livefeedScript = tempFeedItem.GetComponent<COLivefeedItem>();

				//Debug.Log("AddFeedItem script");

				GameObject newsimageObject = tempFeedItem.transform.Find ("newsimage").gameObject;

				Image newsImage = newsimageObject.GetComponent<Image> ();

				Texture2D tempTex = photos [index % 10];
				Sprite tempSprite = Sprite.Create (tempTex, new Rect (0.0f, 0.0f, tempTex.width, tempTex.height), new Vector2 (0.5f, 0.5f));

				newsImage.sprite = tempSprite;

				GameObject statusTextGO = tempFeedItem.transform.Find ("newstext").gameObject;
				Text statusTextLabel = statusTextGO.GetComponent<Text> ();
				statusTextLabel.text = "dummytext" + index;

		}
	
}
