using UnityEngine;

public class CharacterState {
	private GameObject character;
	private int HP;
	private int move;
	private int AGL;
	private int DEF;

	public CharacterState(int hp,int move,int agl,int def){
		this.HP = hp;
		this.move = move;
		this.AGL = agl;
		this.DEF = def;
	}
}
