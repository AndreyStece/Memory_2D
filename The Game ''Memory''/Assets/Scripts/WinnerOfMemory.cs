using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinnerOfMemory : MonoBehaviour
{
    #region Переход в главное меню или к выбору уровня сложности
    public void Win(int i)
    {
        switch (i)
        {
            case (0):
                SceneManager.LoadScene("Menu Of Game");
                break;
            case (1):
                SceneManager.LoadScene("Single Mode");
                break;
            default:
                break;
        }
    }
    #endregion
}