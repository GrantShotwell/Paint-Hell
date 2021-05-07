using FiniteStateAi;
using UnityEngine;

[CreateAssetMenu(fileName = "Wall Right Decision", menuName = "Finite State AI/Decisions/Playeroid AI/Gap Ahead")]
public class GapAheadDecision : Decision {

	public LayerMask layers;

	public override bool Decide(StateController controller) {

		var playeroid = controller as PlayeroidAiController;
		if(!playeroid) return LogErrorWrongController(this, controller);

		Vector2 direction = playeroid.player.facingRight ? Vector2.right : Vector2.left;
		return TestGap(playeroid.player, direction, 1f, layers);

	}

	protected static bool TestGap(PlayerController player, Vector2 direction, float distance, LayerMask layers) {
		Vector2 halfDown = Vector2.down / 2f;
		Vector2 feet = (Vector2)player.transform.position + player.collider.offset - player.collider.size * halfDown;
		return !Physics2D.OverlapBox(feet - halfDown + direction * distance, Vector2.one, 0f, layers.value);
	}

}
