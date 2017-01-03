using UnityEngine;
using System.Collections;

public class Enemy3Script : MonoBehaviour {

    public Sprite noShield;
    public Sprite shield;
    public Sprite invincible;

    int health = 3;
    float firingSpeed = 1.0f;
    float shieldRegenRate = 5.0f;

    bool goUp = true;

    // Use this for initialization
    void Start()
    {
        //start of each level firing this fast, only when enemies die does it speed up
        InvokeRepeating("LaunchProjectile4", 1, firingSpeed);
        //for levels where this is the first enemy to shoot, not invincible
        //the rest of the levels start as invincible
        if (GameControlScript.control.GetCurrentLevel() == 3 || GameControlScript.control.GetCurrentLevel() == 5)
        {
            ChangeHealth(2);
        }
        else
        {
            ChangeHealth(3);
        }

        //if on left side go right so goLeft false
        //else foLeft already true so no need for else statement
        if (transform.position.y > 2)
        {
            goUp = false;
        }
        StartCoroutine(MoveTimer());

        Turn();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Turn();
    }

    void Move()
    {
        if (goUp)
        {
            transform.localPosition += new Vector3(0, 0.08f, 0);
        }
        else
        {
            transform.localPosition += new Vector3(0, -0.08f, 0);
        }
    }

    void Turn()
    {
        transform.right = PlayerControlScript.control.GetPlayerPosition() - transform.position;
    }

    IEnumerator MoveTimer()
    {
        yield return new WaitForSeconds(1.0f);
        if (goUp)
        {
            goUp = false;
        }
        else
        {
            goUp = true;
        }
        StartCoroutine(MoveTimer());
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
            //enemy 3 dies so 3rd spot in list so 2
            GameControlScript.control.EnemyDied(2);
            Destroy(this.gameObject);
        }
    }

    IEnumerator ShieldRegen()
    {
        yield return new WaitForSeconds(shieldRegenRate);
        ChangeHealth(2);
    }

    void LaunchProjectile4()
    {
        Instantiate(PrefabManagerScript.EnemyProjectiles[3], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
    }

    void CheckInvincibility()
    {
        bool check = true;
        //if no other enemies above this one alive, then no longer invincible
        //start at 3 since 2 is this enemy, so do not want to check it against itself
        for (int i = 3; i < GameControlScript.control.GetAmountOfEnemyTypes(); ++i)
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
    }

    void IncreaseFiringSpeed()
    {
        //cancel earlier invoke, up speed for less enemies
        CancelInvoke();
        //stop from going below 0.2f
        if (firingSpeed >= 0.6f)
        {
            firingSpeed -= 0.4f;
        }
        InvokeRepeating("LaunchProjectile4", firingSpeed, firingSpeed);
    }
}
