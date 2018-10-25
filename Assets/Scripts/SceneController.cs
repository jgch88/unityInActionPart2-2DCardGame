using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {
	// grid spacing
	public const int gridRows = 2;
	public const int gridCols = 4;
	public const float offsetX = 2f;
	public const float offsetY = 2.5f;

	[SerializeField] private MemoryCard originalCard; // the one card in the scene
	[SerializeField] private Sprite[] images; // references to sprite assets, you can serialize an Array!

	void Start () {
		Vector3 startPos = originalCard.transform.position; // everything is relative to/offset from this base card

		for (int i = 0; i < gridCols; i++) {
			for (int j = 0; j < gridRows; j++) {
				MemoryCard card;
				if (i == 0 && j == 0) {
					card = originalCard;
				} else {
					card = Instantiate (originalCard) as MemoryCard; // cloning
				}

				int id = Random.Range (0, images.Length);
				// setting the original card/clones
				card.SetCard (id, images [id]);

				float posX = (offsetX * i) + startPos.x;
				float posY = -(offsetY * j) + startPos.y;
				card.transform.position = new Vector3 (posX, posY, startPos.z);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
