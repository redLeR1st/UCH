using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameStart : MonoBehaviour
{

	public GameObject m_canvas = null;
	public GameObject w_canvas = null;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

		if (Input.GetButtonDown("Cancel"))
		{
			if (m_canvas.activeSelf)
			{
				m_canvas.SetActive(false);
			}
			else
			{
				m_canvas.SetActive(true);
				GameStats.isGamePaused = true;
			}
		}

		if (Input.GetButtonDown("Submit"))
		{
			if (w_canvas.activeSelf)
			{
				w_canvas.SetActive(false);
			}
			else
			{
				w_canvas.SetActive(true);
				GameStats.isGamePaused = true;
			}
		}
	}
}
