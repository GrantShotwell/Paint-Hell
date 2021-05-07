using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FiniteStateAi;

[CreateAssetMenu(fileName = "Wall Left Decision", menuName = "Finite State AI/Decisions/Playeroid AI/Wall Left")]
public class WallLeftDecision : WallAheadDecision {

	public override bool Decide(StateController controller) {

		var playeroid = controller as PlayeroidAiController;
		if(!playeroid) return LogErrorWrongController(this, controller);

		var player = playeroid.player;
		Vector2 direction = Vector2.left;
		return TestWall(player, direction, distance, layers);

	}

}
