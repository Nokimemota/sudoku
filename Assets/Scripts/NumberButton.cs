using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberButton : MonoBehaviour {

    public Button button;
    public Text buttonText;
    private GameController gameController;

    public void SetGameControllerReference(GameController controller)
        {
            gameController = controller;
        }

    public void SetSide()
    {

        gameController.PlayerSide = "5";
        
        button.interactable = false;
        gameController.EndTurn();
    }

    
}
