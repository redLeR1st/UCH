using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelect : MonoBehaviour {

	float rotation = 0;

	private bool weaponToPut = false;

	private GameObject newWeapon = null;

	public GameObject w_canvas = null;

	public GameObject[] weapon;




	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update() {
		if (weaponToPut && !w_canvas.active) {
			Vector3 pos = Input.mousePosition;
			pos.z = transform.position.z - Camera.main.transform.position.z;
			newWeapon.transform.position = Camera.main.ScreenToWorldPoint(pos);


			if (Input.GetButtonDown("RotateLeft"))
			{
				rotation += 90;
				if (rotation >= 360)
				{
					rotation = 0;
				}
			}
			if (Input.GetButtonDown("RotateRight"))
			{
				rotation -= 90;
				if (rotation <= -360)
				{
					rotation = 0;
				}
			}

			newWeapon.transform.eulerAngles = new Vector3(0, 0, rotation);


		}
		if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) == true)
		{
			weaponToPut = false;
			rotation = 0;

			print("click");
		}

	}


	/*******************WEAPON PUT FUNCTIONS***********************************/

	public void weapon0Put()
	{
		putWeapon(weapon[0]);

	}
	public void weapon1Put()
	{
		putWeapon(weapon[1]);

	}

	public void weapon2Put()
	{
		putWeapon(weapon[2]);

	}


	/****************END WEAPON PUT FUNCTIONS***********************************/

	private void putWeapon(GameObject putThis)
	{
		if (putThis != null)
		{
			if (weaponToPut)
			{
				Destroy(newWeapon);
			}
			else
			{
				hideWeaponMenu();
				weaponToPut = true;
				newWeapon = Instantiate(putThis);
			}
		}
	}


	public void hideWeaponMenu()
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
