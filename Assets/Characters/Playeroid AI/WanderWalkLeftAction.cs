using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FiniteStateAi;

[CreateAssetMenu(fileName = "Wander Walk Left", menuName = "Finite State AI/Actions/Playeroid AI/Wander Walk Left")]
public class WanderWalkLeftAction : Action {

	public override void TriggerEnter(StateController controller) {

	}

	public override void TriggerExit(StateController controller) {

	}

	public override void TriggerUpdate(StateController controller) {

		var playeroid = controller as PlayeroidAiController;
		playeroid.player.movement.horizontal = -1f;

	}

}
