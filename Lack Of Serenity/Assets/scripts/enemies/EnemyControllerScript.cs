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
        //these need to match game controller levelStarted code

        //Creates Enemy 1
        Transform firstEnemy = (Transform)Instantiate(PrefabManagerScript.Enemies[0], new Vector3(0, 4.3f, 0), Quaternion.identity);
        firstEnemy.SetParent(enemyParent.transform);
        if (GameControlScript.control.GetCurrentLevel() == 2)
        {
            //spawn level 2 enemies
            Transform secondEnemy = (Transform)Instantiate(PrefabManagerScript.Enemies[1], new Vector3(-8, 4.3f, 0), Quaternion.identity);
            secondEnemy.SetParent(enemyParent.transform);
            Transform secondEnemy2 = (Transform)Instantiate(PrefabManagerScript.Enemies[1], new Vector3(8, 4.3f, 0), Quaternion.identity);
            secondEnemy2.SetParent(enemyParent.transform);
        }
        else if (GameControlScript.control.GetCurrentLevel() == 3)
        {
            //spawn level 3 enemies
            Transform thirdEnemy = (Transform)Instantiate(PrefabManagerScript.Enemies[2], new Vector3(-8, -0.8f, 0), Quaternion.identity);
            thirdEnemy.SetParent(enemyParent.transform);
            Transform thirdEnemy2 = (Transform)Instantiate(PrefabManagerScript.Enemies[2], new Vector3(8, -0.8f, 0), Quaternion.identity);
            thirdEnemy2.SetParent(enemyParent.transform);
        }
        else if (GameControlScript.control.GetCurrentLevel() == 4)
        {
            //spawn level 4 enemies
            Transform fourthEnemy = (Transform)Instantiate(PrefabManagerScript.Enemies[3], new Vector3(-8, 4.7f, 0), Quaternion.identity);
            fourthEnemy.SetParent(enemyParent.transform);
            Transform fourthEnemy2 = (Transform)Instantiate(PrefabManagerScript.Enemies[3], new Vector3(8, 4.7f, 0), Quaternion.identity);
            fourthEnemy2.SetParent(enemyParent.transform);
        }
        else if (GameControlScript.control.GetCurrentLevel() == 5)
        {
            //spawn level 5 enemies
            Transform secondEnemy = (Transform)Instantiate(PrefabManagerScript.Enemies[1], new Vector3(-8, 4.3f, 0), Quaternion.identity);
            secondEnemy.SetParent(enemyParent.transform);
            Transform secondEnemy2 = (Transform)Instantiate(PrefabManagerScript.Enemies[1], new Vector3(8, 4.3f, 0), Quaternion.identity);
            secondEnemy2.SetParent(enemyParent.transform);
            Transform thirdEnemy = (Transform)Instantiate(PrefabManagerScript.Enemies[2], new Vector3(-8, -0.8f, 0), Quaternion.identity);
            thirdEnemy.SetParent(enemyParent.transform);
            Transform thirdEnemy2 = (Transform)Instantiate(PrefabManagerScript.Enemies[2], new Vector3(8, -0.8f, 0), Quaternion.identity);
            thirdEnemy2.SetParent(enemyParent.transform);
        }
        else if (GameControlScript.control.GetCurrentLevel() == 6)
        {
            //spawn level 6 enemies
            Transform thirdEnemy = (Transform)Instantiate(PrefabManagerScript.Enemies[2], new Vector3(-8, -0.8f, 0), Quaternion.identity);
            thirdEnemy.SetParent(enemyParent.transform);
            Transform thirdEnemy2 = (Transform)Instantiate(PrefabManagerScript.Enemies[2], new Vector3(8, -0.8f, 0), Quaternion.identity);
            thirdEnemy2.SetParent(enemyParent.transform);
            Transform fourthEnemy = (Transform)Instantiate(PrefabManagerScript.Enemies[3], new Vector3(-8, 4.7f, 0), Quaternion.identity);
            fourthEnemy.SetParent(enemyParent.transform);
            Transform fourthEnemy2 = (Transform)Instantiate(PrefabManagerScript.Enemies[3], new Vector3(8, 4.7f, 0), Quaternion.identity);
            fourthEnemy2.SetParent(enemyParent.transform);
        }
        else if (GameControlScript.control.GetCurrentLevel() == 7)
        {
            //spawn level 7 enemies
            Transform secondEnemy = (Transform)Instantiate(PrefabManagerScript.Enemies[1], new Vector3(-8, 4.3f, 0), Quaternion.identity);
            secondEnemy.SetParent(enemyParent.transform);
            Transform secondEnemy2 = (Transform)Instantiate(PrefabManagerScript.Enemies[1], new Vector3(8, 4.3f, 0), Quaternion.identity);
            secondEnemy2.SetParent(enemyParent.transform);
            Transform fourthEnemy = (Transform)Instantiate(PrefabManagerScript.Enemies[3], new Vector3(-8, 4.7f, 0), Quaternion.identity);
            fourthEnemy.SetParent(enemyParent.transform);
            Transform fourthEnemy2 = (Transform)Instantiate(PrefabManagerScript.Enemies[3], new Vector3(8, 4.7f, 0), Quaternion.identity);
            fourthEnemy2.SetParent(enemyParent.transform);
        }
        else if (GameControlScript.control.GetCurrentLevel() == 8)
        {
            //spawn level 8 enemies
            Transform secondEnemy = (Transform)Instantiate(PrefabManagerScript.Enemies[1], new Vector3(-8, 4.3f, 0), Quaternion.identity);
            secondEnemy.SetParent(enemyParent.transform);
            Transform secondEnemy2 = (Transform)Instantiate(PrefabManagerScript.Enemies[1], new Vector3(8, 4.3f, 0), Quaternion.identity);
            secondEnemy2.SetParent(enemyParent.transform);
            Transform thirdEnemy = (Transform)Instantiate(PrefabManagerScript.Enemies[2], new Vector3(-8, -0.8f, 0), Quaternion.identity);
            thirdEnemy.SetParent(enemyParent.transform);
            Transform thirdEnemy2 = (Transform)Instantiate(PrefabManagerScript.Enemies[2], new Vector3(8, -0.8f, 0), Quaternion.identity);
            thirdEnemy2.SetParent(enemyParent.transform);
            Transform fourthEnemy = (Transform)Instantiate(PrefabManagerScript.Enemies[3], new Vector3(-8, 4.7f, 0), Quaternion.identity);
            fourthEnemy.SetParent(enemyParent.transform);
            Transform fourthEnemy2 = (Transform)Instantiate(PrefabManagerScript.Enemies[3], new Vector3(8, 4.7f, 0), Quaternion.identity);
            fourthEnemy2.SetParent(enemyParent.transform);
        }



        //attempt at a loop of this, positioning becomes an issue though
        /*
        for(int i = 0; i < GameControlScript.control.GetAmountOfEnemyTypes(); ++i)
        {
            int j = GameControlScript.control.GetEnemiesAlive(i);
            for (; j > 0; --j)
            {
                Transform enemy = (Transform)Instantiate(PrefabManagerScript.Enemies[i], new Vector3(-8, 4.3f, 0), Quaternion.identity);
            }
        }
        */

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
