using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticMonobehaviours {

	private static RNJesus rnJesus;
	public static RNJesus RNJesus {
		get {
			if(rnJesus) return rnJesus;
			else throw new UnassignedReferenceException($"Monobehaviour '{nameof(RNJesus)}' has not been set!");
		}
		set => rnJesus = value;
	}

	private static MainMenuController mainMenuController;
	public static MainMenuController MainMenuController {
		get {
			if(mainMenuController) return mainMenuController;
			else throw new UnassignedReferenceException($"Monobehaviour '{nameof(MainMenuController)}' has not been set!");
		}
		set => mainMenuController = value;
	}

	private static RespawnManager respawnManager;
	public static RespawnManager RespawnManager {
		get {
			if(respawnManager) return respawnManager;
			else throw new UnassignedReferenceException($"Monobehaviour '{nameof(MainMenuController)}' has not been set!");
		}
		set => respawnManager = value;
	}

	private static GameStarterController gameStarterController;
	public static GameStarterController GameStarterController {
		get {
			return gameStarterController;
			//if(gameStarterController) return gameStarterController;
			//else throw new UnassignedReferenceException($"Monobehaviour '{nameof(GameStarterController)}' has not been set!");
		}
		set => gameStarterController = value;
	}

}
