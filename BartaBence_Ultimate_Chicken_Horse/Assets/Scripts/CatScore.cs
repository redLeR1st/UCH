using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatScore : MonoBehaviour {

	public static float catScore = 0;
	private Text scoreText;

	// Use this for initialization
	void Start()
	{
		scoreText = GetComponent<Text>();
	}

	// Update is called once per frame
	void Update()
	{
		scoreText.text = "Cat's score: " + catScore;

		if (catScore >= 2)
		{

			if (PlayerPrefs.GetInt("TwoScoreForCat") == 0)
			{
				PlayerPrefs.SetInt("TwoScoreForCat", 1);
				Debug.Log("Two score reached for CAT!!!");
			}
			else
			{
				Debug.Log("Two score for CAT was already got! Nothing happens.");
			}
		}
	}
}
