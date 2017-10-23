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
	}
}
