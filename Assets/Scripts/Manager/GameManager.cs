using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager> {
    [SerializeField]
    MoveCharacter moveCharacter;


    public Vector2 mapSize;
    [SerializeField]
    Vector3 spawnPos;
    [SerializeField]
    GameObject mapChipPref;
    [SerializeField]
    List<GameObject> charaPrefList;
    
    public List<GameObject> charaList;
    public GameObject map;
    public GameObject[,] mapChips;
    public int[,] moveMap;

    public bool isMove = false;

    // Use this for initialization
    void Start()
    {
        CreateMap(mapSize,mapChipPref);
        foreach (GameObject obj in charaPrefList)
        {
            int x = Random.Range(0, (int)mapSize.x);
            int y = Random.Range(0, (int)mapSize.y);
            CreateCharacter(mapChips[x, y], obj);
            moveMap[x, y] = -99;
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


    private GameObject[,] CreateMap(Vector2 mapSize, GameObject mapChip)
    {
        int width = (int)mapSize.x;
        int height = (int)mapSize.y;

        mapChips = new GameObject[width, height];
        moveMap = new int[width, height];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject temp = Instantiate(mapChip, new Vector3(i, j, 0), Quaternion.identity);
                temp.transform.parent = map.transform;
                mapChips[i, j] = temp;
                moveMap[i, j] = temp.GetComponent<NomalMapChip>().getMoveNum();
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
