using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
 * 自軍出撃キャラ選択
 **/
public class CharacterSelection{

	List<long> selectedCharaList; //キャラリスト
	private const short character_max = 2;
	private GameObject UIobj;
	public CharacterSelection(GameObject UI){
		UIobj = UI;
	}

	public IEnumerator SelectCharacter()
	{
		GameManager.Instance.enabled = false;
		Debug.Log ("Select Character");
		selectedCharaList = new List<long> ();
		//選択処理
		while(true)
		{
			if (selectedCharaList.Count == character_max) {
				endSelection ();
				yield break;
			}
			yield return null;
		}
	}

	public void addCharacter(long index)
	{ 
		if (!selectedCharaList.Contains (index)) 
		{
			selectedCharaList.Add (index);
			Debug.Log ("Add Character :"+index);
		}
	}

	public void addCharacter(GameObject obj)
	{
		Image img = obj.GetComponent<Image> ();
		//Color color = img.GetComponent<Color> ();
		Debug.Log(img.sprite.name.Split ('_') [0]);
		long index = long.Parse(img.sprite.name.Split ('_') [0]);
		
		if (!selectedCharaList.Contains (index)) {
			selectedCharaList.Add (index);
			Debug.Log ("Add Character :" + index);
			//color.a = 0.5f;
		} else {
			selectedCharaList.Remove (index);
			//color.a = 1.0f;
		}
		//img.color = color;
	}

	private void endSelection()
	{
		
		//GameManager_temp_ito.Instance.moveCharacter = this.gameObject.AddComponent<MoveCharacter> ();
		//キャラ配置*/
		GameManager.Instance.CharacterArrengement(selectedCharaList, true);

		GameManager.Instance.enabled = true;

		UIobj.GetComponent<CharacterSelectionUI> ().Destroy ();

		Debug.Log ("選択終了");
	}

}
