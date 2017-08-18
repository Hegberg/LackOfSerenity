using UnityEngine;
using System.Collections;

public class Projectile5Script : MonoBehaviour {

    public Transform tail;
    public Transform thisParent;
    Vector3 movement = new Vector3(0.0f, -0.1f, 0);

    // Use this for initialization
    void Start()
    {
        Ignore();
    }

    // Update is called once per frame
    void Update()
    {
        //ignore collisions with certian objects
        Ignore();
        //move
        transform.position +=  movement;
        //create tail
        Transform createdTail = (Transform)Instantiate(tail, transform.position, Quaternion.identity);
        createdTail.SetParent(thisParent.transform);
    }

    //may not be necessary
    void Ignore()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.Find("Projectile_5(Clone)").GetComponent<Collider2D>());
    }

    //need isTrigger set to true for projectile in collider options for this to work
    void OnTriggerEnter2D(Collider2D other)
    {
        //goes through the 4 platforms but not through the bottom platform
        if ( other.gameObject.name == "BottomPlatform" || other.gameObject.name == "TopPlatform"
            || other.gameObject.name == "LeftPlatform" || other.gameObject.name == "RightPlatform"
			|| other.gameObject.name == "Lava")
        {
            DestroyClones();
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

    void DestroyClones()
    {
        BroadcastMessage("Destroy");
    }
}
