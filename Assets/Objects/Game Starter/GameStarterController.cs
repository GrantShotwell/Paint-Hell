using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarterController : MonoBehaviour {

	[Header("Game Settings")]
	public int scoreGoal = 10;

	[Header("Prefabs")]
	public GameObject playerCameraPrefab;

	[Header("Scores")]
	public List<int> teamScores;
	public List<UnityEngine.UI.Text> teamScoreDisplays;
	public UnityEngine.UI.Text winnerDisplay;

	private void Awake() {
		StaticMonobehaviours.GameStarterController = this;
	}

	private void Start() {
		CreateCombatantsAndCamera();
		StartTrackingTeamScores();
	}

	private void Update() {

		int teamCount = teamScores.Count;
		for(int team = 0; team < teamCount; team++) {
			int score = teamScores[team];
			teamScoreDisplays[team].text = score.ToString();
		}

	}

	private void FixedUpdate() {

		int teamCount = teamScores.Count;
		for(int team = 0; team < teamCount; team++) {
			int score = teamScores[team];
			if(score >= scoreGoal) EndGame(team);
		}

	}

	public void EndGame(int winner) {
		StartCoroutine(EndGameCoroutine(winner));
	}

	private IEnumerator EndGameCoroutine(int winner) {

		if(winnerDisplay) {
			winnerDisplay.text = $"Team {winner + 1} wins!";
			winnerDisplay.color = winner == 0 ? Color.blue : Color.green;
		}

		yield return new WaitForSeconds(5f);

		StaticMonobehaviours.MainMenuController.LoadMain();

	}

	public void StartTrackingTeamScores() {

		RespawnManager respawnManager = StaticMonobehaviours.RespawnManager;

		int teamCount = respawnManager.respawns.Count;
		teamScores = new List<int>(teamCount);
		for(int team = 0; team < teamCount; team++) teamScores.Add(0);

	}

	public void CreateCombatantsAndCamera() {

		MainMenuController main = StaticMonobehaviours.MainMenuController;
		RespawnManager respawnManager = StaticMonobehaviours.RespawnManager;

		int teamSize = main.teamSize;
		int teamCount = respawnManager.respawns.Count;

		for(int team = 0; team < teamCount; team++) {
			for(int combatant = 0; combatant < teamSize; combatant++) {

				PlayerController player;

				if(team == 0 && combatant == 0) {
					player = Instantiate(main.playerPrefab).GetComponent<PlayerController>();
					player.gameObject.name = "Player";
					CreateCamera(player.transform);
				} else {
					player = Instantiate(main.computerPrefab).GetComponent<PlayerController>();
					player.gameObject.name = "Computer Opponent " + (team * teamSize + combatant);
				}

				switch(team) {
					case 0: player.color = Color.blue; break;
					case 1: player.color = Color.green; break;
					case 2: player.color = Color.red; break;
					case 3: player.color = Color.cyan; break;
					case 4: player.color = Color.yellow; break;
					case 5: player.color = Color.magenta; break;
					default: player.color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f); break;
				}

				player.team = team;
				player.respawnManager = respawnManager;
				player.Despawn();

			}
		}

	}

	public void CreateCamera(Transform target) {
		GameObject camera = Instantiate(playerCameraPrefab);
		camera.name = playerCameraPrefab.name;
		PlayerCameraController controller = camera.GetComponent<PlayerCameraController>();
		controller.target = target;
	}

}
