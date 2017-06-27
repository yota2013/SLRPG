using UnityEngine;

public class Battle : BattleState{
	public Battle(){
		Debug.Log ("Battle constract");
	}
	public override void update(){
		//Debug.Log ("Battle update");
		GameObject obj = getClickObject ();
		if (obj != null) {
			BattleInfo.camera.transform.position = new Vector3(0,0,-10) + obj.transform.position;
			BattleInfo.mapChips [(int)obj.transform.position.x, (int)obj.transform.position.y].printState ();
		}
	}

	private GameObject getClickObject() {
		　GameObject result = null;
		　// 左クリックされた場所のオブジェクトを取得
		　if(Input.GetMouseButtonDown(0)) {
			　　　Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			　　　Collider2D collition2d = Physics2D.OverlapPoint(tapPoint);
			　　　if (collition2d) {
				　　　　　result = collition2d.transform.gameObject;
				　　　}
			　}
		　return result;
	}
}
