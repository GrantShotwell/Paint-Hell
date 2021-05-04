using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Healthbar : MonoBehaviour {

	[Header("Values")]
	[Range(0, 10)]
	public int max;
	[Range(0, 10)]
	public int current;

	[Header("Events")]
	public UnityEvent<int, Vector2> OnDamage;
	public UnityEvent<int, Vector2> OnHeal;

	void OnValidate() {

		if(max > 100) max = 100;
		if(max < 1) max = 1;

		if(current > max) current = max;
		if(current < 0) current = 0;

	}

	public void Damage(int amount, Vector2 force) {
		if((current -= amount) <= 0) current = 0;
		OnDamage.Invoke(amount, force.normalized);
	}

	public void Heal(int amount, Vector2 force) {
		if((current += amount) >= max) current = max;
		OnHeal.Invoke(amount, force.normalized);
	}

}
