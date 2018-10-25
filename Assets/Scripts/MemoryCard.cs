using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour {
	[SerializeField] private GameObject cardBack;
	[SerializeField] private Sprite image;

	void Start() {
		// The Sprite Renderer component is what makes a 2D sprite a sprite
		// Its main property is "Sprite", which can be set programmatically.
		// Here we are attaching a sprite into the SerializedField of the script,
		// which then passes it on to the Sprite Renderer
		GetComponent<SpriteRenderer> ().sprite = image;
	}

	public void OnMouseDown() {
		// Debug.Log ("Testing clicks");
		if (cardBack.activeSelf) {
			cardBack.SetActive (false);
		}
	}
}
