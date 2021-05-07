using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialEnder : MonoBehaviour {

	public UnityEngine.UI.Text display;

	public void EndTutorial() {
		StartCoroutine(EndTutorialCoroutine());
	}

	public IEnumerator EndTutorialCoroutine() {
		display.text = "Team 1 wins!";
		yield return new WaitForSeconds(5f);
		SceneManager.LoadScene("Main");
	}

}
