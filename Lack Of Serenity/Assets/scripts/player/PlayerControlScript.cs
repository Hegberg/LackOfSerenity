using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerControlScript : MonoBehaviour
{
    //variable for recently gaining a life
    private bool lifeGained = false;

    private int lives = 1;
    public static PlayerControlScript control;

    public AudioClip fireSound;
    public AudioClip lifeGainedSound;
    public AudioClip lifeLostSound;

	public Sprite lifeAbsorbOffCooldown;
	public Sprite lifeAbsorbOnCooldown;

	float waitBetweenGettingMoreLife = 1f;

    bool cheatsEnabled = true;

	public Rigidbody2D rb2D;

    // Use this for initialization
    void Start()
    {
        if (control == null)
        {
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }

		rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
		CheckEnviroment ();
    }

    //when dead return to main menu
    private void Dead()
    {
        GameControlScript.control.PlayerDefeated();
        //no need to destroy game object since is destroyed in above call when level is changed
        //Destroy(gameObject);
    }

    private void Move()
    {
        //fire if have lives to fire
        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody2D rigid = gameObject.GetComponent<Rigidbody2D>();
            if (lives >= 2)
            {
				Transform projectile = (Transform) Instantiate(PrefabManagerScript.PlayerProjectiles[0], new Vector3(rigid.transform.position.x, rigid.transform.position.y, 0), Quaternion.identity);
				//projectile parent is enemy parent, can't have parent as player
				//or player movement will affect projectile
				projectile.SetParent (EnemyControllerScript.control.enemyParent.transform);
                lives -= 1;
                PlayerHealthScript.control.changedLife(lives);
                GetComponent<AudioSource>().PlayOneShot(fireSound, 1);
            }

        }

        if (Input.GetKeyDown("w"))
        {
            Jump();
        }
        if (Input.GetKey("a"))
        {
            MoveLeft();
        }
        else if (Input.GetKey("d"))
        {
            MoveRight();
        }

        ///cheat to get full health
        if (Input.GetKeyDown("c") && cheatsEnabled)
        {
            lives = 7;
            PlayerHealthScript.control.changedLife(lives);
        }
        
    }

    public void LifeLost()
    {
        lives -= 1;
		if (lives <= 0) {
			Dead ();
		} else {
			//not played if player dies
			PlayerHealthScript.control.changedLife(lives);
			GetComponent<AudioSource>().PlayOneShot(lifeLostSound, 1);
		}
    }

    public void LifeGained()
    {
        lifeGained = true;
        StartCoroutine(LifeConvertWait());
		GetComponent<AudioSource>().PlayOneShot(lifeGainedSound, 1);
        if (lives < 7)
        {
            lives += 1;
            PlayerHealthScript.control.changedLife(lives);
        }
    }

    //wait time for life to change back
    IEnumerator LifeConvertWait()
    {
		GetComponent<SpriteRenderer>().sprite = lifeAbsorbOnCooldown;
        yield return new WaitForSeconds(waitBetweenGettingMoreLife);
        lifeGained = false;
		GetComponent<SpriteRenderer>().sprite = lifeAbsorbOffCooldown;
    }

    public bool CheckIfLifeGainedRecently()
    {
        return lifeGained;
    }

    public Vector3 GetPlayerPosition()
    {
        return transform.position;
    }

    //used by enemy projectiles if hit player
    private void Jump()
    {
        //transform.Translate(new Vector3(0, 1, 0) * 200 * Time.deltaTime);
        Rigidbody2D rigid = gameObject.GetComponent<Rigidbody2D>();
        //rigid.AddForce(Vector2.up*10);
        if (rigid.velocity.y == 0)
        {
            rigid.velocity += Vector2.up * 7;
			//rb2D.AddForce (Vector2.up * 400);
        }
    }

    private void MoveLeft()
    {
        transform.Translate(new Vector3(-0.08f, 0, 0));
		//rb2D.MovePosition (transform.position - new Vector3 (0.08f, rb2D.velocity.y/100));
    }

    private void MoveRight()
    {
        transform.Translate(new Vector3(0.08f, 0, 0));
		//rb2D.MovePosition (transform.position + new Vector3 (0.08f, rb2D.velocity.y/100));
    }

	private void CheckEnviroment() {
		if ((GameControlScript.control.GetCurrentLevel () == 9) 
			&& gameObject.GetComponent<Collider2D>().IsTouching(GameControlScript.control.GetLavaCollider())) {
			Dead ();
		}
	}
}
