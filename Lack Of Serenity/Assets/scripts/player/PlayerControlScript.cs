using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerControlScript : MonoBehaviour
{
    //variable for recently gaining a life
    private bool lifeGained = false;

    private int lives = 1;
    public static PlayerControlScript control;

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
    }

    // Update is called once per frame
    void Update()
    {
        Move();
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
                Instantiate(PrefabManagerScript.PlayerProjectiles[0], new Vector3(rigid.transform.position.x, rigid.transform.position.y, 0), Quaternion.identity);
                lives -= 1;
                PlayerHealthScript.control.changedLife(lives);
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
        if (Input.GetKeyDown("c"))
        {
            lives = 7;
            PlayerHealthScript.control.changedLife(lives);
        }
    }

    public void LifeLost()
    {
        lives -= 1;
        if (lives == 0)
        {
            Dead();
        }
        PlayerHealthScript.control.changedLife(lives);
    }

    public void LifeGained()
    {
        lifeGained = true;
        StartCoroutine(LifeConvertWait());
        if (lives < 7)
        {
            lives += 1;
            PlayerHealthScript.control.changedLife(lives);
        }
    }

    //wait time for life to change back
    IEnumerator LifeConvertWait()
    {
        yield return new WaitForSeconds(1);
        lifeGained = false;
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
        }
    }

    private void MoveLeft()
    {
        transform.Translate(new Vector3(-0.08f, 0, 0));
    }

    private void MoveRight()
    {
        transform.Translate(new Vector3(0.08f, 0, 0));
    }
}
