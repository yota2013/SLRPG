using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetOnClickObj{
    public GetOnClickObj()
    {
    }

    public GameObject getGameObj()
    {
        GameObject result = null;
        // 左クリックされた場所のオブジェクトを取得
        Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D collition2d = Physics2D.OverlapPoint(tapPoint);
        if (collition2d)
        {
            result = collition2d.transform.gameObject;
        }
        return result;
    }


}
