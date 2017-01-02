using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameControlScript : MonoBehaviour {

    private int amountOfLevels = 4;
    private int amountOfEnemyTypes = 4;
    public static GameControlScript control;
    //4 is amount of levels in the game, each level has new enemy which takes up new slot in list
    // [0] for enemy 1, [1] for enemy 2, etc
    private List<int> enemiesAlive = new List<int>();
    //private bool inGame = false;

    private int currentLevel;

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
        for (int i = 0; i < amountOfLevels; ++i)
        {
            enemiesAlive.Add(0);
        }

    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void SetLevel(int level)
    {
        currentLevel = level;
    }

    private void CheckLevelFinished()
    {
        if (enemiesAlive[0] == 0)
        {
            ChangeScene();
            currentLevel += 1;
        }
    }

    public void PlayerDefeated()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void LastEnemyDefeated()
    {
        ChangeScene();
    }

    //for when the player beats a stage
    public void ChangeScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        //set scene and number of enimies in it for each change
        if (sceneName == "Level_1")
        {
            //need set level first since level started needs level check
            SetLevel(2);
            LevelStarted();
            SceneManager.LoadScene("Level_2");
        }
        else if (sceneName == "Level_2")
        {
            SetLevel(3);
            LevelStarted();
            SceneManager.LoadScene("Level_3");
        }
        else if (sceneName == "Level_3")
        {
            SetLevel(4);
            LevelStarted();
            SceneManager.LoadScene("Level_4");
        }
        else if (sceneName == "Level_4")
        {
            SceneManager.LoadScene("Main_Menu");
            //inGame = false;
        }
    }

    //for when choosing level from start screen
    public void ChooseScene(int LevelChosen)
    {
        //set scene and number of enimies in it for each change
        if (LevelChosen == 1)
        {
            SetLevel(1);
            LevelStarted();
            SceneManager.LoadScene("Level_1");
        }
        else if (LevelChosen == 2)
        {
            SetLevel(2);
            LevelStarted();
            SceneManager.LoadScene("Level_2");
        }
        else if (LevelChosen == 3)
        {
            SetLevel(3);
            LevelStarted();
            SceneManager.LoadScene("Level_3");
        }
        else if (LevelChosen == 4)
        {
            SetLevel(4);
            LevelStarted();
            SceneManager.LoadScene("Level_4");
        }
    }

    public void EnemyDied(int enemyNumber)
    {
        //Debug.Log("Game Control EnemyDied");
        if (enemyNumber >= 0 && enemyNumber < amountOfEnemyTypes)
        {
            enemiesAlive[enemyNumber] -= 1;
            EnemyControllerScript.control.EnemyDied(enemyNumber);
        }
    }

    public void LevelStarted()
    {
        //reset enemies alive
        for (int i = 0; i < amountOfEnemyTypes; ++i) {
            enemiesAlive[i] = 0;
        }
        //set the enemies that are alive manually for each level
        if (currentLevel == 1)
        {
            enemiesAlive[0] = 1;
        }
        else if (currentLevel == 2)
        {
            enemiesAlive[0] = 1;
            enemiesAlive[1] = 2;
        }
        else if (currentLevel == 3)
        {
            enemiesAlive[0] = 1;
            enemiesAlive[1] = 2;
            enemiesAlive[2] = 2;
        }
        else if (currentLevel == 4)
        {
            enemiesAlive[0] = 1;
            enemiesAlive[1] = 2;
            enemiesAlive[2] = 2;
            enemiesAlive[3] = 2;
        }
    }

    public int GetEnemiesAlive(int enemyType)
    {
        //Debug.Log("Get Enemies Alive");
        if (enemyType >= 0 && enemyType < amountOfEnemyTypes)
        {
            //Debug.Log(enemiesAlive[enemyType].ToString());
            return enemiesAlive[enemyType];
        }
        else //return invalid value
        {
            return -1;
        }
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public int GetAmountOfEnemyTypes()
    {
        return amountOfEnemyTypes;
    }
}
