using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour {

	public void ClickExit()
    {
        SceneManager.LoadScene("menu");
        //Application.Quit();
    }
}
