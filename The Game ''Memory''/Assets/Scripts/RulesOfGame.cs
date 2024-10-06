using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RulesOfGame : MonoBehaviour
{
    #region Правила игры "Memory"
    public void Rules(int i)
    {
        switch (i)
        {
            case (0):
                SceneManager.LoadScene("Essence Of Game");
                break;
            case (1):
                SceneManager.LoadScene("Rules Of Single Mode");
                break;
            case (2):
                SceneManager.LoadScene("Rules Of Local Network");
                break;
            case (3):
                SceneManager.LoadScene("Menu Of Game");
                break;
            default:
                break;
        }
    }
    #endregion

    #region Каждый раздел правил игры
    public void OneRule(int i)
    {
        switch (i)
        {
            case (0):
                SceneManager.LoadScene("Rules Of Game");
                break;
            case (1):
                SceneManager.LoadScene("Menu Of Game");
                break;
            default:
                break;
        }
    }
    #endregion
}