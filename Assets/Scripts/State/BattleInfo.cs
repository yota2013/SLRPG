using UnityEngine;

public static class BattleInfo{
	public static GameObject camera;
	public static MapChip[,] mapChips;
	public static GameObject map;
	private static Vector3 initPos = new Vector3(0,0,0);

	public static void init(GameObject Camera, MapChip[,] mapchips){
		camera = Camera;
		mapChips = mapchips;
	}
}
