using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class GameController : MonoBehaviour {

    public Text[] buttonList;
    public string PlayerSide;
    private int[,] board = new int[9, 9];
    private int[,] pattern = new int [9,9];
    public Text timerText;
    private float startTime;
    bool finished = false;
    string diff;
    int clues, r;
    
    void Awake()
    {        
        startTime = Time.time; //start timer
        diff =  MyData.difficulty;
        SetGameControllerReferenceOnButtons();       
        string s = "";        
        TextAsset asset = Resources.Load<TextAsset>("Sudoku");
        string[] e = asset.text.Split('\n');
        r = Random.Range(0, 500);
        s = e[r];
        e = null;        
        string[] f = s.Split(' ');               
        for (int i = 0; i < f.Length; i++)//read pattern into array
        {
            int q;
            int.TryParse(f[i], out q);
            pattern[i / 9, i % 9] = q;
        }
        int w;
        switch (diff)
        {
            case "Easy":
                clues = Random.Range(27, 32);
                break;
            case "Medium":
                clues = Random.Range(22, 27);
                break;
            case "Hard":
                clues =  Random.Range(17, 22);
                break;
        }
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].text = " ";
        }
            for (int i = 0; i < clues; i++)
        {
            w = Random.Range(0, 80);
            Debug.Log(w);
            if (w < buttonList.Length && buttonList[w] != null)
            {
                buttonList[w].text = pattern[w / 9, w % 9].ToString();
                var Component = buttonList[w].GetComponentInParent<Button>();
                if (Component != null)
                {
                    Component.interactable = false;
                }
            }
        }

    }

    void SetGameControllerReferenceOnButtons()
    {
        for(int i=0;i< buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public void SetSide(string Side)
    {

        PlayerSide = Side;
    }

    public string GetPlayerSide()
    {
        return PlayerSide;
    }

    public void EndTurn()
    {    
        string t;
        int u;
        
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                t = buttonList[j * 9 + i].text.ToString();
                int.TryParse(t, out u);
                board[j, i] = u;
            }
        }
        bool isValid = true;
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (board[j, i] != pattern[j, i])
                    isValid = false;
            }
        }

        if (isValid.Equals(true))
            GameOver();
    }

    private void GameOver()
    {
        finished = true;
        for (int i = 0; i < buttonList.Length; i++)
            buttonList[i].GetComponentInParent<Button>().interactable = false;
        Debug.Log(diff + " ;" + r + " ;" + timerText.text);
        //Application.ExternalCall(functionName, diff, r, timerText.text);
    }
    public void Reset()
    {
        for (int i = 0; i < buttonList.Length; i++)
            if (buttonList[i].GetComponentInParent<Button>().interactable == true)
                buttonList[i].text = " ";
    }
    void Update()
    {
        if (finished)
            return;
        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        timerText.text = minutes + ":" + seconds;
    }
}
