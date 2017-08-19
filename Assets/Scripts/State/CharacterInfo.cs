using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour {
    
	// default config file
    const string config_dir = "Config/Character";
	const long config_id = 1345010201;

    [SerializeField]
    bool playable;

    Character chara;

	// constructor
	public CharacterInfo(long chara_id){
		InstantiateCharacter (chara_id);
    }

	private void InstantiateCharacter(long id){
//      string json = JsonToString.loadFromFile(config_dir, id.ToString());
//		TODO: specify character ID on instantiate
		string json = JsonToString.loadFromFile("Config/Character", "1345010201");
		chara = JsonUtility.FromJson<Character> (json);
	}

	public string name{
		get{ return chara.name;}
	}

	public long id{
		get{ return chara.id;}
	}

	public short hp{
		get{ return chara.hp;}
		set{ chara.hp = value;}
	}

	public short move{
		get{ return chara.move;}
		set{ chara.move = value;}
	}

	public short speed{
		get{ return chara.speed;}
		set{ chara.speed = value;}
	}

	public short cost{
		get{ return chara.cost;}
		set{ chara.cost = value;}
	}

	public string religion{
		get{ return chara.getReligionStr ();}
	}

	public string attribute{
		get{ return chara.getAttributeStr ();}
	}

    public void setPlayable(bool isPlayable)
    {
        playable = isPlayable; //0が味方，1がAI
    }

    public bool getPlayable()
    {
        return playable;
    }

	void Awake(){
		if (chara == null) {
			InstantiateCharacter (config_id);
		}
	}
}
