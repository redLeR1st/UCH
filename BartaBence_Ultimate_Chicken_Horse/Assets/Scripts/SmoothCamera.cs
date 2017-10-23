using UnityEngine;
using System.Collections;

public class SmoothCamera : MonoBehaviour
{

	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public Transform Dog;
	public Transform Cat;

	// Update is called once per frame
	void Update()
	{
		if (Dog && Cat)
		{
			Vector3 av = new Vector3((Dog.position.x + Cat.position.x) / 2, (Dog.position.y + Cat.position.y) / 2, 0);

			//Get the position of the attached transform in Unity world position
			Vector3 point = Camera.main.WorldToViewportPoint(av);
			//Create a position with the delta
			Vector3 delta = av - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.25f, point.z));
			//Add the delta to the target position
			Vector3 destination = transform.position + delta;
			//Smoothly damp the camera's position based on the calculated values
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);

			//transform.localScale += new Vector3(1000.0f, 1000.0f, 0);
		}
	}
}
