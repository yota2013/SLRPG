using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class BattleManager : MonoBehaviour {
	private BattleState bs;
	// Use this for initialization
	void Start () {
		Util.sum (10,8);
		Util2.sum2 (10, 8);
		//Utility.Util.sum (10,8);
		//Utility.Util2.sum2 (10,8);

		BattleInfo.init(this.gameObject,createMap(20,20));
		bs = new Battle();
	}

	// Update is called once per frame
	void Update () {
		bs.update ();
	}
		
	private MapChip[,] createMap(int width,int height){
		GameObject map = new GameObject ("map");
		MapChip[,] mapChips = new MapChip[width,height];
		GameObject mapChip0 = (GameObject)Resources.Load ("GameObj/MapChip");
		for(int i = 0;i<width;i++){
			for(int j = 0;j<height;j++){
				GameObject Temp = (GameObject)Instantiate (mapChip0,new Vector3(i,j,0),Quaternion.identity);
				mapChips[i, j] = new MapChip (i,j,Temp);
				Temp.transform.parent = map.transform;
			}
		}
		return mapChips;
	}

}
