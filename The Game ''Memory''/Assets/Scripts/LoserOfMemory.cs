using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoserOfMemory : MonoBehaviour
{
    #region Переход в главное меню или к выбору уровня сложности
    public void Lose(int i)
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