using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager> {
	//SerializeField private だけど シーンに表示される
    [SerializeField]
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
		
		CreateMap(mapSize,mapChipPref);
        //キャラ配置
		foreach (GameObject obj in charaPrefList)
        {
            int x = Random.Range(0, (int)mapSize.x);
            int y = Random.Range(0, (int)mapSize.y);
            CreateCharacter(mapChips[x, y], obj);
            moveMap[x, y] = -99; //他のキャラが移動できないように移動コストを99にしている
        }
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



}
