using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireArrow : MonoBehaviour
{

	public GameObject arrow; //reference to arrow, set it from editor
	public float speed = 1f; //we're making it public, so we can test other values from the editor
	public Transform firePoint;

	public List<GameObject> arrowPool = new List<GameObject>();
	public int arrowPoolSize;

	public float targetTime = 1.2f;
	private float restartTimer;

	// Use this for initialization
	void Start()
	{
		for (int i = 0; i < arrowPoolSize; i++)
		{
			GameObject newArrow = Instantiate(arrow, firePoint.position, arrow.transform.rotation) as GameObject;
			newArrow.SetActive(false);
			arrowPool.Add(newArrow);
		}
		restartTimer = targetTime;
	}

	// Update is called once per frame
	void Update()
	{
		targetTime -= Time.deltaTime;

		if (targetTime <= 0.0f)
		{
			fireArrow();
			targetTime = restartTimer;
		}

	}

private void fireArrow()
	{
		//float newRotationAngle = CharacterMovemenetController.facingRight ? 90 : 270;
		//Rigidbody2D arrowClone = (Rigidbody2D) Instantiate(arrow, firePoint.position, Quaternion.Euler(0, 0, newRotationAngle));

		foreach (GameObject arrowClone in arrowPool)
		{
			if (!arrowClone.activeSelf)
			{
				arrowClone.SetActive(true);
				Vector3 force = /*CharacterMovemenetController.facingRight ? */transform.right /*: transform.right * -1*/;
				arrowClone.GetComponent<Rigidbody2D>().velocity = force * speed;
				break;
			}
		}
	}
}
