using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// UnityEngine - это библиотека, которая подключает различные инструменты и функции,
// предназначенные для работы с игровым взаимодействием в Unity
using UnityEngine.SceneManagement;
// UnityEngine.SceneManagement - это библиотека, которая подключает инструменты и функции 
// для "управления сценами игры"(SceneManagement)

public class RulesOfGame : MonoBehaviour
{
    #region Переменные
    public GameObject Essence;
    // Панель Essence открывается при просмотре раздела правил игры "Суть игры"
    public GameObject SingleMode;
    // Панель SingleMode открывается при просмотре раздела правил игры "Правила одиночного режима"
    public GameObject LocalNetwork;
    // Панель LocalNetwork открывается при просмотре раздела правил игры "Правила режима локальной сети"
    #endregion

    #region Инициализация переменных при запуске игры
    // Use this for initialization
    void Start()
    // Встроенный метод Start используется для инициализация переменных при запуске игры
    {
        Essence.SetActive(false);
        SingleMode.SetActive(false);
        LocalNetwork.SetActive(false);
        // SetActive отвечает за скрытие или показ той или иной панели
        // При выбранном значении "false" панели скрываются
    }
    #endregion

    #region Правила игры "Memory"
    public void Rules(int i)
    // Метод Rules вызывается для осуществления какого-либо действия, совершенного пользователем в разделе правил игры
    {
        switch (i)
        // Функция, которую запрашивает пользователь, нажав какую-то из показанных ему кнопок,
        // выбирается и осуществляется только по числовому значению данной кнопки, которой и соответствует эта функция
        {
            case (0):
                Essence.SetActive(true);
                // SetActive отвечает за скрытие или показ той или иной панели
                // При выбранном значении "true" открывается панель Essence,
                // которая становится действительной при нажатии кнопки "Суть игры"
                break;
            case (1):
                SingleMode.SetActive(true);
                // SetActive отвечает за скрытие или показ той или иной панели
                // При выбранном значении "true" открывается панель SingleMode,
                // которая становится действительной при нажатии кнопки "Правила одиночного режима"
                break;
            case (2):
                LocalNetwork.SetActive(true);
                // SetActive отвечает за скрытие или показ той или иной панели
                // При выбранном значении "true" открывается панель LocalNetwork,
                // которая становится действительной при нажатии кнопки "Правила режима локальной сети"
                break;
            case (3):
                SceneManager.LoadScene("Menu Of Game");
                // При нажатии кнопки "Вернуться в главное меню" осуществляется загрузка новой сцены(SceneManager.LoadScene) 
                // и переход к главному игровому меню("Menu of Game")
                break;
            default:
                break;
        }
    }
    #endregion

    #region Каждый раздел правил игры
    public void OneRule(int i)
    // Метод OnRule вызывается для осуществления какого-либо действия, совершенного пользователем в одном из разделов правил игры
    {
        switch (i)
        // Функция, которую запрашивает пользователь, нажав какую-то из показанных ему кнопок,
        // выбирается и осуществляется только по числовому значению данной кнопки, которой и соответствует эта функция
        {
            case (0):
                {
                    Essence.SetActive(false);
                    SingleMode.SetActive(false);
                    LocalNetwork.SetActive(false);
                    // SetActive отвечает за скрытие или показ той или иной панели
                    // При выбранном значении "false" панели скрываются
                }
                break;
            case (1):
                SceneManager.LoadScene("Menu Of Game");
                // При нажатии кнопки "Переход в главное меню" осуществляется загрузка новой сцены(SceneManager.LoadScene) 
                // и переход к главному игровому меню("Menu of Game")
                break;
            default:
                break;
        }
    }
    #endregion
}