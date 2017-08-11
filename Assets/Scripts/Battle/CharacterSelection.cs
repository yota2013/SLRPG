using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 自軍出撃キャラ選択
 **/
public class CharacterSelection{

	List<long> selectedCharaList; //キャラリスト
	private const short character_max = 2;

	public IEnumerator SelectCharacter()
	{
		GameManager.Instance.enabled = false;
		Debug.Log ("Select Character");
		Debug.Log ("GUIなし　Push 1 & 2");
		selectedCharaList = new List<long> ();
		//選択処理
		while(true)
		{
			//Listに追加する処理
			if (Input.GetKeyDown ("1")) 
			{
				addCharacter (1345010301L);
			} else if(Input.GetKeyDown ("2"))
			{
				addCharacter (1145010302L);
			}else if(Input.GetKeyDown ("3"))
			{
				addCharacter (1145010302L);
			}else if(Input.GetKeyDown ("4"))
			{
				addCharacter (1023010301L);
			}
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

	private void endSelection()
	{
		
		//GameManager_temp_ito.Instance.moveCharacter = this.gameObject.AddComponent<MoveCharacter> ();
		//キャラ配置*/
		GameManager.Instance.CharacterArrengement(selectedCharaList, true);

		GameManager.Instance.enabled = true;
		Debug.Log ("選択終了");
	}

}
