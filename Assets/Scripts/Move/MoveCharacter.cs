using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour 
{
    int[,] moveMap;
    private Vector2 mapSize;
	bool isMove = false;
    GameObject beforeParent;
    GameObject nowTurnCharacter;

    void Start()
    {
        mapSize = GameManager.Instance.mapSize;//インスタンスの変数

    }

    public void Move(Transform objTrans, GameObject character)
    {
        if (isMove)
        { 
            if (moveMap[(int)objTrans.position.x, (int)objTrans.position.y] >= 0)
            {
                beforeParent = character.transform.parent.gameObject;
                character.transform.position = objTrans.position;
                character.transform.parent = objTrans;
                GameManager.Instance.emphasisSprite.DisenableEmphasiss();
                isMove = false;
            }
        }
    }

    public void CalculateMoveMap(GameObject character)
    {
        GameObject[,] mapChips = GameManager.Instance.mapChips;
        moveMap = GameManager.Instance.GetMoveMap(character.GetComponent<CharacterInfo>().getPlayable());
        int x = (int)character.transform.position.x;
        int y = (int)character.transform.position.y;

        moveMap[x, y] = character.GetComponent<CharacterInfo>().move;
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
    }


    void Search4(int canMove, int x, int y)
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
        if (y + 1 < mapSize.y && moveMap[x, y + 1] < 0)
        {
            Search(canMove, x, y + 1);
        }
    }

    void Search(int canMove, int x, int y)
    {
        if (canMove + moveMap[x, y] >= 0)
        {
            moveMap[x, y] = canMove + moveMap[x, y];
            Search4(canMove - 1, x, y);
        }
    }


    public void InitializeValue(GameObject character)
    {
        nowTurnCharacter = character;
        beforeParent = character.transform.parent.gameObject;
        
		CalculateMoveMap(character);//計算の移動 計算とマスを光らしている．　ボタンにしたい
	    isMove = true;
    }
		

    public void ReturnMove()
    {
        nowTurnCharacter.transform.position = beforeParent.transform.position;
        nowTurnCharacter.transform.parent = beforeParent.transform;
        GameManager.Instance.emphasisSprite.DisenableEmphasiss();
        InitializeValue(nowTurnCharacter);
    }

	public void DebugOnclick()
	{
		//Debug.Log (isMove);
		if (isMove == false)
		{
			isMove = true;
			CalculateMoveMap (nowTurnCharacter);
		}
		else if (isMove ==true) 
		{
			isMove = false;
			GameManager.Instance.emphasisSprite.DisenableEmphasiss();
		}
		//Debug.Log ("after"+isMove);
	}


}
