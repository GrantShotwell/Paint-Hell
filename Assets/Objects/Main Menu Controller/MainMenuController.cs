using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	[Header("Combatants")]
	public GameObject playerPrefab;
	public GameObject computerPrefab;
	public int teamSize = 10;

	private void Awake() {
		StaticMonobehaviours.MainMenuController = this;
	}

	private void Start() {
		
	}

	public void LoadMain() {

		Destroy(StaticMonobehaviours.RNJesus.gameObject);
		Destroy(StaticMonobehaviours.MainMenuController.gameObject);
		SceneManager.LoadScene("Main");

	}

	public void LoadLevel(string levelName) {

		DontDestroyOnLoad(StaticMonobehaviours.RNJesus.gameObject);
		DontDestroyOnLoad(StaticMonobehaviours.MainMenuController.gameObject);
		SceneManager.LoadScene(levelName);

	}

	public void LoadTutorial() {

		SceneManager.LoadScene("Tutorial");

	}

	public void CloseGame() {

		Application.Quit();

	}

}
