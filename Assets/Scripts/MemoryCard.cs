using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour {
	[SerializeField] private GameObject cardBack;

	public void OnMouseDown() {
		// Debug.Log ("Testing clicks");
		if (cardBack.activeSelf) {
			cardBack.SetActive (false);
		}
	}
}
