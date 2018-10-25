using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour {
	[SerializeField] private GameObject cardBack;
	[SerializeField] private Sprite image;

	void Start() {
		GetComponent<SpriteRenderer> ().sprite = image;
	}

	public void OnMouseDown() {
		// Debug.Log ("Testing clicks");
		if (cardBack.activeSelf) {
			cardBack.SetActive (false);
		}
	}
}
