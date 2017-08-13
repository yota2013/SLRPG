using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTest : MonoBehaviour {
    GameObject[,] mapchips;
    List<GameObject> attackEria;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AttackErea()
    {
        GameObject character = GameManager.Instance.nowTurnCharacter;
        int centerX = (int)character.transform.parent.position.x;
        int centerY = (int)character.transform.parent.position.y;
        mapchips = GameManager.Instance.mapChips;
        attackEria = new List<GameObject>();
        if (centerX - 1 >= 0)
        {
            attackEria.Add(mapchips[centerX - 1, centerY]);
        }
        if(centerX + 1 < mapchips.GetLength(0))
        {
            attackEria.Add(mapchips[centerX + 1, centerY]);
        }
        if (centerY -1 >= 0)
        {
            attackEria.Add(mapchips[centerX, centerY - 1]);
        }
        if (centerY + 1 < mapchips.GetLength(1))
        {
            attackEria.Add(mapchips[centerX, centerY + 1]);
        }

        GameManager.Instance.emphasisSprite.EnableEmphasiss(attackEria);
    }
}
