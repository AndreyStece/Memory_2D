using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTheGame : MonoBehaviour
{
    #region Переменная игрового объекта
    
    #endregion

    #region Инициализация игрового объекта
    // Use this for initialization
    void Start()
    {
        
    }
    #endregion

    #region Возврат или выход из текущей игры
    public void Desires(int i)
    {
        switch (i)
        {
            case (0):
                SceneManager.LoadScene("Menu Of Game");
                break;
            case (1):
                SceneManager.LoadScene("Single Mode");
                break;
            case (2):
                {
                    ManagementOfGame g = new ManagementOfGame();
                    SceneManager.LoadScene("Single mode");
                    g.Exit(1);
                }
                break;
            default:
                break;
        }
    }
    #endregion
}