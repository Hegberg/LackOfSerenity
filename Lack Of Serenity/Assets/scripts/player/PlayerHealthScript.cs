using UnityEngine;
using System.Collections;

public class PlayerHealthScript : MonoBehaviour {

    public Sprite oneHealth;
    public Sprite twoHealth;
    public Sprite threeHealth;
    public Sprite fourHealth;
    public Sprite fiveHealth;
    public Sprite sixHealth;
    public Sprite sevenHealth;
    public static PlayerHealthScript control;
    Vector3 rotation = new Vector3(0,0,-3.0f);

    // Use this for initialization
    void Start () {
        if (control == null)
        {
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }

    }
	
	// Update is called once per frame
	void Update () {
	    transform.Rotate(rotation);
    }

    public void changedLife(int life)
    {
        if (life == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = oneHealth;
        } else if (life == 2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = twoHealth;
        } else if (life == 3)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = threeHealth;
        } else if (life == 4)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = fourHealth;
        } else if (life == 5)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = fiveHealth;
        } else if (life == 6)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sixHealth;
        } else if (life == 7)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sevenHealth;
        }
    }
}
