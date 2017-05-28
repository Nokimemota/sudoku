using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

    public Text buttonText;
    public void Game(string diff)
    {
        MyData.difficulty = buttonText.text.ToString();
        SceneManager.LoadScene("game");  
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
