using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColorIfAchReached : MonoBehaviour {

	public string achiName;
	public Sprite newSprite;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.GetInt(achiName) != 0)
		{
			this.GetComponent<Image>().sprite = newSprite;
		}
	}
}
