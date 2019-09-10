using UnityEngine;
using System.Collections;

public class SQL : MonoBehaviour {

	// Use this for initialization
	void Start () {

		StartCoroutine (updateScore("10154174629653284",456));
		StartCoroutine (updateScore("1153871738001584",687));
		StartCoroutine (updateScore("739471599538438",785));
		StartCoroutine (updateScore("1175988795769601",108));
		StartCoroutine (updateScore("217253462034757",790));
		StartCoroutine (updateScore("1229229257159100",506));
		StartCoroutine (updateScore("1115169615242072",723));
		StartCoroutine (updateScore("10210627244934817",504));
		StartCoroutine (updateScore("557495374456857",789));
		StartCoroutine (updateScore("10211019796113070",630));
		StartCoroutine (updateScore("10154697681864909",127));
		StartCoroutine (updateScore("1765008603823653",763));
		StartCoroutine (updateScore("1700767293566626",222));
		StartCoroutine (updateScore("1212961072121694",555));
		StartCoroutine (updateScore("1844332842463694",887));

	}
	
	IEnumerator updateScore (string userID , int score ) {
		var form = new WWWForm();
		string name = "Hasan Gharaibeh";
		form.AddField("userID", userID);
		form.AddField("score", score);
		form.AddField("FFname", name);

		var www = new WWW("http://127.0.0.1/game1/page1.php", form);
		
		yield return www;

		print (www.text);
	
	}
}
