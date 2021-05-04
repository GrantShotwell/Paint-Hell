using FiniteStateAi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wander Walk Right", menuName = "Finite State AI/Actions/Playeroid AI/Wander Walk Right")]
public class WanderWalkRightAction : Action {

	public override void TriggerEnter(StateController controller) {

	}

	public override void TriggerExit(StateController controller) {

	}

	public override void TriggerUpdate(StateController controller) {

		var playeroid = controller as PlayeroidAiController;
		playeroid.player.movement.horizontal = +1f;

	}

}
