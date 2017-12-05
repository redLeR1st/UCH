using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoombScript : MonoBehaviour {
    float timeLeft;
    // Use this for initialization
    void Start () {
        timeLeft = 0.09f;

    }

    

    void Update()
    {
   
    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        

        if (coll.gameObject.tag == "Weapon" && WeaponSelect.weaponToPut)
        {
            Destroy(coll.gameObject);
        }

        if (coll.gameObject.tag == "Boomb" && WeaponSelect.weaponToPut)
        {
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }


    }


}
