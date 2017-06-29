using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class BattleManager : MonoBehaviour {
	private Battle bs;

    public Vector2 mapSize;
    [SerializeField]
    Vector3 spawnPos;

    [SerializeField]
    GameObject mapChipPref;
    [SerializeField]
    GameObject charaPref;

    public GameObject tempChara;

    public List<GameObject> charaList;
    public GameObject Map;

    // Use this for initialization
    void Start () {
		BattleInfo.init(this.gameObject,CreateMap(mapSize));
        CreateCharacter(spawnPos);
        bs = new Battle();
	}

	// Update is called once per frame
	void Update () {
		bs.update ();
	}
		
	private MapChip[,] CreateMap(Vector2 mapSize){
        int width = (int)mapSize.x;
        int height = (int)mapSize.y;

        MapChip[,] mapChips = new MapChip[width,height];
		for(int i = 0;i<width;i++){
			for(int j = 0;j<height;j++){
				GameObject temp = Instantiate (mapChipPref,new Vector3(i,j,0),Quaternion.identity);
                temp.transform.parent = Map.transform;
                mapChips[i, j] = new MapChip (i,j,temp);
				
			}
		}
		return mapChips;
	}

    private void CreateCharacter(Vector3 pos) {
        GameObject temp = Instantiate(charaPref, pos, Quaternion.identity);
        tempChara = temp;
        charaList.Add(temp);
    }


}
