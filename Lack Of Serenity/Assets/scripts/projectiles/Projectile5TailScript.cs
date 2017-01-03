using UnityEngine;
using System.Collections;

public class Projectile5TailScript : MonoBehaviour {

    Vector3 movement = new Vector3(0.0f, -0.1f, 0);
    // Use this for initialization
    void Start () {
	    Ignore();
    }
	
	// Update is called once per frame
	void Update () {
	    Ignore();
    }

    void Ignore()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.Find("Platform1").GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.Find("Platform2").GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.Find("Platform3").GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.Find("Platform4").GetComponent<Collider2D>());
        //also ignore parent movement
        transform.position -= movement;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //goes through the 4 platforms but not through the bottom platform
        if (other.gameObject.name == "BottomPlatform" || other.gameObject.name == "TopPlatform"
            || other.gameObject.name == "LeftPlatform" || other.gameObject.name == "RightPlatform")
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

        }
    }

    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
