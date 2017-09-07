using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceUIController : MonoBehaviour {
    [SerializeField]
    GameObject facePref;
    [SerializeField]
    List<GameObject> faceUIParent;
    [SerializeField]
    Text statusText;

    GameManager gameManager;


    public void InitializeFaceUI(long index, GameObject chara)
    {
        if (gameManager == null) gameManager = GameManager.Instance;
        GameObject tempFace = Instantiate(facePref, faceUIParent[gameManager.charaList.Count].transform.position, Quaternion.identity);
        tempFace.gameObject.transform.parent = faceUIParent[gameManager.charaList.Count].transform;
        Sprite image = Resources.Load<Sprite>("CharacterFace/" + index);
        tempFace.GetComponent<Image>().sprite = image;
        FaceUIParentColor(chara.GetComponent<CharacterInfo>().getPlayable(), gameManager.charaList.Count);

        if (gameManager.charaList.Count == 1) DisplayStatus(gameManager.charaList[0]);

        chara.GetComponent<CharacterInfo>().faceUI = tempFace;
    }

    void FaceUIParentColor(bool playable, int num)
    {
        if (playable)
        {
            faceUIParent[num].GetComponent<Image>().color = new Color(0, 0, 255, 1);
        }
        else
        {
            faceUIParent[num].GetComponent<Image>().color = new Color(255, 0, 0, 1);
        }
    }
        
    public void UpdateUI()
    {
        for(int i = 0; i < gameManager.charaList.Count; i++) {
            if (i == 0) DisplayStatus(gameManager.charaList[i]);
            GameObject obj = gameManager.charaList[i].GetComponent<CharacterInfo>().faceUI;
            obj.gameObject.transform.parent = faceUIParent[i].transform;
            obj.transform.position = obj.transform.parent.position;
            FaceUIParentColor(gameManager.charaList[i].GetComponent<CharacterInfo>().getPlayable(), i);

        }

    }

    void DisplayStatus(GameObject chara)
    {
        statusText.text = "HP : "+chara.GetComponent<CharacterInfo>().hp.ToString();
    }
}
