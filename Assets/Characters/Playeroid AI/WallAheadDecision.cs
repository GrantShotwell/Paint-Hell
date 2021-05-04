using FiniteStateAi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wall Ahead Decision", menuName = "Finite State AI/Decisions/Playeroid AI/Wall Ahead")]
public class WallAheadDecision : Decision {

	public LayerMask layers;
	public float distance = 0.25f;

	public override bool Decide(StateController controller) {

		var playeroid = controller as PlayeroidAiController;
		if(!playeroid) {
			Debug.LogError($"Cannot use this decision with the '{controller.GetType().Name}' controller!");
			return false;
		}

		var player = playeroid.player;
		Vector2 direction = player.facingRight ? Vector2.right : Vector2.left;
		RaycastHit2D hit = TestWall(player, direction, distance, layers);

		if(hit) {
			return true;
		} else {
			return false;
		}

	}

	protected static RaycastHit2D TestWall(PlayerController player, Vector2 direction, float distance, LayerMask layers) {
		Vector2 origin = (Vector2)player.transform.position + player.collider.offset;
		distance += player.collider.size.x / 2f;
		RaycastHit2D hit = Physics2D.BoxCast(origin, player.collider.size - Vector2.one * Physics2D.defaultContactOffset, 0f, direction, distance, layers.value);
		return hit;
	}

}
