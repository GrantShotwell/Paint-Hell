using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector2Random {

	public static Vector2 NormalVector() {
		float angle = Random.Range(0, 2 * Mathf.PI);
		return new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));
	}

	public static Vector2 NormalVector(out float angle) {
		angle = Random.Range(0, 2 * Mathf.PI);
		return new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));
	}

	public static Vector2 AngledOffset(Vector2 original, float negAngle, float posAngle) {
		float angle = Random.Range(negAngle, posAngle) * Mathf.Deg2Rad + Mathf.Atan2(original.y, original.x);
		return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * original.magnitude;
	}

	public static Vector2[] AngledOffsetArray(Vector2 original, float negAngle, float posAngle, int count) {
		Vector2[] array = new Vector2[count];
		for(int i = 0; i < count; i++) array[i] = AngledOffset(original, negAngle, posAngle);
		return array;
	}

}
