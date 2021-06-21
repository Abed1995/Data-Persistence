using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Transform holder;

     TextMeshPro scoreText;
     TMP_InputField playerName;

    private void Start()
    {
        playerName = holder.Find("Player Name").GetComponent<TMP_InputField>();
        

    }
    public void StartButton()
    {
        GameManager.Instance.newPlayerName =playerName.text ;
        SceneManager.LoadScene(1);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
