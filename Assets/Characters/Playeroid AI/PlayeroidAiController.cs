using FiniteStateAi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayeroidAiController : StateController {

	[Range(0f, 30f)]
	public float viewRadius = 15f;

	private readonly ICollection<GameObject> reactingGameObjects = new HashSet<GameObject>();
	public IReadOnlyCollection<GameObject> ReactingGameObjects => (IReadOnlyCollection<GameObject>)reactingGameObjects;

	private readonly ICollection<GameObject> reactedGameObjects = new HashSet<GameObject>();
	public IReadOnlyCollection<GameObject> ReactedGameObjects => (IReadOnlyCollection<GameObject>)reactedGameObjects;

	public PlayerController player { get; private set; }

	private void Start() {

		player = GetComponent<PlayerController>();
		player.Start();

	}

	private void Update() {

		player.renderer.color = current.color;
		player.StandardUpdate();

	}

	private void FixedUpdate() {

		// Inputs that need to be set (for reference when writing state actions):
		//   player.mouseWorldPosition
		//   player.movement

		ReviewReactedGameObjects();
		current.TriggerUpdateActions(this);
		current.CheckTransitions(this);

		// Execute standard player controller update.
		player.StandardFixedUpdate();

	}

	private bool CheckCanSeeGameObject(GameObject go) {
		// Since players can see through walls, so should the AI.
		// Simple check to see if GameObject is within view radius.
		Vector2 vectorTo = transform.position - go.transform.position;
		return vectorTo.magnitude <= viewRadius;
	}

	private void ReviewUnreactedGameObject(GameObject go) {
		// Throw exception for invalid usage of this method.
		if(reactingGameObjects.Contains(go)) throw new System.InvalidOperationException($"GameObject '{go.name}' has already been reacted to!");
		// Simple logic for adding reacted GameObject.
		if(CheckCanSeeGameObject(go)) StartReactingToGameObject(go);
	}

	private void ReviewReactedGameObjects() {
		// Queue objects to remove, because enumerables cannot be modified during enumeration.
		ICollection<GameObject> removal = new List<GameObject>(reactedGameObjects.Count);
		foreach(var go in reactedGameObjects) if(!CheckCanSeeGameObject(go)) removal.Add(go);
		// Remove objects queued to be removed.
		foreach(var go in removal) reactedGameObjects.Remove(go);
	}

	private void StartReactingToGameObject(GameObject go) {
		// GameObject needs to be added to a collection so that it is not queued to be reacted to twice.
		reactingGameObjects.Add(go);
		// RNJesus uses the current difficulty settings to determine reaction times.
		StaticMonobehaviours.RNJesus.QueueComputerReaction(() => {
			// Move GameObject from 'queued reaction' to 'finished reacton'.
			reactingGameObjects.Remove(go);
			reactedGameObjects.Add(go);
		});
	}

}
