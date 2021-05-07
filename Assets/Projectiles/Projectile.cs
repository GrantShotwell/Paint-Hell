using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Projectile : MonoBehaviour {

	[Header("Values")]
	public Vector2 velocity;
	public int damage;

	[Header("Events")]
	public UnityEvent<GameObject, Vector2> OnDamage;
	public UnityEvent<GameObject, Vector2> OnBreak;

	[HideInInspector]
	public int team = -1;
	public GameObject creator;

	private void FixedUpdate() {
		transform.position += (Vector3)velocity * Time.fixedDeltaTime;
	}

	void OnTriggerEnter2D(Collider2D collider) {

		if(collider.attachedRigidbody) {
			if(collider.attachedRigidbody.gameObject == creator) return;
		} else {
			if(collider.gameObject == creator) return;
		}

		Projectile projectile = collider.GetComponent<Projectile>();
		if(projectile) {
			if(projectile.team == team) return;
		} else {
			if(collider.isTrigger) return;
		}

		IRespawnable respawnable = collider.GetComponent<IRespawnable>();
		if(respawnable != null) if(team >= 0 && respawnable.team == team) return;

		Healthbar healthbar = collider.GetComponent<Healthbar>();
		if(healthbar) {
			healthbar.Damage(damage, velocity);
			OnDamage.Invoke(collider.gameObject, collider.ClosestPoint(transform.position));
		} else {
			OnBreak.Invoke(collider.gameObject, collider.ClosestPoint(transform.position));
		}

		Destroy(gameObject);

	}

}
