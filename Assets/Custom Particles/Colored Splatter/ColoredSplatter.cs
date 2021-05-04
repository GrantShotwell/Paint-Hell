using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ColoredSplatter : Decal {
	
	public static RollingArray<ColoredSplatter> splatters = new RollingArray<ColoredSplatter>(500);

	public List<Sprite> sprites = new List<Sprite>();
	public Color color = Color.white;
	public Vector2 direction = Vector2.zero;

	public bool sendForward = true;
	new SpriteRenderer renderer;

	void Start() {

		renderer = GetComponent<SpriteRenderer>();
		renderer.color = color;
		renderer.sortingOrder = GetNextTileDecalLayer();

		if(sprites.Count > 0) {
			int index = Random.Range(0, sprites.Count);
			renderer.sprite = sprites[index];
		}

		float angle;
		if(direction == Vector2.zero) direction = Vector2Random.NormalVector(out angle);
		else angle = Mathf.Atan2(direction.y, direction.x);
		Vector3 euler = transform.rotation.eulerAngles;
		euler.z = angle * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(euler);

		if(sendForward) {

			var hit = Physics2D.Raycast(transform.position, direction);
			if(hit) {
				transform.position = hit.point;
				splatters.Add(this, out ColoredSplatter last);
				if(last) last.Dispose();
			} else {
				Destroy(gameObject);
			}

		} else {

			splatters.Add(this, out ColoredSplatter last);
			if(last) last.Dispose();

		}

	}

	void Update() {
		renderer.color = color;
	}

	void Dispose() {
		Destroy(gameObject);
	}

}
