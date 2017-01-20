using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("q"))
        {
            GameControlScript.control.ChooseScene(1);
        }
	}

    void OnMouseOver()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Play was clicked on -> ");

            GameControlScript.control.ChooseScene(1);
        }
    }
}
