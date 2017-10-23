using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogScore : MonoBehaviour {

	public static float dogScore = 0;
	private Text scoreText;

	// Use this for initialization
	void Start () {
		scoreText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Dog's score: " + dogScore;
	}
}
