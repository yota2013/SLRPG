using UnityEngine;

public class MapChip {
	private GameObject mapChipObj;
	private bool isCharacter;
	private int spriteNum;
	private int x, y;
    private Vector2 pos;
	public MapChip(int x, int y, GameObject mapchip){
		spriteNum = 0;
		isCharacter = false;
        pos.x = x;
        pos.y = y;
		mapChipObj = mapchip;
	}

	public int getspriteNum(){
		return spriteNum;
	}

    public Vector2 getPosition() {
        return pos;
    }

	public void printState(){
		Debug.Log (this.x+" "+this.y);
	}
}