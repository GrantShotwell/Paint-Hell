using FiniteStateAi;
using UnityEngine;

[CreateAssetMenu(fileName = "Character Left Decision", menuName = "Finite State AI/Decisions/Playeroid AI/Character Left")]
public class CharacterLeftDecision : CharacterAheadDecision {

	public override bool Decide(StateController controller) {

		var playeroid = controller as PlayeroidAiController;
		if(!playeroid) return LogErrorWrongController(this, controller);

		Vector2 direction = Vector2.left;
		return TestCharacter(playeroid.player, direction, 1f, layers);

	}

}
