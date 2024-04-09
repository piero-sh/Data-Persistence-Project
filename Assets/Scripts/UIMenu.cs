using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject invalidNameGO;
    [SerializeField]
    private TMP_InputField nameInputField;

    public void Start()
    {
        GameManager.Instance.LoadBestScore();
    }

    public void StartGame()
    {
        if(string.IsNullOrEmpty(nameInputField.text))
        {
            invalidNameGO.SetActive(true);
            return;
        }
        GameManager.Instance.playerName = nameInputField.text;
        SceneManager.LoadScene("main");
    }
}
