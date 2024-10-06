using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleMode : MonoBehaviour
{
    #region Одиночный(однопользовательский) режим
    public void Single(int j)
    {
        switch (j)
        {
            case (0):
               SceneManager.LoadScene("Single Mode(12)");
                break;
            case (1):
                SceneManager.LoadScene("Single Mode(18)");
                break;
            case (2):
                SceneManager.LoadScene("Single Mode(24)");
                break;
            case (3):
                SceneManager.LoadScene("Menu of Game");
                break;
            default:
                break;
        }
    }
    #endregion
}