using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour {

    private GetOnClickObj getOnClickObj;
    private Coroutine coroutine;
    private int[,] moveMap;
    private Vector2 mapSize;


    void Start()
    {
        getOnClickObj = new GetOnClickObj();
        mapSize = GameManager.Instance.mapSize;
    }
    
    IEnumerator Move(GameObject character)
    {
        CalculateMove(character);
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
        moveMap = (int[,])GameManager.Instance.moveMap.Clone();
        int x = (int)chara.transform.position.x;
        int y = (int)chara.transform.position.y;
        moveMap[x, y] = chara.GetComponent<CharacterInfo>().move;
        Search4(moveMap[x, y], x, y);
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
        coroutine = StartCoroutine(Move(character));
    }

    void EndMove()
    {
        StopCoroutine(Move(null));
        GameManager.Instance.isMove = false;    
    }



}
