using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decal : MonoBehaviour {

	private static int currentWallLayer = int.MinValue;
	private static int currentTileLayer = int.MinValue;

	public static int GetNextWallDecalLayer() => currentWallLayer++;

	public static int GetNextTileDecalLayer() => currentTileLayer++;

}
