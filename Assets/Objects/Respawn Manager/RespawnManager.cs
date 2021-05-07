using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour {

	public List<RespawnSet> respawns = new List<RespawnSet>();
	private Queue<IRespawnable> waiting = new Queue<IRespawnable>();

	[System.Serializable]
	public class RespawnSet {
		public List<RespawnPoint> spawns = new List<RespawnPoint>();
		public static implicit operator List<RespawnPoint>(RespawnSet set) => set.spawns;
	}

	private void Awake() {
		StaticMonobehaviours.RespawnManager = this;
	}

	void FixedUpdate() {
		while(waiting.Count > 0) {
			IRespawnable respawnable = waiting.Dequeue();
			RequestRespawnNow(respawnable);
		}
	}

	public void RequestRespawnDelayed(IRespawnable respawnable, float delay) {
		StartCoroutine(DelayRespawnNow(respawnable, delay));
	}

	private IEnumerator DelayRespawnNow(IRespawnable respawnable, float delay) {
		yield return new WaitForSeconds(delay);
		RequestRespawnNow(respawnable);
	}

	public void RequestRespawnNow(IRespawnable respawnable) {

		int teamCount = respawns.Count;
		int team = respawnable.team;
		if(team >= teamCount) {
			Debug.LogError($"Team {team} doesn't exist.");
			return;
		}

		List<RespawnPoint> spawns = respawns[team];
		int count = spawns.Count;
		RespawnPoint selected = null;
		int k = Random.Range(0, count - 1);

		for(int i = 0; i < count; i++) {
			RespawnPoint spawn = spawns[(i + k) % count];
			bool enabled = spawn.enabled && spawn.gameObject.activeInHierarchy;
			bool available = spawn.obstacles == 0;
			if(!selected && enabled) selected = spawns[k];
			if(available) {
				selected = spawn;
				break;
			}
		}

		if(selected) {
			selected.queue.Enqueue(respawnable);
		} else {
			waiting.Enqueue(respawnable);
		}

	}

}
