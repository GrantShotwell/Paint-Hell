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
	public Collider2D creator;

	private void FixedUpdate() {
		transform.position += (Vector3)velocity * Time.fixedDeltaTime;
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if(collider == creator) return;

		Projectile projectile = collider.GetComponent<Projectile>();
		if(projectile && projectile.creator == creator) return;

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
