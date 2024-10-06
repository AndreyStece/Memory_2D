using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocalNetwork : MonoBehaviour
{
    #region Возврат или выход из текущей игры
    public void Return()
    {
        SceneManager.LoadScene("Menu Of Game");
    }
    #endregion
}