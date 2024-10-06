using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOfGame : MonoBehaviour
{
    #region Меню игры "Memory"
    public void Menu(int i)
    {
        switch (i)
        {
            case (0):
                SceneManager.LoadScene("Single Mode");
                break;
            case (1):
                SceneManager.LoadScene("Local Network");
                break;
            case (2):
                SceneManager.LoadScene("Rules Of Game");
                break;
            case (3):
                Application.Quit();
                break;
            default:
                break;
        }
    }
    #endregion
}