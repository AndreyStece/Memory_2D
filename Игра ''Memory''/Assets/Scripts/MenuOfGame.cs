using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// UnityEngine - это библиотека, которая подключает различные инструменты и функции, 
// предназначенные для работы с игровым взаимодействием в Unity
using UnityEngine.SceneManagement; 
// UnityEngine.SceneManagement - это библиотека, которая подключает инструменты и функции 
// для "управления сценами игры"(SceneManagement)

public class MenuOfGame : MonoBehaviour
{
    #region Меню игры "Memory"
    public void Menu(int i)
    // Метод Menu вызывается для осуществления какого-либо действия, совершенного пользователем в игровом меню
    {
        switch (i)
        // Функция, которую запрашивает пользователь, нажав какую-то из показанных ему кнопок,
        // выбирается и осуществляется только по числовому значению данной кнопки, которой и соответствует эта функция
        {
            case (0):
                SceneManager.LoadScene("Single Mode");
                // При нажатии кнопки "Одиночный режим" осуществляется загрузка новой сцены(SceneManager.LoadScene) 
                // и переход к выбору уровня сложности("Single Mode")
                break;
            case (1):
                SceneManager.LoadScene("Local Network");
                // При нажатии кнопки "Локальная сеть" осуществляется загрузка новой сцены(SceneManager.LoadScene) 
                // и переход игры в режим локальной сети("Local Network")
                break;
            case (2):
                SceneManager.LoadScene("Rules Of Game");
                // При нажатии кнопки "Правила игры" осуществляется загрузка новой сцены(SceneManager.LoadScene) 
                // и переход к просмотру правил игры("Rules Of Game")
                break;
            case (3):
                Application.Quit();
                // При нажатии кнопки "Выход из игры" осуществляется завершение самой игры и выход из нее(Application.Quit)
                break;
            default:
                break;
        }
    }
    #endregion
}