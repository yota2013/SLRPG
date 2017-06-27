using UnityEngine;

public class MapChip {
	private GameObject mapChipObj;
	private Character character;
	private int spriteNum;
	private int x, y;
	public MapChip(int x,int y,GameObject mapchip){
		spriteNum = 0;
		character = null;
		this.x = x;
		this.y = y;
		mapChipObj = mapchip;
	}

	public int getspriteNum(){
		return spriteNum;
	}

	public void printState(){
		Debug.Log (this.x+" "+this.y);
	}
}