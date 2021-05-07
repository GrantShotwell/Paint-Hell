using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRespawnable {

	public int team { get; }

	public void Respawn(Vector2 at);

	public void Despawn();

}
