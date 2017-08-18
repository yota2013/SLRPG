using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BattleCard : MonoBehaviour
{
	/*メンバ変数： カード種類，ダメージ量，範囲
	メンバ関数：処理の範囲,どういうカードかとう宣言*/

	private enum Cardtype : byte
	{
		NULL,
		Close,
		Long,
		Area,
		Healer,
	};

	Cardtype cardtype;
	[SerializeField] private string _cardtype;
	[SerializeField] private int _amount;
	[SerializeField] private List<Vector2> _range;//local座標
	[SerializeField] private int _delaytime;
	[SerializeField] private int _range_id;

	public int amount
	{
		get{ return _amount;}
		set{ _amount = value;}
	}

	public List<Vector2> range
	{
		get{ return _range;}
		set{ _range = value;}
	}

	public string getCardtypeStr(){
		return cardtype.ToString ();
	}

	public void setCardtype(string value){
		if(value == "NULL" || value == ""){
			value = "Close";
		}
		cardtype = (Cardtype)Enum.Parse(typeof(Cardtype), value);
	}

	public int delaytime
	{
		get{ return _delaytime;}
		set{ _delaytime = value;}
	}

	public int range_id{
		get{ return _range_id;}
		set{ _range_id = value;}
	}

	// Use this for initialization
	//public virtual void DoWork(int i)
	//public override void DoWork(int i)
	public virtual List<Vector2> RangeCreate(Vector2 localPostion)
	{
		return new List<Vector2> ();
	}

	//ローカル座標を代入すると関数起動

}
