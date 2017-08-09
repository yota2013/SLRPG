using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {

    public MoveCharacter moveCharacter;
    private GetOnClickObj getOnClickObj;
    private Coroutine coroutine;
    int[,] moveMap;
    private Vector2 mapSize;
    bool isMove = true;
    public GameObject nowTurnCharacter;


    void Start()
    {
        getOnClickObj = new GetOnClickObj();
    }
    
    IEnumerator Turn()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject obj = getOnClickObj.getGameObj();
                if (obj != null)
                {
                    if (obj.CompareTag("Map"))
                    {
                        moveCharacter.Move(obj.transform, nowTurnCharacter);
                    }
                    else if (obj.CompareTag("Character"))
                    {

                    }
                }
            }
            yield return null;
        }
        
    }

    public void StartTurn(GameObject character)
    {
        nowTurnCharacter = character;
        moveCharacter.InitializeValue(nowTurnCharacter);
        coroutine = StartCoroutine(Turn());
    }

    public void EndTurn()
    {
        StopCoroutine(Turn());
        GameManager.Instance.emphasisSprite.DisenableEmphasiss();
        GameManager.Instance.isTurn = false;    
    }



}
