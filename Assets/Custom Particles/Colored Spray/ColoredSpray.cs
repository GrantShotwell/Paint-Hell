using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ColoredSpray : Decal {

	public static RollingArray<ColoredSpray> splatters = new RollingArray<ColoredSpray>(200);

	public List<Sprite> sprites = new List<Sprite>();
	public Color color = Color.white;
	public Vector2 direction = Vector2.zero;
	public float distance = 5;
	public float length = 4;

	public float colorMultiplier = 0.80f;
	public float alphaMultiplier = 0.50f;

	public bool sendForward = true;
	new SpriteRenderer renderer;

	void OnValidate() {
		if(renderer || (renderer = GetComponent<SpriteRenderer>())) {
			SetColor();
			if(sprites.Count >= 1 && !renderer.sprite) {
				renderer.sprite = sprites[0];
			}
		}
	}

	void Start() {

		renderer = GetComponent<SpriteRenderer>();
		SetColor();
		renderer.sortingOrder = GetNextWallDecalLayer();

		if(sprites.Count > 0) {
			int index = Random.Range(0, sprites.Count);
			renderer.sprite = sprites[index];
		}

		splatters.Add(this, out ColoredSpray last);
		if(last) last.Dispose();

		if(sendForward) {

			float angle;
			if(direction == Vector2.zero) direction = Vector2Random.NormalVector(out angle);
			else angle = Mathf.Atan2(direction.y, direction.x);
			Vector3 euler = transform.rotation.eulerAngles;
			euler.z = angle * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(euler);

			transform.position += (Vector3)direction * (distance * Random.value);

		}

	}

	void Update() {
		//SetColor();
	}

	public void SetColor() {
		renderer.color = new Color(color.r * colorMultiplier, color.g * colorMultiplier, color.b * colorMultiplier, color.a * alphaMultiplier);
	}

	void Dispose() {
		StartCoroutine(FadeOutCoroutine());
	}

	private IEnumerator FadeOutCoroutine() {

		while(renderer.color.a > 0.05f) {
			Color color = renderer.color;
			color.a -= 0.05f;
			renderer.color = color;
			yield return new WaitForSeconds(0.05f);
		}

		Destroy(gameObject);

	}

}
