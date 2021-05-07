using FiniteStateAi;
using UnityEngine;

[CreateAssetMenu(fileName = "Character Ahead Decision", menuName = "Finite State AI/Decisions/Playeroid AI/Character Ahead")]
public class CharacterAheadDecision : Decision {

	public LayerMask layers;
	public float distance = 0.25f;

	public override bool Decide(StateController controller) {

		var playeroid = controller as PlayeroidAiController;
		if(!playeroid) return LogErrorWrongController(this, controller);

		Vector2 direction = playeroid.player.facingRight ? Vector2.right : Vector2.left;
		return TestCharacter(playeroid.player, direction, 1f, layers);

	}

	protected static bool TestCharacter(PlayerController player, Vector2 direction, float distance, LayerMask layers) {
		Vector2 origin = (Vector2)player.transform.position + player.collider.offset;
		distance += player.collider.size.x / 2f;
		RaycastHit2D hit = Physics2D.BoxCast(origin, player.collider.size - Vector2.one * Physics2D.defaultContactOffset, 0f, direction, distance, layers.value);
		return hit;
	}

}
