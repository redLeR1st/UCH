using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleManager : MonoBehaviour {

	//GameObject blackHole = null;
	Collider2D collider = null;
	GameObject[] players = null;

	// Use this for initialization
	void Start () {
		collider = gameObject.GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {

		players = GameObject.FindGameObjectsWithTag("Player");

		for (int i = 0; i < players.Length; i++) {

			if (collider.IsTouching(players[i].GetComponent<Collider2D>()))
			{
				players[i].GetComponent<Rigidbody2D>().velocity = gameObject.transform.position;

			}
		}
	}
}
