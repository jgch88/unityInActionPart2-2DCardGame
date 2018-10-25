using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

	[SerializeField] private MemoryCard originalCard; // the one card in the scene
	[SerializeField] private Sprite[] images; // references to sprite assets, you can serialize an Array!

	// grid spacing
	public const int gridRows = 2;
	public const int gridCols = 4;
	public const float offsetX = 2f;
	public const float offsetY = 2.5f;

	// game state variables
	private MemoryCard _firstRevealed;
	private MemoryCard _secondRevealed;

	void Start () {
		Vector3 startPos = originalCard.transform.position; // everything is relative to/offset from this base card

		// instead of letting cards randomly create without pairing
		// we define the cardIDs as pairs in an array, then shuffle the array.
		int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3 };
		numbers = ShuffleArray (numbers); // Knuth / Fisher-Yates shuffle algorithm

		for (int i = 0; i < gridCols; i++) {
			for (int j = 0; j < gridRows; j++) {
				MemoryCard card;
				if (i == 0 && j == 0) {
					card = originalCard;
				} else {
					card = Instantiate (originalCard) as MemoryCard; // cloning
				}

				// math to go through 0 - 7
				int index = j * gridCols + i;
				// getting the specific card enum / symbol from the shuffled numbers array
				int id = numbers [index];
				// setting the original card/clones
				card.SetCard (id, images [id]);

				float posX = (offsetX * i) + startPos.x;
				float posY = -(offsetY * j) + startPos.y;
				card.transform.position = new Vector3 (posX, posY, startPos.z);
			}
		}
	}

	// Knuth / Fisher-Yates shuffle
	// Loops through the array and swaps every element of the array with another randomly
	// chosen array position.
	private int[] ShuffleArray(int[] numbers) {
		int[] newArray = numbers.Clone () as int[];
		for (int i = 0; i < newArray.Length; i++) {
			int tmp = newArray [i];
			int r = Random.Range (i, newArray.Length);
			newArray [i] = newArray [r];
			newArray [r] = tmp;
		}
		return newArray;
	}

	public bool canReveal {
		get {return _secondRevealed == null;}
	}

	public void CardRevealed(MemoryCard card) {
		if (_firstRevealed == null) {
			_firstRevealed = card;
		} else {
			_secondRevealed = card;
			Debug.Log ("Match? " + (_firstRevealed.id == _secondRevealed.id));
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
