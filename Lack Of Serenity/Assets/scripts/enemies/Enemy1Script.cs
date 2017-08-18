using UnityEngine;
using System.Collections;

public class Enemy1Script : MonoBehaviour {

    public Sprite noShield;
    public Sprite shield;
    public Sprite invincible;

    int health = 3;
    float firingSpeed1 = 1.0f;
    float firingSpeed2 = 5.0f;
    float shieldRegenRate = 5.0f;

    // Use this for initialization
    void Start () {
        //start of each level firing this fast, only when enemies die does it speed up
        //first number is delay till repeating starts ,second is delay between firing
        InvokeRepeating("LaunchProjectile1", 1, firingSpeed1);
        InvokeRepeating("LaunchProjectile2", 1 + firingSpeed2, firingSpeed2);

        //for levels this is the only enemy so level 1 so far, only have shield
		if (GameControlScript.control.GetCurrentLevel() == 1 
			|| GameControlScript.control.GetCurrentLevel() == 9 )
        {
            ChangeHealth(2);
        }
        else 
        {
            ChangeHealth(3);
        }
    }
	
	// Update is called once per frame
	void Update () {
		CheckEnviroment ();
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

    //wait for shield regen timer then give enemy shield back
    IEnumerator ShieldRegen()
    {
        yield return new WaitForSeconds(shieldRegenRate);
        ChangeHealth(2);
    }

    public void Hit()
    {
        //if invincible none of these trigger so enemy is not affected
        if(health == 2)
        {
            ChangeHealth(1);
        } else if (health == 1)
        {
            GameControlScript.control.LastEnemyDefeated();
            Destroy(this.gameObject);
        }
    }

    void LaunchProjectile1()
    {
		Transform projectile = (Transform) Instantiate(PrefabManagerScript.EnemyProjectiles[0], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
		projectile.SetParent (EnemyControllerScript.control.enemyParent.transform);
	}

    void LaunchProjectile2()
    {
        //create 8 projectile2's at the same time
        for (int i = 0; i <=8; ++i)
        {
            Instantiate(PrefabManagerScript.EnemyProjectiles[1], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }
    }

    void CheckInvincibility()
    {
        bool check = true;
        //if no other enemies alive, then no longer invincible
        //start at 1 since 0 is this enemy, so do not want to check it against itself
        for (int i = 1; i < GameControlScript.control.GetAmountOfEnemyTypes(); ++i)
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
        //stop firing speed from going below 0.1f
        if (firingSpeed1 > 0.1f)
        {
            firingSpeed1 -= 0.5f;
			if (firingSpeed1 < 0.1f) {
				firingSpeed1 = 0.1f;
			}
        }
        //stop from going lesss then 1.1f
        if (firingSpeed2 > 1.1f)
        {
            firingSpeed2 -= 1.5f;
			if (firingSpeed2 < 1.1f) {
				firingSpeed2 = 1.1f;
			}
        }
        InvokeRepeating("LaunchProjectile1", firingSpeed1, firingSpeed1);
        InvokeRepeating("LaunchProjectile2", firingSpeed1 + firingSpeed2, firingSpeed2);
    }

	private void CheckEnviroment() {
		if (GameControlScript.control.GetCurrentLevel () == 9) {
			transform.Translate (GameControlScript.control.GetLavaSpeed ());
		}
	}
}
