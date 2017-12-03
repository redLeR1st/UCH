using UnityEngine;
using System.Collections;

public class ArrowController : MonoBehaviour
{

	public Transform firePoint;

	public bool hasMaxDistance;
	public float maxDistance;


	public float distanceTraveled = 0f;


	void Awake()
	{
		//firePoint = GameObject.FindGameObjectWithTag("FirePoint").transform;
	}

	void OnEnable()
	{
		distanceTraveled = 0;
		transform.position = firePoint.position;
	}

	void Update()
	{


		if (hasMaxDistance)
		{
			distanceTraveled += transform.position.x;

			if (Mathf.Abs(distanceTraveled) >= maxDistance)
			{
				gameObject.SetActive(false);
			}
		}
	}
}
