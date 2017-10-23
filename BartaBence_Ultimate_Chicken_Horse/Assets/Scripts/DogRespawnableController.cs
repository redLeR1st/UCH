using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogRespawnableController : MonoBehaviour {

	public DogRespawnableObject[] respawnableObjects;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}


	public void resetGame()
	{
		foreach (DogRespawnableObject respawnableObject in respawnableObjects)
		{
			respawnableObject.respawn();
		}
	}
}
