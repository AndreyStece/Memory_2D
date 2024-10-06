using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
// UnityEngine - это библиотека, которая подключает различные инструменты и функции,
// предназначенные для работы с игровым взаимодействием в Unity
using UnityEngine.SceneManagement; 
// UnityEngine.SceneManagement - это библиотека, которая подключает инструменты и функции 
// для "управления сценами игры"(SceneManagement)

public class SingleMode : MonoBehaviour
{
    #region Одиночный(однопользовательский) режим
    public void Single(int i)
    // Метод Single вызывается для осуществления какого-либо действия, совершенного пользователем при выборе уровня сложности
    {
        switch (i)
        // Функция, которую запрашивает пользователь, нажав какую-то из показанных ему кнопок,
        // выбирается и осуществляется только по числовому значению данной кнопки, которой и соответствует эта функция
        {
            case (0):
                SceneManager.LoadScene("Single Mode(12)");
                // При нажатии кнопки "Легкий уровень" осуществляется загрузка новой сцены(SceneManager.LoadScene) 
                // и переход к игре с легким уровнем сложности("Single Mode(12)")
                break;
            case (1):
                SceneManager.LoadScene("Single Mode(18)");
                // При нажатии кнопки "Средний уровень" осуществляется загрузка новой сцены(SceneManager.LoadScene) 
                // и переход к игре со средним уровнем сложности("Single Mode(18)")
                break;
            case (2):
                SceneManager.LoadScene("Single Mode(24)");
                // При нажатии кнопки "Сложный уровень" осуществляется загрузка новой сцены(SceneManager.LoadScene) 
                // и переход к игре со сложным уровнем сложности("Single Mode(24)")
                break;
            case (3):
                SceneManager.LoadScene("Menu of Game");
                // При нажатии кнопки "Вернуться в главное меню" осуществляется загрузка новой сцены(SceneManager.LoadScene) 
                // и переход к главному игровому меню("Menu of Game")
                break;
            default:
                break;
        }
    }
    #endregion
}