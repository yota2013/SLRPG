using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour {
    public int HP;
    public int move;
    public int AGL;
    public int DEF;

    public CharacterInfo(int hp, int move, int agl, int def)
    {
        this.HP = hp;
        this.move = move;
        this.AGL = agl;
        this.DEF = def;
    }

	 
}
