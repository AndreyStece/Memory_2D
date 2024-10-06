using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagementOfGame : MonoBehaviour
{
    #region Приостановка текущей игры
    public void Stop()
    {
        Time.timeScale = 0;
        Pause.SetActive(true);
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
                    Time.timeScale = 1;
                    Pause.SetActive(false);
                }
                break;
            default:
                break;
        }
    }
    #endregion

    #region Изменяемые переменные
    private float Label;
    public GameObject[] CardsOfGame;
    public Sprite BackOfCard;
    public Sprite[] FaceOfCards;
    List<int> Digit;
    int K;
    private int Number;
    private bool Key;
    private bool[] DKey;
    private bool Jey;
    private bool Zed;
    private float Times;
    private int Pairs;
    public Text Timer;
    public Text CloseCards;
    public GameObject Pause;
    #endregion

    #region Инициализация переменных при запуске игры
    // Use this for initialization
    void Start()
    {
        Label = Mathf.Round(CardsOfGame.Length / 8) - 1;
        Digit = new List<int>();
        K = 0;
        DKey = new bool[CardsOfGame.Length];
        for (int i = 0; i < CardsOfGame.Length; i++)
        { DKey[i] = false; }
        Jey = false;
        Zed = true;
        Times = 59;
        Pairs = CardsOfGame.Length / 2;
    }
    #endregion

    #region Методы, выполняющиеся при каждом действии на сцене игры
    // Update is called once per frame
    void Update()
    {
        #region Установка таймера
        if (Label <= 0 && Mathf.Round(Times) == 0)
        {
            SceneManager.LoadScene("Loser Of ''Memory''");
        }

        Times -= Time.deltaTime;

        if (Times > 10)
        {
            Timer.text = "Время: " + (Mathf.Round((Times + 30) / 60) - 1 + Label) + ":" + Mathf.Round(Times);
        }
        else if (Times <= 9.5 && Times >= 0)
        {
            Timer.text = "Время: " + (Mathf.Round((Times + 30) / 60) - 1 + Label) + ":0" + Mathf.Round(Times);
        }
        else if (Label != 0 && Times < -0.5)
        {
            Timer.text = "Время: " + Label + ":00";
            Times = 59.5f;
            Label--;
        }
        #endregion

        if (Zed)
        { LoadingValuesImages(); }

        if (Input.GetMouseButtonUp(0))
        { EductionOfCards(); }
    }
    #endregion

    #region Инициализация значений лицевых сторон для карточек игры
    void LoadingValuesImages()
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 1; j < (CardsOfGame.Length) / 2 + 1; j++)
            {
                Key = true;
                while (Key)
                {
                    Number = Random.Range(0, CardsOfGame.Length);
                    Key = DKey[Number];
                }
                CardsOfGame[Number].GetComponent<Cards>().SValueOfCard = j;
                DKey[Number] = true;
            }
        }

        foreach (GameObject Card in CardsOfGame)
        { Card.GetComponent<Cards>().Images(); }

        if (Zed)
        { Zed = false; }
    }
    #endregion

    #region Получение текстур для карточек
    public Sprite LoadingBackOfCard()
    { return BackOfCard; }

    public Sprite LoadingFaceOfCards(int i)
    { return FaceOfCards[i - 1]; }
    #endregion

    #region Выделение 2-х выбранных карточек
    void EductionOfCards()
    {
        Digit = new List<int>();
        for (int i = 0; i < CardsOfGame.Length; i++)
        {
            if (CardsOfGame[i].GetComponent<Cards>().SKey == true && CardsOfGame[i].GetComponent<Cards>().SJey == false)
            {
                print(CardsOfGame[i].GetComponent<Cards>().SKey);
                Digit.Add(i);
            }
        }

        if (Digit.Count == 2)
        { CompareOfCards(Digit); }
    }
    #endregion

    #region Сравнение значений 2-х выбранных карточек
    void CompareOfCards(List<int> Digit)
    {
        Jey = false;
        Cards.Zed = false;
        if (CardsOfGame[Digit[0]].GetComponent<Cards>().SValueOfCard == CardsOfGame[Digit[1]].GetComponent<Cards>().SValueOfCard)
        {
            Jey = true;
            Pairs--;
            CloseCards.text = "Количество не раскрывшихся пар: " + Pairs;
            if (Pairs == 0)
            {
                SceneManager.LoadScene("Winner Of ''Memory''");
            }
        }
        else
        {
            CardsOfGame[Digit[0]].GetComponent<Cards>().SKey = false;
            CardsOfGame[Digit[1]].GetComponent<Cards>().SKey = false;
        }

        for (int i = 0; i < Digit.Count; i++)
        {
            CardsOfGame[Digit[i]].GetComponent<Cards>().SJey = Jey;
            CardsOfGame[Digit[i]].GetComponent<Cards>().CheckPoint();
        }
    }
    #endregion
}