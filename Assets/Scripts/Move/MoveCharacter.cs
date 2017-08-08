using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour {

    private GetOnClickObj getOnClickObj;
    private Coroutine coroutine;
    int[,] moveMap;
    private Vector2 mapSize;


    void Start()
    {
        getOnClickObj = new GetOnClickObj();
        mapSize = GameManager.Instance.mapSize;//インスタンスの変数
    }
    
    IEnumerator Move(GameObject character)
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject obj = getOnClickObj.getGameObj();
                Debug.Log(obj.gameObject.name);
                if (obj.CompareTag("Map"))
                {
                    if (moveMap[(int)obj.transform.position.x, (int)obj.transform.position.y] >= 0)
                    {
                        character.transform.position = obj.transform.position;
                        character.transform.parent = obj.transform;
                        GameManager.Instance.emphasisSprite.DisenableEmphasiss();
                        EndMove();
                        yield break;
                    }
                }

            }
            yield return null;
        }
    }

    void CalculateMove(GameObject chara)
    {
        GameObject[,] mapChips = GameManager.Instance.mapChips;
        moveMap = (int[,])GameManager.Instance.moveMap.Clone();
        int x = (int)chara.transform.position.x;
        int y = (int)chara.transform.position.y;

        moveMap[x, y] = chara.GetComponent<CharacterInfo>().move;
        Search4(moveMap[x, y], x, y);

        List<GameObject> emphasiss = new List<GameObject>();
        emphasiss.Clear();
        for (int i = 0; i < moveMap.GetLength(0); i++)
        {
            for (int j = 0; j < moveMap.GetLength(1); j++)
            {
                if (moveMap[i, j] >= 0)
                {
                    emphasiss.Add(mapChips[i, j]);
                }
            }
        }
        GameManager.Instance.emphasisSprite.EnableEmphasiss(emphasiss);
        for (int i = 0; i < mapSize.x; i++)
        {
            Debug.Log(moveMap[i, 0] + " " + moveMap[i, 1] + " " + moveMap[i, 2] + " " + moveMap[i, 3] + " " + moveMap[i, 4] + " " + moveMap[i, 5] + " " + moveMap[i, 6]);
        }
    }

    void Search4(int canMove,int x, int y)
    {
        if (x - 1 >= 0 && moveMap[x - 1, y] < 0)
        {
            Search(canMove, x - 1, y);
        }
        if (x + 1 < mapSize.x && moveMap[x + 1, y] < 0)
        {
            Search(canMove, x + 1, y);
        }
        if (y - 1 >= 0 && moveMap[x, y - 1] < 0)
        {
            Search(canMove, x, y - 1);
        }
        if (y + 1 < mapSize.y && moveMap[x, y+1] < 0)
        {
            Search(canMove, x, y + 1);
        }
    }

    void Search(int canMove, int x, int y)
    {
        if (canMove + moveMap[x, y] >= 0)
        {
            moveMap[x, y] = canMove + moveMap[x, y];
            Search4(canMove-1, x, y);
        }
    }



    public void StartMove(GameObject character)
    {

        CalculateMove(character);
        coroutine = StartCoroutine(Move(character));
        
    }

    void EndMove()
    {
        StopCoroutine(Move(null));
        GameManager.Instance.isMove = false;    
    }



}
