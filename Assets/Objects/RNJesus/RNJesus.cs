using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RNJesus : MonoBehaviour {

	[SerializeField]
	private DifficultySettings difficultySettings;

	public DifficultySettings DifficultySettings { get => difficultySettings; set => difficultySettings = value; }

	private LinkedList<(Action Action, float TriggerTime)> QueuedReactions { get; } = new LinkedList<(Action Action, float TriggerTime)>();


	void Awake() {
		StaticMonobehaviours.RNJesus = this;
	}

	void Start() {
		
	}

	void Update() {
		CheckQueuedReactions();
	}

	void FixedUpdate() {
		
	}


	private void CheckQueuedReactions() {
		float time = Time.inFixedTimeStep ? Time.fixedTime : Time.time;
		var current = QueuedReactions.First;
		while(current != null) {
			var reaction = current.Value;
			if(reaction.TriggerTime <= time) {
				reaction.Action.Invoke();
				var last = current;
				current = current.Next;
				QueuedReactions.Remove(last);
			} else {
				current = current.Next;
			}
		}
	}

	public void QueueComputerReaction(Action action) {
		float time = Time.inFixedTimeStep ? Time.fixedTime : Time.time;
		float delay = DifficultySettings.ReactionTimeSettings.GetComputerReactionDelay();
		QueuedReactions.AddLast((action, time + delay));
	}

	public void QueueComputerReaction(Action action, float multiplier) {
		float time = Time.inFixedTimeStep ? Time.fixedTime : Time.time;
		float delay = DifficultySettings.ReactionTimeSettings.GetComputerReactionDelay();
		QueuedReactions.AddLast((action, time + delay * multiplier));
	}

	public void QueueComputerReaction(Action action, int offset) {
		float time = Time.inFixedTimeStep ? Time.fixedTime : Time.time;
		float delay = DifficultySettings.ReactionTimeSettings.GetComputerReactionDelay();
		QueuedReactions.AddLast((action, time + delay + (offset / 1000f)));
	}

}
