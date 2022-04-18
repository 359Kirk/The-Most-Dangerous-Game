using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] string _nextLevelName;
    public GameObject WinScreen;
    public GameObject LossScreen;
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;
    public GameObject Elephant;
    Monster[] _hunters;
    

    void OnEnable()
    {
        _hunters = FindObjectsOfType<Monster>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MonstersAreAllDead())
        {
            DisplayWinScreen();
        }
    }

    public float AttemptStart = 6f;
    private int AttemptRem = 6;
    public int attempts
    {
        get { return AttemptRem; }
        set
        {
            AttemptRem = value;
            if (AttemptRem < 0)
            {
                if (MonstersAreAllDead())
                {
                    DisplayWinScreen();
                    Time.timeScale = 0f;
                }
                else
                {
                    DisplayLossScreen();
                    Time.timeScale = 0f;
                }
            }
        }
    }

    private void DisplayLossScreen()
    {
        LossScreen.SetActive(true);
    }

    private void DisplayWinScreen()
    {
        WinScreen.SetActive(true);
        if ((AttemptRem / AttemptStart) >= .75)
        {
            Star1.SetActive(true);
            Star2.SetActive(true);
            Star3.SetActive(true);
        }
        else if ((AttemptRem / AttemptStart) >= .50)
        {
            Star1.SetActive(true);
            Star2.SetActive(true);
            Star3.SetActive(false);
        }
        else
        {
            Star1.SetActive(true);
            Star2.SetActive(false);
            Star3.SetActive(false);
        }
    }

    public void GoToNextLevel()
    {
        Debug.Log("Go To Level" + _nextLevelName);
        SceneManager.LoadScene(_nextLevelName);
    }

    bool MonstersAreAllDead()
    {
        foreach (var monster in _hunters)
        {
            if (monster.gameObject.activeSelf)
            {
                return false;
            }
        }

        return true;
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Attempts Left: " + AttemptRem);
    }

}
