using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionUI : MonoBehaviour {
	[SerializeField]
	GameObject characterSelect;
	List<long> playableCharacter;
	// Use this for initialization
	void Start () 
	{
		playableCharacter = new List<long> ();
		GetPlayableCharacters ();
		CreateSelectableCharacter ();
	}

	public void GetPlayableCharacters()
	{
		//string json = JsonToString.loadFromFile("Config/Character/","playableCharacters");
		//Debug.Log (json);
		playableCharacter.Add(1023010301L);
		playableCharacter.Add(1145010302L);
		playableCharacter.Add(1345010301L);
	}

	public void CreateSelectableCharacter()
	{
		for(int i = playableCharacter.Count;i>0;i--)
		{
			GameObject temp = Instantiate(characterSelect,this.transform.position + new Vector3(100*i,0,0), Quaternion.identity);
			//temp.GetComponent<Image> ().sprite = Resources.Load;
			Sprite[] sp = Resources.LoadAll<Sprite> ("Character/" + playableCharacter[i-1]);
			temp.GetComponent<Image> ().sprite = System.Array.Find<Sprite> (sp,(sprite) => sprite.name.Equals(playableCharacter[i-1]+"_0"));
			temp.transform.parent = this.transform;
		}

	}

	public void addCharacter(GameObject obj)
	{
		GameManager.Instance.characterSelection.addCharacter (obj);
	}


	public void Destroy(){
		Destroy (this.gameObject);
	}

}
