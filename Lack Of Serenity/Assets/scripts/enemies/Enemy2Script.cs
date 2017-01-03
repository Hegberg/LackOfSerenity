using UnityEngine;
using System.Collections;

public class Enemy2Script : MonoBehaviour {

    public Sprite noShield;
    public Sprite shield;
    public Sprite invincible;

    int health = 3;
    float firingSpeed = 1.0f;
    float shieldRegenRate = 5.0f;
    int amountOfShots = 1;

    bool goLeft = true;

    // Use this for initialization
    void Start()
    {
        //start of each level firing this fast, only when enemies die does it speed up
        InvokeRepeating("LaunchProjectile3", 1, firingSpeed);
        //for levels where this is the first enemy to shoot, not invincible
        //the rest of the levels start as invincible
        if (GameControlScript.control.GetCurrentLevel() == 2)
        {
            ChangeHealth(2);
        }
        else
        {
            ChangeHealth(3);
        }

        //if on left side go right so goLeft false
        //else foLeft already true so no need for else statement
        if (transform.position.x < 0)
        {
            goLeft = false;
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
        if (goLeft)
        {
            transform.localPosition += new Vector3(-0.08f, 0, 0);
        }
        else
        {
            transform.localPosition += new Vector3(0.08f, 0, 0);
        }
    }

    void Turn()
    {
        transform.right = PlayerControlScript.control.GetPlayerPosition() - transform.position;
    }

    IEnumerator MoveTimer()
    {
        yield return new WaitForSeconds(1.2f);
        goLeft = !goLeft;
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
            //enemy 2 dies so 2nd spot in list so 1
            GameControlScript.control.EnemyDied(1);
            Destroy(this.gameObject);
        }
    }

    IEnumerator ShieldRegen()
    {
        yield return new WaitForSeconds(shieldRegenRate);
        ChangeHealth(2);
    }

    void LaunchProjectile3()
    {
        Instantiate(PrefabManagerScript.EnemyProjectiles[2], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
    }

    void CheckInvincibility()
    {
        bool check = true;
        //if no other enemies above this one alive, then no longer invincible
        //start at 2 since 1 is this enemy, so do not want to check it against itself
        for (int i = 2; i < GameControlScript.control.GetAmountOfEnemyTypes(); ++i)
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
        if (firingSpeed >= 0.4f)
        {
            firingSpeed -= 0.2f;
        }
        amountOfShots += 1;
        //starts firing double and triple shots
        for (int i = 0; i < amountOfShots; ++i) {
            //this creates offset so players can see the double.tiple etc shots
            float j = i * 0.02f;
            InvokeRepeating("LaunchProjectile3", firingSpeed + j, firingSpeed);
        }
    }
}