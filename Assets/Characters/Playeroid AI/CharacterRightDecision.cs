using FiniteStateAi;
using UnityEngine;

[CreateAssetMenu(fileName = "Character Right Decision", menuName = "Finite State AI/Decisions/Playeroid AI/Character Right")]
public class CharacterRightDecision : CharacterAheadDecision {

	public override bool Decide(StateController controller) {

		var playeroid = controller as PlayeroidAiController;
		if(!playeroid) return LogErrorWrongController(this, controller);

		Vector2 direction = Vector2.right;
		return TestCharacter(playeroid.player, direction, 1f, layers);

	}

}
