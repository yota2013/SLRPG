using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmphasissSprite : MonoBehaviour 
{
    const float EARLINESS = 0.005f;
    int direction = 1;
    float col = 0.5f;
    List<GameObject> emphasissObj;
    bool isTrigger = false;


    void Update()
    {
        if (isTrigger)
        {
            col += EARLINESS * direction;
            if (col >= 0.7f)
            {
                direction = -1;
            }
            if (col <= 0.5f)
            {
                direction = 1;
            }

            foreach(GameObject obj in emphasissObj)
            {
                obj.GetComponent<SpriteRenderer>().color = new Color(col, col, col, 1);
            }
        }
    }

    public void EnableEmphasiss(List<GameObject> obj)
    {
        if (isTrigger)
        {
            DisenableEmphasiss();
        }
        isTrigger = true;
        emphasissObj = obj;
    }

		
	//onecolor にする関数
	public void OneColorEmphasiss(List<GameObject> oneEmphasissObj)
	{
		
		foreach ( GameObject obj in oneEmphasissObj )
		{
			//Debug.Log ();
			if(emphasissObj.Contains(obj))
			{
				emphasissObj.Remove (obj);
				//Debug.Log ("ある");
			}
			obj.GetComponent<SpriteRenderer>().color = new Color(0.7f, 0.0f, 0.0f, 1);
		}
	}

    public void DisenableEmphasiss()
    {
        foreach (GameObject obj in emphasissObj)
        {
            obj.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1);
        }
        isTrigger = false;
    }
		
}
