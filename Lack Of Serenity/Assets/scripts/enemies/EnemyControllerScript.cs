using UnityEngine;
using System.Collections;

public class EnemyControllerScript : MonoBehaviour {

    public static EnemyControllerScript control;
    public Transform enemyParent;


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
        
        SpawnEnemies();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SpawnEnemies()
    {
        //Creates Enemy 1
        Transform firstEnemy = (Transform)Instantiate(PrefabManagerScript.Enemies[0], new Vector3(0, 4.1f, 0), Quaternion.identity);
        firstEnemy.SetParent(enemyParent.transform);
        if (GameControlScript.control.GetCurrentLevel() > 1)
        {
            //spawn level 2 enimies
            Transform secondEnemy = (Transform)Instantiate(PrefabManagerScript.Enemies[1], new Vector3(-8, 4.1f, 0), Quaternion.identity);
            secondEnemy.SetParent(enemyParent.transform);
            Transform secondEnemy2 = (Transform)Instantiate(PrefabManagerScript.Enemies[1], new Vector3(8, 4.1f, 0), Quaternion.identity);
            secondEnemy2.SetParent(enemyParent.transform);
        }
        //put in code fore level 3 and 4 when get there
        //possibly throw it into for loop
    }

    public void TurnInvincibilityOff()
    {
        //Debug.Log("EnemyController Invicibilty");
        BroadcastMessage("CheckInvincibility");
    }

    public void EnemyDied(int enemyNumber)
    {
        //Debug.Log("EnemyController EnemyDied");
        if (GameControlScript.control.GetEnemiesAlive(enemyNumber) == 0)
        {
            BroadcastMessage("IncreaseFiringSpeed");
            TurnInvincibilityOff();
        }
    }
}
