using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character : ISerializationCallbackReceiver{

	[SerializeField] private long _id;
	[SerializeField] private string _name;
	[SerializeField] private string _avatar_path;
	[SerializeField] private short _hp;
	[SerializeField] private short _move;
	[SerializeField] private short _speed;
	[SerializeField] private short _cost;

	private enum Religion : byte{
		NULL,
		Fire,
		Water,
		Wind,
		Light,
		Dark,
	};
	Religion religion;
	[SerializeField] private string _religion;

	private enum Attribute : byte{
		NULL,
		Close,
		Long,
		Area,
		Healer,
	};
	Attribute attribute;
	[SerializeField] private string _attribute;

	// ----------------------------------------------------

	// constructor
	// set default value and these can be overwritten
	public Character(){
		this.id = -1;
		this.name = "";
		this._avatar_path = "";
		this.hp = -1;
		this.move = -1;
		this.speed = -1;
		this.cost = -1;
		this.religion = Religion.NULL;
		this.attribute = Attribute.NULL;
	}

	// callback
	// called after deserialized (JsonUtility.FromJson)
	public void OnAfterDeserialize(){
		
		this.setReligion (_religion);
		this.setAttribute (_attribute);

//		db (); // debug
	}

	// callback
	// caled before serialize (JsonUtility.ToJson)
	public void OnBeforeSerialize(){
	}

	// ----------------------------------------------------
	public string name{
		get{ return _name;}
		private set{ _name = value;}
	}

	public long id{
		get{ return _id;}
		private set{ _id = value;}
	}

	public short hp{
		get{ return _hp;}
		set{ _hp = value;}
	}

	public short move{
		get{ return _move;}
		set{ _move = value;}
	}

	public short speed{
		get{ return _speed;}
		set{ _speed = value;}
	}

	public short cost{
		get{ return _cost;}
		set{ _cost = value;}
	}
		
	public string getReligionStr(){
		return religion.ToString();
	}
	private void setReligion(string value){
		if(value == "null" || value == ""){
			value = "Wind";
		}
		religion = (Religion)Enum.Parse (typeof(Religion), value);
	}

	public string getAttributeStr(){
		return attribute.ToString ();
	}
	private void setAttribute(string value){
		if(value == "null" || value == ""){
			value = "Close";
		}
		attribute = (Attribute)Enum.Parse (typeof(Attribute), value);
	}


	// ----------------------------------------------------

	// debug: list fields
	void db(){
		Debug.Log ("name: " + this.name);

		Debug.Log ("hp: " + this.hp.ToString());

		Debug.Log ("move: " + this.move.ToString());

		Debug.Log ("speed: " + this.speed.ToString());

		if (this._religion == null)
			Debug.Log ("religion: null");
		else Debug.Log ("religion: " + this.getReligionStr());

		if (this._attribute == null)
			Debug.Log ("attribute: null");
		else Debug.Log ("attribute: " + this.getAttributeStr());
	}

	// --- any methods?
	// ・ダメージ補正処理？
}