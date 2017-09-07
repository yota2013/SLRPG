using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonMonoBehaviour<GameManager> {

    public EmphasissSprite emphasisSprite;
    public MoveCharacter moveCharacter;
    public FaceUIController faceUIController;


    public Vector2 mapSize;//マップの大きさ
    [SerializeField]
    Vector3 spawnPos;
    [SerializeField]
    GameObject mapChipPref;//マップのプレハブ
    //[SerializeField]
    //List<GameObject> charaPrefList; //キャラリスト
	[SerializeField]
	GameObject charaPref;
	public CharacterSelection characterSelection;
	[SerializeField]
	GameObject characterSelectionUI;
    [SerializeField]
    GameObject UI;

    
    public List<GameObject> charaList;
    public GameObject nowTurnCharacter;
    public GameObject map; //mapオブジェクトこの下にmapchip生成
    public GameObject[,] mapChips; //mapのオブジェクトが入ってる
    public int[,] moveMap;
    
    public bool isTurn = false;

    // Use this for initialization
    void Awake()
    {
		CreateMap(mapSize,mapChipPref);
        //キャラ配置
		//敵軍キャラ選択&配置
		List<long> enemyIndex = new List<long>{1023010301L,1023010301L};
		CharacterArrengement(enemyIndex,false);
		//自軍キャラ選択&配置
		GameObject characterSelectionUITemp = Instantiate(characterSelectionUI, UI.transform.position,Quaternion.identity);
		characterSelectionUITemp.transform.parent = UI.transform;
		characterSelection = new CharacterSelection (characterSelectionUITemp);
		StartCoroutine (characterSelection.SelectCharacter());
    }

    // Update is called once per frame
    int i = 0;
    void Update()
    {
        if (!isTurn)
        {
            StartTurn(charaList[0]);
            isTurn = true;
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
                moveMap[i, j] = temp.GetComponent<NomalMapChip>().getMoveNum();//マップごとに既に存在している.
            }
        }
        
        return mapChips;
    }

	//Playableキャラの配置
	public void CharacterArrengement(List<long> selectedCharacterIndex,bool isPlayable){
		foreach (long index in selectedCharacterIndex)
		{
			int x = Random.Range(0, (int)mapSize.x);
			int y = Random.Range(0, (int)mapSize.y);
			CreateCharacter(mapChips[x, y], index,isPlayable);
		}
	}


    private void CreateCharacter(GameObject mapChip, long index,bool isPlayable)
    {
		//charaPrefはPrefabs/ito/CharaPrefを指定しておいてください
		GameObject temp = Instantiate(charaPref, mapChip.transform.position, Quaternion.identity);
        temp.transform.parent = mapChip.transform;
		temp.GetComponent<CharacterInfo> ().Initialize (index, isPlayable);
        faceUIController.InitializeFaceUI(index, temp);
        charaList.Add(temp);
    }


    public int[,] GetMoveMap(bool charaPlayable)
    {
        int[,] temp = (int[,])moveMap.Clone();
        foreach (GameObject obj in charaList)
        {
            temp[(int)obj.transform.parent.position.x, (int)obj.transform.parent.position.y] = -99;
        }
        return temp;
    }

    

    public void ClickEvent(GameObject obj)
    {
        if (obj.CompareTag("Map"))
        {
            moveCharacter.Move(obj.transform, nowTurnCharacter);
        }
        else if (obj.CompareTag("Character"))
        {
		}
    }
    

    public void StartTurn(GameObject character)
    {
        nowTurnCharacter = character;
        moveCharacter.InitializeValue(nowTurnCharacter);
    }

    public void EndTurn()
    {
        sortCharaList();
        faceUIController.UpdateUI();
        GameManager.Instance.emphasisSprite.DisenableEmphasiss();
        GameManager.Instance.isTurn = false;
    }

    void sortCharaList()
    {
        GameObject temp = charaList[0];
        int i =0;
        for (; i < charaList.Count - 1; i++)
        {
            charaList[i] = charaList[i + 1];
        }
        charaList[i] = temp;
    }
}
