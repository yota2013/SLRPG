using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//GameObject 

public class CloseCard : BattleCard {
	//インスタンス変数 : カード種類，近距離のどのパターンか，量，を引数
	//ペアレントの自分の座標が必要

	public CloseCard(int amount,string cardtype,int range_id)
	{
		this.amount = amount;
		this.range_id = range_id;
		setCardtype(cardtype);
		//this.range = proceesing (range_id);
	}

	//接近の処理を作成 引数：キャラの位置
	public override List<Vector2> RangeCreate(Vector2 localPostion)
	{
		//ローカル座標を保持しておけばよいこれに足せば，それは全体のマップ座標になる
		range_id = this.range_id;

		switch (range_id) 
		{
			//1マス localのポジションを
		case 1:
			Debug.Log ("Range:" + range_id);
			int loop = 0;
			while(loop < 3)
			{
				
			}	
			break;
		}

		return new List<Vector2> ();
	}

}
