using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyControllerScript : MonoBehaviour {

    public static EnemyControllerScript control;
    public Transform enemyParent;
	private float midXSpawn = 0f;
	private float rightXSpawn = 6f;
	private float leftXSpawn = -6f;
	private float enemy1YSpawn = 4.3f;
	private float enemy2YSpawn = 4.3f;
	private float enemy3YSpawn = -0.8f;
	private float enemy4YSpawn = 4.7f;

	//List<float> -> enemy type, x, y 
	//enemy one spawns, then second, third, fourth etc
	private List<List<float>> enemy1SpawnInfo;
	private List<List<float>> enemy2SpawnInfo;
	private List<List<float>> enemy3SpawnInfo;
	private List<List<float>> enemy4SpawnInfo;

    // Use this for initialization
    void Start () {
        if (control == null)
        {
            control = this;

			enemy1SpawnInfo = new List<List<float>> {new List<float> {0, midXSpawn, enemy1YSpawn} };
			enemy2SpawnInfo = new List<List<float>> {new List<float> {1, leftXSpawn, enemy2YSpawn}, new List<float> {1, rightXSpawn, enemy2YSpawn} };
			enemy3SpawnInfo = new List<List<float>> {new List<float> {2, leftXSpawn, enemy3YSpawn}, new List<float> {2, rightXSpawn, enemy3YSpawn} };
			enemy4SpawnInfo = new List<List<float>> {new List<float> {3, leftXSpawn, enemy4YSpawn}, new List<float> {3, rightXSpawn, enemy4YSpawn} };

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
		Transform firstEnemy = (Transform)Instantiate(PrefabManagerScript.Enemies[(int)enemy1SpawnInfo[0][0]], new Vector3(enemy1SpawnInfo[0][1], enemy2SpawnInfo[0][2], 0), Quaternion.identity);
        firstEnemy.SetParent(enemyParent.transform);
		GameControlScript.control.EnemyCreated(0);

		/* use this if spawn code below becomes unuseable
        if (GameControlScript.control.GetCurrentLevel() == 2)
        {
            //spawn level 2 enemies
			for (int i = 0; i < 2; ++i) {
				Transform enemy2 = (Transform)Instantiate(PrefabManagerScript.Enemies[(int)enemy2SpawnInfo[i][0]], new Vector3(enemy2SpawnInfo[i][1], enemy2SpawnInfo[i][2], 0), Quaternion.identity);
				enemy2.SetParent(enemyParent.transform);
			}
        }
        else if (GameControlScript.control.GetCurrentLevel() == 3)
        {
            //spawn level 3 enemies
			for (int i = 0; i < 2; ++i) {
				Transform enemy3 = (Transform)Instantiate(PrefabManagerScript.Enemies[(int)enemy3SpawnInfo[i][0]], new Vector3(enemy3SpawnInfo[i][1], enemy3SpawnInfo[i][2], 0), Quaternion.identity);
				enemy3.SetParent(enemyParent.transform);
			}
        }
        else if (GameControlScript.control.GetCurrentLevel() == 4)
        {
            //spawn level 4 enemies
			for (int i = 0; i < 2; ++i) {
				Transform enemy4 = (Transform)Instantiate(PrefabManagerScript.Enemies[(int)enemy4SpawnInfo[i][0]], new Vector3(enemy4SpawnInfo[i][1], enemy4SpawnInfo[i][2], 0), Quaternion.identity);
				enemy4.SetParent(enemyParent.transform);
			}
        }
        else if (GameControlScript.control.GetCurrentLevel() == 5)
        {
            //spawn level 5 enemies
			for (int i = 0; i < 2; ++i) {
				Transform enemy2 = (Transform)Instantiate(PrefabManagerScript.Enemies[(int)enemy2SpawnInfo[i][0]], new Vector3(enemy2SpawnInfo[i][1], enemy2SpawnInfo[i][2], 0), Quaternion.identity);
				enemy2.SetParent(enemyParent.transform);
				Transform enemy3 = (Transform)Instantiate(PrefabManagerScript.Enemies[(int)enemy3SpawnInfo[i][0]], new Vector3(enemy3SpawnInfo[i][1], enemy3SpawnInfo[i][2], 0), Quaternion.identity);
				enemy3.SetParent(enemyParent.transform);
			}
        }
        else if (GameControlScript.control.GetCurrentLevel() == 6)
        {
            //spawn level 6 enemies
			for (int i = 0; i < 2; ++i) {
				Transform enemy3 = (Transform)Instantiate(PrefabManagerScript.Enemies[(int)enemy3SpawnInfo[i][0]], new Vector3(enemy3SpawnInfo[i][1], enemy3SpawnInfo[i][2], 0), Quaternion.identity);
				enemy3.SetParent(enemyParent.transform);
				Transform enemy4 = (Transform)Instantiate(PrefabManagerScript.Enemies[(int)enemy4SpawnInfo[i][0]], new Vector3(enemy4SpawnInfo[i][1], enemy4SpawnInfo[i][2], 0), Quaternion.identity);
				enemy4.SetParent(enemyParent.transform);
			}
        }
        else if (GameControlScript.control.GetCurrentLevel() == 7)
        {
            //spawn level 7 enemies
			for (int i = 0; i < 2; ++i) {
				Transform enemy2 = (Transform)Instantiate(PrefabManagerScript.Enemies[(int)enemy2SpawnInfo[i][0]], new Vector3(enemy2SpawnInfo[i][1], enemy2SpawnInfo[i][2], 0), Quaternion.identity);
				enemy2.SetParent(enemyParent.transform);
				Transform enemy4 = (Transform)Instantiate(PrefabManagerScript.Enemies[(int)enemy4SpawnInfo[i][0]], new Vector3(enemy4SpawnInfo[i][1], enemy4SpawnInfo[i][2], 0), Quaternion.identity);
				enemy4.SetParent(enemyParent.transform);
			}
        }
        else if (GameControlScript.control.GetCurrentLevel() == 8)
        {
            //spawn level 8 enemies
			for (int i = 0; i < 2; ++i) {
				Transform enemy2 = (Transform)Instantiate(PrefabManagerScript.Enemies[(int)enemy2SpawnInfo[i][0]], new Vector3(enemy2SpawnInfo[i][1], enemy2SpawnInfo[i][2], 0), Quaternion.identity);
				enemy2.SetParent(enemyParent.transform);
				Transform enemy3 = (Transform)Instantiate(PrefabManagerScript.Enemies[(int)enemy3SpawnInfo[i][0]], new Vector3(enemy3SpawnInfo[i][1], enemy3SpawnInfo[i][2], 0), Quaternion.identity);
				enemy3.SetParent(enemyParent.transform);
				Transform enemy4 = (Transform)Instantiate(PrefabManagerScript.Enemies[(int)enemy4SpawnInfo[i][0]], new Vector3(enemy4SpawnInfo[i][1], enemy4SpawnInfo[i][2], 0), Quaternion.identity);
				enemy4.SetParent(enemyParent.transform);
			}
        }
		*/

		//this works for when only 2 of every enemy type is being spawned
		for (int i = 0; i < 2; ++i) {
			if ((GameControlScript.control.GetCurrentLevel () == 2) || (GameControlScript.control.GetCurrentLevel () == 5) || (GameControlScript.control.GetCurrentLevel () == 7) || (GameControlScript.control.GetCurrentLevel () == 8)) {
				Transform enemy2 = (Transform)Instantiate (PrefabManagerScript.Enemies [(int)enemy2SpawnInfo [i] [0]], new Vector3 (enemy2SpawnInfo [i] [1], enemy2SpawnInfo [i] [2], 0), Quaternion.identity);
				enemy2.SetParent (enemyParent.transform);
				GameControlScript.control.EnemyCreated(1);
			}
			if ((GameControlScript.control.GetCurrentLevel () == 3) || (GameControlScript.control.GetCurrentLevel () == 5) || (GameControlScript.control.GetCurrentLevel () == 6) || (GameControlScript.control.GetCurrentLevel () == 8)) {
				Transform enemy3 = (Transform)Instantiate (PrefabManagerScript.Enemies [(int)enemy3SpawnInfo [i] [0]], new Vector3 (enemy3SpawnInfo [i] [1], enemy3SpawnInfo [i] [2], 0), Quaternion.identity);
				enemy3.SetParent (enemyParent.transform);
				GameControlScript.control.EnemyCreated(2);
			}
			if ((GameControlScript.control.GetCurrentLevel () == 4) || (GameControlScript.control.GetCurrentLevel () == 6) || (GameControlScript.control.GetCurrentLevel () == 7) || (GameControlScript.control.GetCurrentLevel () == 8)) {
				Transform enemy4 = (Transform)Instantiate (PrefabManagerScript.Enemies [(int)enemy4SpawnInfo [i] [0]], new Vector3 (enemy4SpawnInfo [i] [1], enemy4SpawnInfo [i] [2], 0), Quaternion.identity);
				enemy4.SetParent (enemyParent.transform);
				GameControlScript.control.EnemyCreated(3);
			}
		}

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
