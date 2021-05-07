using FiniteStateAi;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayeroidAiController : StateController {

	[Range(0f, 30f)]
	public float viewRadius = 15f;

	private readonly HashSet<GameObject> reactingGameObjects = new HashSet<GameObject>();
	private readonly HashSet<GameObject> reactedGameObjects = new HashSet<GameObject>();

	public PlayerController player { get; private set; }

	private void Start() {

		player = GetComponent<PlayerController>();
		player.Start();

	}

	private void Update() {

		//player.color = current.color;
		player.StandardUpdate();

	}

	private void FixedUpdate() {

		// Inputs that need to be set (for reference when writing state actions):
		//   player.mouseWorldPosition
		//   player.movement

		current.TriggerUpdateActions(this);
		current.CheckTransitions(this);

		float distance = float.PositiveInfinity;
		bool targetedSomething = false;
		foreach(GameObject gameObject in reactedGameObjects) {
			PlayerController player = gameObject.GetComponent<PlayerController>();
			float d = Vector2.Distance(transform.position, player.transform.position);
			if(this.player.team != player.team && d < distance) {
				distance = d;
				this.player.mouseWorldPosition = (Vector2)player.transform.position + new Vector2(0f, player.collider.size.y / 2f);
				targetedSomething = true;
			}
		}

		if(targetedSomething && player.CanFirePrimary()) {
			player.FirePrimary();
		}

		// Execute standard player controller update.
		player.StandardFixedUpdate();

	}

	private void OnTriggerEnter2D(Collider2D collider) {
		GameObject gameObject = collider.attachedRigidbody.gameObject;
		if(!reactingGameObjects.Contains(gameObject) && !reactedGameObjects.Contains(gameObject)) {
			if(WillReactTo(gameObject)) StartReactingToGameObject(gameObject);
		}
	}

	private void OnTriggerExit2D(Collider2D collider) {
		GameObject gameObject = collider.attachedRigidbody.gameObject;
		reactedGameObjects.Remove(gameObject);
		reactingGameObjects.Remove(gameObject);
	}

	/// <summary>
	/// Tests if <paramref name="gameObject"/> is something the AI considers worth tracking.
	/// </summary>
	/// <param name="gameObject">The <see cref="GameObject"/> to test.</param>
	/// <returns>Returns <see langword="true"/> if the AI will track this object.</returns>
	public bool WillReactTo(GameObject gameObject) {
		if(gameObject.GetComponentInParent<PlayerController>()) return true;
		return false;
	}

	private void StartReactingToGameObject(GameObject gameObject) {
		// GameObject needs to be added to a collection so that it is not queued to be reacted to twice.
		reactingGameObjects.Add(gameObject);
		// RNJesus uses the current difficulty settings to determine reaction times.
		StaticMonobehaviours.RNJesus.QueueComputerReaction(() => {
			// Make sure object is still 'reacting' (not deleted or out of view circle).
			// Move GameObject from 'queued reaction' to 'finished reacton'.
			bool reacting = reactingGameObjects.Remove(gameObject);
			if(reacting) reactedGameObjects.Add(gameObject);
		});
	}

}
