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
    private bool inGame = false;

    private int currentLevel;

    public AudioClip mainMenuMusic;
    public AudioClip inGameMusic;
    public AudioClip playerDiedSound;
    
    private bool playingPlayerDiedSound = false;

	private Vector2 lavaSpeed = new Vector2 (0, 0.01f);
	private Collider2D lavaCollider;

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

        Object.DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        MusicLoop();

        //Object.DontDestroyOnLoad(gameObject);
    }

    public void MusicLoop()
    {
        //Debug.Log(playingPlayerDiedSound);
        if (!GetComponent<AudioSource>().isPlaying && !playingPlayerDiedSound)
        {
            if (inGame)
            {
                GetComponent<AudioSource>().PlayOneShot(inGameMusic, 1);
            } 
            else
            {
                GetComponent<AudioSource>().PlayOneShot(mainMenuMusic, 1);
            }
        }
    }

    IEnumerator PlayerDiedSoundWait()
    {
        //delay until main music restarts
        yield return new WaitForSeconds(3);
        playingPlayerDiedSound = false;
    }


    //change music based off changing game state
    private void ChangeInGame(bool isInGame, bool didPlayerDie = false)
    {
        
        if(inGame && isInGame)
        {
            //do nothing, keep playing In Game Music
        }
        else if (inGame && !isInGame)
        {
            //switch to main menu music and play player death sound first if they died
            
            if (didPlayerDie)
            {
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().PlayOneShot(playerDiedSound, 1);

                //so music doesn't start from the looping function
                playingPlayerDiedSound = true;
                StartCoroutine(PlayerDiedSoundWait());
            }
            else
            {
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().PlayOneShot(mainMenuMusic, 1);
            }
        }
        else if (!inGame && isInGame)
        {
            //switch to In Game Music
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().PlayOneShot(inGameMusic, 1);
        }
        else if (!inGame && !isInGame)
        {
            //do nothing keep playing menu music
        }
        inGame = isInGame;
        
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
        ChangeInGame(false, true);
        SceneManager.LoadScene("Main_Menu");
    }

    public void LastEnemyDefeated()
    {
        ChangeScene();
    }

    //for when the player beats a stage
    public void ChangeScene()
    {
        ChangeInGame(true);
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
            SetLevel(5);
            LevelStarted();
            SceneManager.LoadScene("Level_5");

        }
        else if (sceneName == "Level_5")
        {
            SetLevel(6);
            LevelStarted();
            SceneManager.LoadScene("Level_6");
        }
        else if (sceneName == "Level_6")
        {
            SetLevel(7);
            LevelStarted();
            SceneManager.LoadScene("Level_7");
        }
        else if (sceneName == "Level_7")
        {
            SetLevel(8);
            LevelStarted();
            SceneManager.LoadScene("Level_8");
        }
		else if (sceneName == "Level_8")
		{
			SetLevel(9);
			LevelStarted();
			SceneManager.LoadScene("Level_9");
		}
        else if (sceneName == "Level_9")
        {
			ChangeInGame(false);
            SceneManager.LoadScene("Main_Menu");
        }
    }

    //for when choosing level from start screen
    public void ChooseScene(int LevelChosen)
    {
        ChangeInGame(true);
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
        else if (LevelChosen == 5)
        {
            SetLevel(5);
            LevelStarted();
            SceneManager.LoadScene("Level_5");
        }
        else if (LevelChosen == 6)
        {
            SetLevel(6);
            LevelStarted();
            SceneManager.LoadScene("Level_6");
        }
        else if (LevelChosen == 7)
        {
            SetLevel(7);
            LevelStarted();
            SceneManager.LoadScene("Level_7");
        }
        else if (LevelChosen == 8)
        {
            SetLevel(8);
            LevelStarted();
            SceneManager.LoadScene("Level_8");
        }
		else if (LevelChosen == 9)
		{
			SetLevel(9);
			LevelStarted();
			SceneManager.LoadScene("Level_9");
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
    }

	public void EnemyCreated(int enemyType) {
		enemiesAlive[enemyType] += 1;
		//Debug.Log (enemyType + " " + enemyType + " -> " + enemiesAlive [enemyType]);
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

	public Vector2 GetLavaSpeed(){
		return lavaSpeed;
	}

	public void SetLavaSpeed(Vector2 tempSpeed) {
		lavaSpeed = tempSpeed;
	}

	public Collider2D GetLavaCollider() {
		return lavaCollider;
	}

	public void SetLavaCollider(Collider2D newCollider) {
		lavaCollider = newCollider;
	}
}
