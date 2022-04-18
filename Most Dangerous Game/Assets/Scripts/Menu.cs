using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] string _nextLevelName;
    public GameObject settingsUI;
    public GameObject SceneSelectUI;

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GameSettings()
    {
        settingsUI.SetActive(true);
    }

    public void Close()
    {
        settingsUI.SetActive(false);
    }

    public void CloseLevel()
    {
        SceneSelectUI.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SceneSelection()
    {
        SceneSelectUI.SetActive(true);
    }

    public void LevelOne()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void LevelThree()
    {
        SceneManager.LoadScene("Level 3");

    }

    public void LevelFour()
    {
        SceneManager.LoadScene("Level 4");
    }

    public void LevelFive()
    {
        SceneManager.LoadScene("Level 5");
    }

    public void LevelSix()
    {
        SceneManager.LoadScene("Level 6");
    }
}
