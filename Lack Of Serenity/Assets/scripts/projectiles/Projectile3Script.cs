﻿using UnityEngine;
using System.Collections;

public class Projectile3Script : MonoBehaviour {

    public Transform player;
    Vector3 movement = new Vector3(0.1f, 0.1f, 0);
    private float distanceToConvert = 2.0f;

    // Use this for initialization
    void Start()
    {
        Ignore();
        //aim at player
        transform.right = PlayerControlScript.control.GetPlayerPosition() - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //ignore collisions with certian objects
        Ignore();
        //move
        transform.position += Vector3.Scale(transform.right, movement);
        //check if converted to life of player
        LifeGained();
    }

    void LifeGained()
    {
        if (Input.GetKeyDown("space") && !PlayerControlScript.control.CheckIfLifeGainedRecently() && (Vector2.Distance(this.transform.position, PlayerControlScript.control.gameObject.transform.position) <= distanceToConvert))
        {
            PlayerControlScript.control.LifeGained();
            Destroy(this.gameObject);
        }
    }

    //may not be necessary
    void Ignore()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.Find("Projectile_3(Clone)").GetComponent<Collider2D>());
    }

    //need isTrigger set to true for projectile in collider options for this to work
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Platform1" || other.gameObject.name == "Platform2" || other.gameObject.name == "Platform3"
            || other.gameObject.name == "Platform4" || other.gameObject.name == "BottomPlatform" || other.gameObject.name == "TopPlatform"
            || other.gameObject.name == "LeftPlatform" || other.gameObject.name == "RightPlatform"
			|| other.gameObject.name == "Lava")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.name == "Player_Projectile_1(Clone)")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.gameObject.name == "Player1")
        {
            PlayerControlScript.control.LifeLost();
            Destroy(gameObject);
        }
    }
}
