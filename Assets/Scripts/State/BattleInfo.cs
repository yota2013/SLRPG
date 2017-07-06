using UnityEngine;

public static class BattleInfo{
	public static GameObject camera;
	public static NomalMapChip[,] mapChips;
	public static GameObject map;
	private static Vector3 initPos = new Vector3(0,0,0);

	public static void init(GameObject Camera, NomalMapChip[,] mapchips){
		camera = Camera;
		mapChips = mapchips;
	}
}
