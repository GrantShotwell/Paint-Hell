using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour {

	public Queue<IRespawnable> queue = new Queue<IRespawnable>();
	public Transform waypoint;
	public LayerMask collisionLayers;
	public float maxRaycastDistance = 10f;
	public int obstacles = 0;


	void FixedUpdate() {
		if(obstacles == 0) RespawnSomething();
	}

	void OnTriggerEnter2D(Collider2D collision) {
		obstacles++;
	}

	void OnTriggerExit2D(Collider2D collision) {
		obstacles--;
	}

	public void RespawnSomething() {

		if(queue.Count == 0) return;

		Vector2 waypoint = this.waypoint.position;
		if(Physics2D.Raycast(waypoint, Vector2.down, maxRaycastDistance)) {
			waypoint = Physics2D.Raycast(waypoint, Vector2.down, maxRaycastDistance).point;
		}

		IRespawnable respawnable = queue.Dequeue();
		respawnable.Respawn(waypoint);

	}

}
