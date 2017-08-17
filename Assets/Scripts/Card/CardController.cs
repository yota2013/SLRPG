using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//カードとユーザー(Turunobject)の繋がりを管理するプログラムをここに記述する
//

public class CardController : SingletonMonoBehaviour<CardController>  {

	[SerializeField]  GameManager gameManager = null; 

	void Start () {
		gameManager = GameManager.Instance;

	}

	// Update is called once per frame
	void Update () {
		//Debug.Log (gameManager.nowTurnCharacter);
	}
	//もし，カードを選択したら，NowTurnを更新し，Gardにキャラの位置を渡す．


}
