using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// UnityEngine - это библиотека, которая подключает различные инструменты и функции,
// предназначенные для работы с игровым взаимодействием в Unity
using UnityEngine.UI;

public class Cards : MonoBehaviour
{
    #region Изменяемые переменные
    [SerializeField]
    private int ValueOfCard;
    // Значение ValueOfCard определяется числовым значением
    [SerializeField]
    private Sprite FaceOfCard;
    // Изображение FaceOfCard определяется изображением лицевой(передней) стороной карточки
    [SerializeField]
    private Sprite BackOfCard;
    // Изображение BackOfCard определяется изображением обратной(задней) стороной карточки
    private GameObject Management;
    // Объект Management предназначен для установки связи с игровыми объектами из класса ManagementGame
    [SerializeField]
    private bool Key;
    // Значение Key определяется за счет нажатия на одну из карточек текущей игры
    [SerializeField]
    private bool Jey;
    // Значение Jey определяется за счет раскрытия одинаковой пары карточек
    private static bool Zed;
    // Значение Zed отвечает за доступ к перелистыванию карточек во время игровых действий

    #region Переменные для режима локальной сети
    public NetworkView Synchronization;
    // NetworkView - это компактный и мощный инструмент обнаружения и управления сетью
    // Обнаруживает TCP/IP-узлов в сети, а также TCP-порты
    // Значение переменной Synchronization класса NetworkView обеспечивает синхронизацию между сервером и подключенным к нему клиентом
    private GameObject NetworkManagement;
    // Объект NetworkManagement предназначен для установки связи с игровыми объектами из класса ManagementOfNetworkGame
    ManagementOfNetworkGame Net = new ManagementOfNetworkGame();
    // Переменная класса ManagementOfNetworkGame 
    #endregion

    #endregion

    #region Свойства отдельных переменных
    // Свойства осуществляют более безопасный доступ к данным переменным
    public bool SZed
    {
        get { return Zed; }
        set { Zed = value; }
    }

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
    void Start()
    // Встроенный метод Start используется для инициализация переменных при запуске игры
    {
        Management = GameObject.FindGameObjectWithTag("Management");
        // Объект Management устанавливает связь с игровым объектом "Маnagement Of Game" с помощью тега "Management"
        // и приобретает доступ к игровым элементам этого объекта(количество карточек, значение лицевых и задних сторон и тд.)
        Key = false;
        // При запуске игры нажатие на одну из карточек этой игры не осуществлялось,
        // поэтому значение Key равно false
        Jey = false; 
        // При запуске игры нахождение одинаковой пары карточек не осуществлялось,
        // поэтому значение Jey равно false
        Zed = true;
        // При запуске игры доступ к перелистыванию карточек разрешен,
        // поэтому значение Zed равно true

        #region Инициализация переменных для режима локальной сети
        Synchronization = GetComponent<NetworkView>();
        // При запуске игры инициализируется значение Synchronization
        NetworkManagement = GameObject.FindGameObjectWithTag("NetworkManagement");
        // Объект Management устанавливает связь с игровым объектом "Маnagement Of Network Game" с помощью тега "NetworkManagement"
        // и приобретает доступ к игровым элементам этого объекта(количество карточек, значение лицевых и задних сторон и тд.)
        #endregion

    }
    #endregion

    #region Первоначальная загрузка текстур для карточек(метод для одиночного режима)
    public void Images()
    // Метод Images отвечает за присвоение значений сторон для выбранной карточки
    {
        FaceOfCard = Management.GetComponent<ManagementOfGame>().LoadingFaceOfCards(ValueOfCard);
        // С помощью объекта Management вызывается метод LoadingFaceOfCard из класса ManagementOfNetworkGame
        // для получения и присвоения лицевой(передней) стороны карточки за счет ее числового значения ValueOfCard
        BackOfCard = Management.GetComponent<ManagementOfGame>().LoadingBackOfCard();
        // С помощью объекта Management вызывается метод LoadingBackOfCard из класса ManagementOfNetworkGame
        // для получения и присвоения обратной(задней) стороны карточки
        GetComponent<Image>().sprite = BackOfCard;
        // Первоначальная загрузка обратной(задней) стороны карточки при запуске игры
    }
    #endregion

    #region Первоначальная загрузка текстур для карточек(метод для режима локальной сети)
    public void NetworkImages()
    // Метод Images отвечает за присвоение значений сторон для выбранной карточки
    {
        FaceOfCard = NetworkManagement.GetComponent<ManagementOfNetworkGame>().LoadingFaceOfCards(ValueOfCard);
        // С помощью объекта Management вызывается метод LoadingFaceOfCard из класса ManagementOfNetworkGame
        // для получения и присвоения лицевой(передней) стороны карточки за счет ее числового значения ValueOfCard
        BackOfCard = NetworkManagement.GetComponent<ManagementOfNetworkGame>().LoadingBackOfCard();
        // С помощью объекта Management вызывается метод LoadingBackOfCard из класса ManagementOfNetworkGame
        // для получения и присвоения обратной(задней) стороны карточки
        GetComponent<Image>().sprite = BackOfCard;
        // Первоначальная загрузка обратной(задней) стороны карточки при запуске игры
    }
    #endregion

