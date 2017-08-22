using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ComputationProc
{
	public static class ComputationDamge {
		//，ID:攻撃の種類，TODO:キャラとカードの相性もいる 0 or 1でもOK

		public static short CloseDamage(short opponentHp,short damgeValue,int ID)
		{

			//ここにIDでの変更記述
			short hp = Close (opponentHp,damgeValue);
			return hp;
		}

		static short Close(short opponentHp,short damageValue)
		{
			Debug.Log ("CloseDamage:"+(opponentHp - damageValue));
			return (short)(opponentHp - damageValue);
		}

	}
}