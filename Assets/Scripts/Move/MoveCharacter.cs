using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour {
    bool isTrigger = true;
    bool nextTrigger = false;
    GetOnClickObj getOnClickObj;

    GameObject character;
    
    // Use this for initialization
    void Start () {

        getOnClickObj = new GetOnClickObj();
    }
	
	// Update is called once per frame
	void Update () {
        if (isTrigger)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject obj = getOnClickObj.getGameObj();
                Debug.Log(obj.gameObject.name);
                if (obj.CompareTag("Map"))
                {
                    character.transform.position = obj.transform.position;
                    character.transform.parent = obj.transform;
                    isTrigger = false;
                    EndMove();
                }
            }
        }
	}

    public void StartMove(GameObject character)
    {
        this.character = character;
        isTrigger = true;
    }

    void EndMove()
    {
        GameManager.Instance.isMove = false;
    }



}