    #region Перелистывание карт при нажатии на них(метод для одиночного режима)
    public void FlippingOfCards()
    // Метод FlippingOfCards отвечает за перелистывание карточек за счет нажатия на них
    {
        if (Key == false && Jey == false && Zed == true)
        // Если карта не была ранее выбрана, и она не является раскрытой, а доступ к перелистыванию разрешен, тогда...
        {
            Key = true;
            // Карта становится выделенной, поэтому значение Key равно true
            GetComponent<Image>().sprite = FaceOfCard;
            // Карточка переворачивается, и осуществляется показ лицевой(передней) стороны карточки
        }
        else
        if (Key == true && Jey == false && Zed == true)
        // Если карта была ранее выбрана, и она не является раскрытой, а доступ к перелистыванию разрешен, тогда...
        {
            Key = false;
            // Карта перестает быть выделенной, поэтому значение Key равно false
            GetComponent<Image>().sprite = BackOfCard;
            // Карточка переворачивается, и осуществляется показ обратной(задней) стороны карточки
        }
    }
    #endregion

    #region Перелистывание карт при нажатии на них(метод для режима локальной сети)
    public void NetworkFlipping()
    // Метод NetworkFlipping отвечает за перелистывание карточек за счет нажатия на них
    // и вызывается в режиме локальной сети
    {
        if ((Network.isServer && Net.Sserver == true) || (Network.isClient && Net.Sclient == true))
        // Если игрок является сервером и текущий ход присужден серверу или 
        // если игрок является клиентом и текущий ход присужден клиенту, тогда вызывается метод Flipping для перелистывание карточек
        {
            Synchronization = GetComponent<NetworkView>();
            Synchronization.RPC("Flipping", RPCMode.All, null);
            // С помощью функции RPC вызываем метод Flipping, используя режим RPCMode.All,
            // который вызывает этот метод на всех подключенных компьюерах, не передавая никаких параметров в этот метод
        }
    }

    [RPC]
    // Функция обязана быть помеченной как RPC перед тем как её можно будет запускать удаленно
    public void Flipping()
    // Метод Flipping осуществляет перелистывание карточек за счет нажатия на них
    // и вызывается в режиме локальной сети
    {
        if (Key == false && Jey == false && Zed == true)
        // Если карта не была ранее выбрана, и она не является раскрытой, а доступ к перелистыванию разрешен, тогда...
        {
            Key = true;
            // Карта становится выделенной, поэтому значение Key равно true
            GetComponent<Image>().sprite = FaceOfCard;
            // Карточка переворачивается, и осуществляется показ лицевой(передней) стороны карточки
        }
        else
        if (Key == true && Jey == false && Zed == true)
        // Если карта была ранее выбрана, и она не является раскрытой, а доступ к перелистыванию разрешен, тогда...
        {
            Key = false;
            // Карта перестает быть выделенной, поэтому значение Key равно false
            GetComponent<Image>().sprite = BackOfCard;
            // Карточка переворачивается, и осуществляется показ обратной(задней) стороны карточки
        }

        if (Jey == false)
        // Если карточка еще не раскрыта, тогда считаем ее, как выделенную
        {
            Net.Scount++;
        }
        // Значение count добавляет количество перелистываний карточек, совершенных самим игроком
        if (Net.Scount == 2)
        // Если игрок перевернул две карточки, тогда задается смена ходов игроков
        {
            if (Net.Sserver == true)
            // Если текущий ход был присужден игроку, который является сервером, тогда ход присуждается клиенту
            {
                Net.Sserver = false;
                Net.Sclient = true;
            }
            else 
            if (Net.Sclient == true)
            // Если текущий ход был присужден игроку, который является клиентом, тогда ход присуждается серверу
            {
                Net.Sserver = true;
                Net.Sclient = false;
                
            }
            Net.Scount = 0;
            // Количество перелистываний карточек count обнуляется при изменении хода
            Net.SChange = true;
            // Значение Change(true) означает, что доступ к изменению ходов игрококов разрешен
        }
    }
    #endregion

    #region Приостановление действий на сцене игры, пока не произойдут завершающие шаги
    public void CheckPoint()
    // Метод CheckPoint подводит итоги после выделение двух случайных карточек в текущей игре
    { StartCoroutine(pause()); }

    IEnumerator pause()
    {
        yield return new WaitForSeconds(0.5f);

        if (Key == false)
        // Если карточка перестала быть выделенной, тогда она переворачивается обратно,
        // и осуществляется показ обратной(задней) стороны карточки
        { GetComponent<Image>().sprite = BackOfCard; }
        else if (Key == true)
        // Если карточка осталась выделенной, тогда она считается раскрывшейся,
        // и осуществляется показ лицевой(передней) стороны карточки
        { GetComponent<Image>().sprite = FaceOfCard; }

        Zed = true;
        // Доступ к перелистыванию карточек вновь разрешен,
        // поэтому значение Zed равно true
    }
    #endregion
}