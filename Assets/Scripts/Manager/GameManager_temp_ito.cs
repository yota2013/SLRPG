using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameManager_temp_ito : SingletonMonoBehaviour<GameManager_temp_ito> {
	//SerializeField private だけど シーンに表示される
	//[SerializeField]
	MoveCharacter moveCharacter;


	public Vector2 mapSize;//マップの大きさ
	[SerializeField]
	Vector3 spawnPos;
	[SerializeField]
	GameObject mapChipPref;//マップのプレハブ
	[SerializeField]
	List<GameObject> charaPrefList; //キャラリスト

	public List<GameObject> charaList;
	public GameObject map; //mapオブジェクトこの下にmapchip生成
	public GameObject[,] mapChips; //mapのオブジェクトが入ってる
	public int[,] moveMap;

	public bool isMove = false;

	// Use this for initialization
	void Start()
	{
		//enabled = false;
		CreateMap(mapSize,mapChipPref);

		StartCoroutine(SelectCharacter());
/*
		moveCharacter = this.gameObject.AddComponent<MoveCharacter> ();
		//キャラ配置
		foreach (GameObject obj in charaPrefList)
		{
			int x = Random.Range(0, (int)mapSize.x);
			int y = Random.Range(0, (int)mapSize.y);
			CreateCharacter(mapChips[x, y], obj);
			moveMap[x, y] = -99; //他のキャラが移動できないように移動コストを99にしている
		}
		enabled = true;
		Debug.Log ("End Start");*/

	}

	// Update is called once per frame
	int i = 0;
	void Update()
	{
		
		if (!isMove)
		{
			if (i == charaList.Count) i = 0;
			moveCharacter.StartMove(charaList[i]);
			i++;
			isMove = true;
		}
	}

	//マップ作成関数
	private GameObject[,] CreateMap(Vector2 mapSize, GameObject mapChip)
	{
		int width = (int)mapSize.x;//横のサイズ
		int height = (int)mapSize.y;//縦のサイズ

		mapChips = new GameObject[width, height];
		moveMap = new int[width, height];//int 配列のサイズ
		//配置
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				GameObject temp = Instantiate(mapChip, new Vector3(i, j, 0), Quaternion.identity);//map生成
				temp.transform.parent = map.transform;//オブジェクトの場所設定
				mapChips[i, j] = temp;//マップの配列を作成
				moveMap[i, j] = temp.GetComponent<NomalMapChip>().getMoveNum();//マップごとに素手に存在している.
			}
		}

		Debug.Log(moveMap[0,0]);
		return mapChips;
	}

	private void CreateCharacter(GameObject mapChip, GameObject character)
	{
		GameObject temp = Instantiate(character, mapChip.transform.position, Quaternion.identity);
		temp.transform.parent = mapChip.transform;
		charaList.Add(temp);
	}

	IEnumerator SelectCharacter()
	{
		enabled = false;
		Debug.Log ("Select Character");
		//選択処理
		while(charaPrefList.Count<3)
		{
			//Listに追加する処理
			if (Input.GetKeyDown ("1")) 
			{
				addCharacter ("1008010301_2");
			} else if(Input.GetKeyDown ("2"))
			{
				addCharacter ("1145010302_27");
			}else if(Input.GetKeyDown ("3"))
			{
				addCharacter ("1145010302_47");
			}else if(Input.GetKeyDown ("4"))
			{
				addCharacter ("1145010302_52");
			}
			EndSelection ();
			yield return null;
		}
		//選択終了
	}

	private void addCharacter(string index)
	{
		GameObject temp = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/ito/"+index+".prefab"); 
		charaPrefList.Add (temp);
		Debug.Log ("Add Character :"+index);
	}

	private void EndSelection()
	{
		if (charaPrefList.Count == 3) {
			moveCharacter = this.gameObject.AddComponent<MoveCharacter> ();
			//キャラ配置
			foreach (GameObject obj in charaPrefList)
			{
				int x = Random.Range(0, (int)mapSize.x);
				int y = Random.Range(0, (int)mapSize.y);
				CreateCharacter(mapChips[x, y], obj);
				moveMap[x, y] = -99; //他のキャラが移動できないように移動コストを99にしている
			}
			enabled = true;
		}
	}
}
