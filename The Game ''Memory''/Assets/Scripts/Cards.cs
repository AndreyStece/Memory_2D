using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cards : MonoBehaviour 
{
    #region Изменяемые переменные
    [SerializeField]
    private int ValueOfCard;
    [SerializeField]
    private Sprite BackOfCard;
    [SerializeField]
    private Sprite FaceOfCard;
    [SerializeField]
    private bool Key;
    private bool Jey;
    public static bool Zed;
    private GameObject Management;
    #endregion

    #region Свойства отдельных переменных
    public int SValueOfCard
    {
        get { return ValueOfCard; }
        set { ValueOfCard = value; }
    }

    public bool SKey
    {
        get { return Key; }
        set { Key = value; }
    }

    public bool SJey
    {
        get { return Jey; }
        set { Jey = value; }
    }
    #endregion

    #region Инициализация переменных при запуске игры
    // Use this for initialization
    void Start ()
    {
        Key = false;
        Jey = false;
        Zed = true;
        Management = GameObject.FindGameObjectWithTag("Management");
    }
    #endregion

    #region Первоначальная загрузка текстур для карточек
    public void Images()
    {
        BackOfCard = Management.GetComponent<ManagementOfGame>().LoadingBackOfCard();
        FaceOfCard = Management.GetComponent<ManagementOfGame>().LoadingFaceOfCards(ValueOfCard);
        GetComponent<Image>().sprite = BackOfCard;
    }
    #endregion

    #region Перелистывание карт при нажатии на них
    public void FlippingOfCards()
    {
        if (Key == false && Jey == false && Zed == true)
        {
            Key = true;
            GetComponent<Image>().sprite = FaceOfCard;
        }
        else
        if (Key == true && Jey == false && Zed == true)
        {
            Key = false;
            GetComponent<Image>().sprite = BackOfCard;
        }
    }
    #endregion

    #region Приостановление действий на сцене игры, пока не произойдут завершающие шаги
    public void CheckPoint()
    { StartCoroutine(pause()); }
    #endregion

    #region MyRegion
    IEnumerator pause()
    {
        yield return new WaitForSeconds(0.5f);
        if (Key == false)
        { GetComponent<Image>().sprite = BackOfCard; }
        else if (Key == true)
        { GetComponent<Image>().sprite = FaceOfCard; }
        Zed = true;
    }
    #endregion
}