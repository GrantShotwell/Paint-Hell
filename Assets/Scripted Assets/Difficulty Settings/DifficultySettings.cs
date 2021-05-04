using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Difficulty Settings Asset", menuName = "Difficulty Settings/Settings Asset", order = 0)]
public class DifficultySettings : ScriptableObject {

	[SerializeField]
	private ReactionTimeSettings reactionTimeSettings;

	public ReactionTimeSettings ReactionTimeSettings { get => reactionTimeSettings; set => reactionTimeSettings = value; }

}
