using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Reaction Time Settings", menuName = "Difficulty Settings/Reaction Times")]
public class ReactionTimeSettings : ScriptableObject {

	[SerializeField]
	private int humanReactionTime;
	[SerializeField]
	private int maxComputerReactionDelay;

	public int HumanReactionTime { get => humanReactionTime; set => humanReactionTime = value; }
	public int MaxComputerReactionDelay { get => maxComputerReactionDelay; set => maxComputerReactionDelay = value; }

	public float GetComputerReactionDelay() {
		float human = (HumanReactionTime / 1000f);
		float delay = (MaxComputerReactionDelay / 1000f) * Random.value;
		return human + delay;
	}
	
}
