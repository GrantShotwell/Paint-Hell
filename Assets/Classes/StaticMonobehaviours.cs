using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticMonobehaviours {

	private static RNJesus rnJesus;

	public static RNJesus RNJesus {
		get {
			if(rnJesus) return rnJesus;
			else throw new UnassignedReferenceException($"Monobehaviour '{nameof(RNJesus)}' has not been set!");
		}
		set => rnJesus = value;
	}


}
