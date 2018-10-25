using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {
	[SerializeField] private MemoryCard originalCard; // the one card in the scene
	[SerializeField] private Sprite[] images; // references to sprite assets, you can serialize an Array!

	void Start () {
		int id = Random.Range (0, images.Length); // minimum value is inclusive, but return value is always below maximum
		originalCard.SetCard (id, images [id]); // using the card API to change the base card on Start()
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
