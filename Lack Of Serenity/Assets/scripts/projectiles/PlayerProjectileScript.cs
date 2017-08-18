using UnityEngine;
using System.Collections;

public class PlayerProjectileScript : MonoBehaviour {

    Vector3 movement = new Vector3(0.1f,0.1f,0);

    // Use this for initialization
    void Start () {
        Ignore();

		//faces projectile at mouse pointer
		Vector3 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.rotation = Quaternion.LookRotation (Vector3.forward, pos - transform.position);
		transform.Rotate (0, 0, -90);
    }
	
	// Update is called once per frame
	void Update () {
        Ignore();
        transform.position -= Vector3.Scale(transform.right, movement);
    }

    void Ignore()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.Find("Player1").GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.Find("Player_Projectile_1(Clone)").GetComponent<Collider2D>());
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
        else if (other.gameObject.name == "Enemy1(Clone)")
        {
            other.gameObject.GetComponent<Enemy1Script>().Hit();
            Destroy(gameObject);
        } 
        else if (other.gameObject.name == "Enemy2(Clone)")
        {
            other.gameObject.GetComponent<Enemy2Script>().Hit();
            Destroy(gameObject);
        }
        else if (other.gameObject.name == "Enemy3(Clone)")
        {
            other.gameObject.GetComponent<Enemy3Script>().Hit();
            Destroy(gameObject);
        }
        else if (other.gameObject.name == "Enemy4(Clone)")
        {
            other.gameObject.GetComponent<Enemy4Script>().Hit();
            Destroy(gameObject);
        }
    }
}
