using UnityEngine;
using System.Collections;

public class Enemy4Script : MonoBehaviour {

    public Sprite noShield;
    public Sprite shield;
    public Sprite invincible;

    int health = 3;
    float firingSpeed = 3.0f;
    float shieldRegenRate = 5.0f;

    bool goLeft = true;
    bool stopMovement = false;

    int loopAmount = 0;

    // Use this for initialization
    void Start()
    {
        //start of each level firing this fast, only when enemies die does it speed up
        InvokeRepeating("LaunchProjectile5", 1, firingSpeed);
        //for levels where this is the first enemy to shoot, not invincible
        //the rest of the levels start as invincible
        /*
        if (GameControlScript.control.GetCurrentLevel() == 4)
        {
            ChangeHealth(2);
        }
        else
        {
            ChangeHealth(3);
        }
        */
        //For now all instances of this enemy have no invincibility
        ChangeHealth(2);

        //if on left side go right so goLeft false
        //else foLeft already true so no need for else statement
        if (transform.position.x < 0)
        {
            goLeft = false;
        }
        //StartCoroutine(MoveTimer());

    }

    // Update is called once per frame
    void Update()
    {
        if (!stopMovement)
        {
            Move();
        }
    }

    void Move()
    {
        if (goLeft)
        {
            transform.localPosition += new Vector3(-0.08f, 0, 0);
        }
        else
        {
            transform.localPosition += new Vector3(0.08f, 0, 0);
        }
        loopAmount += 1;
        if (loopAmount >= 80)
        {
            loopAmount = 0;
            goLeft = !goLeft;
        }
    }


    IEnumerator PauseMovement()
    {
        yield return new WaitForSeconds(1.3f);
        stopMovement = false;
    }

    void ChangeHealth(int hp)
    {
        health = hp;
        if (health == 1)
        {
            StartCoroutine(ShieldRegen());
            this.GetComponent<SpriteRenderer>().sprite = noShield;
        }
        if (health == 2)
        {
            this.GetComponent<SpriteRenderer>().sprite = shield;
        }
        if (health == 3)
        {
            this.GetComponent<SpriteRenderer>().sprite = invincible;
        }
    }

    public void Hit()
    {
        //if invincible none of these called so enemy isn't affected
        if (health == 2)
        {
            ChangeHealth(1);
        }
        else if (health == 1)
        {
            //enemy 4 dies so 4th spot in list so 3
            GameControlScript.control.EnemyDied(3);
            Destroy(this.gameObject);
        }
    }

    IEnumerator ShieldRegen()
    {
        yield return new WaitForSeconds(shieldRegenRate);
        ChangeHealth(2);
    }

    void LaunchProjectile5()
    {
        Instantiate(PrefabManagerScript.EnemyProjectiles[4], new Vector3(transform.position.x, transform.position.y - 0.7f, 0), Quaternion.identity);
        stopMovement = true;
        StartCoroutine(PauseMovement());
    }

    void CheckInvincibility()
    {
        // This is comminted out since this call is currently useless for this enemy since will never be invincible
        //bool check = true;
        //if no other enemies above this one alive, then no longer invincible
        //start at 4 since 3 is this enemy, so do not want to check it against itself
        /*
        for (int i = 4; i < GameControlScript.control.GetAmountOfEnemyTypes(); ++i)
        {
            if (GameControlScript.control.GetEnemiesAlive(i) != 0)
            {
                check = false;
                break;
            }
        }
        
        //check true if no other enemies alive, so set to not invincible
        //else set to invincible aka health = 3
        if (check)
        {
            ChangeHealth(2);
        }
        else
        {
            ChangeHealth(3);
        }
        */
    }

    void IncreaseFiringSpeed()
    {
        //cancel earlier invoke, up speed for less enemies
        CancelInvoke();
        //stop from going below 0.2f
        if (firingSpeed >= 0.4f)
        {
            firingSpeed -= 0.2f;
        }
        InvokeRepeating("LaunchProjectile5", firingSpeed, firingSpeed);
    }
}