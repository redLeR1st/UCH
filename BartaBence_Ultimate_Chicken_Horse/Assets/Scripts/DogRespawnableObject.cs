using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogRespawnableObject : MonoBehaviour {
	public Transform respawnPoint;

	public void respawn()
	{
		gameObject.transform.position = respawnPoint.position;
	}
}
