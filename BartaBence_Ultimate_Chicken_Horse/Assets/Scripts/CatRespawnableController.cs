using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatRespawnableController : MonoBehaviour {

	public CatRespawnableObject[] respawnableObjects;

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
		foreach (CatRespawnableObject respawnableObject in respawnableObjects)
		{
			respawnableObject.respawn();
		}
	}
}
