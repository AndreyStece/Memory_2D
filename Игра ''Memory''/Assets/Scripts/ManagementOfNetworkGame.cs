using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// UnityEngine - это библиотека, которая подключает различные инструменты и функции,
// предназначенные для работы с игровым взаимодействием в Unity
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// UnityEngine.SceneManagement - это библиотека, которая подключает инструменты и функции 
// для "управления сценами игры"(SceneManagement)

public class ManagementOfNetworkGame : MonoBehaviour
{
    #region Показ игрового чата
    public void ChatShow()
    // Метод ChatShow вызывается для показа игрового чата
    {
        Chat.SetActive(true);
        // SetActive отвечает за скрытие или показ той или иной панели
        // При выбранном значении "true" открывается панель Chat для показа игрового чата

        if (Network.isServer)
        // Если игрок является сервером игры, тогда чат у него включен
        {
            Chat1 = true;

            Synchronization = GetComponent<NetworkView>();
            Synchronization.RPC("Show1", RPCMode.All, null);
            // С помощью функции RPC вызываем метод Show1, используя режим RPCMode.All,
            // который вызывает этот метод на всех подключенных компьюерах, не передавая никаких параметров в этот метод
        }
        else
        if (Network.isClient)
        // Если игрок является клиентом, подключенным к серверу игры, тогда у него включен чат
        {
            Chat2 = true;

            Synchronization = GetComponent<NetworkView>();
            Synchronization.RPC("Show2", RPCMode.All, null);
            // С помощью функции RPC вызываем метод Show2, используя режим RPCMode.All,
            // который вызывает этот метод на всех подключенных компьюерах, не передавая никаких параметров в этот метод
        }
    }

    [RPC]
    // Функция обязана быть помеченной как RPC перед тем как её можно будет запускать удаленно
    public void Show1()
    // Метод Show1 определяет включение чата у первого игрока 
    {
        if (Network.isClient)
        // Если игрок является клиентом, подключенным к игровому серверу, тогда у второго игрока чат включен
        { OnLine.text = "Чат игрока 2: включен"; }
    }

    [RPC]
    // Функция обязана быть помеченной как RPC перед тем как её можно будет запускать удаленно
    public void Show2()
    // Метод Show2 определяет включение чата у второго игрока
    {
        if (Network.isServer)
        // Если игрок является сервером игры, тогда у второго игрока чат включен
        { OnLine.text = "Чат игрока 2: включен"; }
    }
    #endregion

    #region Скрытия игрового чата
    public void ChatHide()
    // Метод ChatShow вызывается для скрытия игрового чата
    {
        Chat.SetActive(false);
        // SetActive отвечает за скрытие или показ той или иной панели
        // При выбранном значении "false" панель Chat для показа игрового чата закрывается

        if (Network.isServer)
        // Если игрок является сервером игры, тогда чат у него отключен
        {
            Chat1 = false;

            Synchronization = GetComponent<NetworkView>();
            Synchronization.RPC("Hide1", RPCMode.All, null);
            // С помощью функции RPC вызываем метод Hide1, используя режим RPCMode.All,
            // который вызывает этот метод на всех подключенных компьюерах, не передавая никаких параметров в этот метод
        }
        else
        if (Network.isClient)
        // Если игрок является клиентом, подключенным к серверу игры, тогда у него отключен чат
        {
            Chat2 = false;

            Synchronization = GetComponent<NetworkView>();
            Synchronization.RPC("Hide2", RPCMode.All, null);
            // С помощью функции RPC вызываем метод Hide2, используя режим RPCMode.All,
            // который вызывает этот метод на всех подключенных компьюерах, не передавая никаких параметров в этот метод
        }
    }

    [RPC]
    // Функция обязана быть помеченной как RPC перед тем как её можно будет запускать удаленно
    public void Hide1()
    // Метод Hide1 определяет отключение чата у первого игрока
    {
        if(Network.isClient)
        // Если игрок является клиентом, подключенным к игровому серверу, тогда у второго игрока чат отключен
        { OnLine.text = "Чат игрока 2: отключен"; }
    }

    [RPC]
    // Функция обязана быть помеченной как RPC перед тем как её можно будет запускать удаленно
    public void Hide2()
    // Метод Hide2 определяет отключение чата у второго игрока
    {
        if (Network.isServer)
        // Если игрок является сервером игры, тогда у второго игрока чат отключен
        { OnLine.text = "Чат игрока 2: отключен"; }
    }
    #endregion

    #region Меню для сетевой игры
    public void MenuOfNetworkGame(int i)
    // Метод MenuOfNetworkGame вызывается для осуществления какого-либо действия, совершенного пользователем в сетевой игре
    {
        Time.timeScale = 0;
        // Time.timescale отвечает за приостановку или возобновление игрового взаимодействия
        // При выбранном значении "0" игра ставится на паузу

        switch (i)
        // Функция, которую запрашивает пользователь, нажав какую-то из показанных ему кнопок,
        // выбирается и осуществляется только по числовому значению данной кнопки, которой и соответствует эта функция
        {
            case (0):
                {
                    Connection = false;
                    // Значение Connection(false) означает, что осуществляется попытка отключения от локальной сети

                    if (Network.isServer)
                    // Если игрок является сервером игры, тогда он отключается от сети
                    {
                        server = false;
                        client = true;
                    }
                    else
                   if (Network.isClient)
                    // Если игрок является клиентом, подключенным к серверу игры, тогда он отключается от сети
                    {
                        server = true;
                        client = false;
                    }

                    Network.Disconnect();
                    // Network.Disconnect отключает игрока от локальной сети или удаляет сам сервер игры
                    SceneManager.LoadScene("Menu Of Game");
                    // При нажатии кнопки "Вернуться в главное меню" осуществляется загрузка новой сцены(SceneManager.LoadScene) 
                    // и переход к главному игровому меню("Menu of Game")
                }
                break;
            case (1):
                {
                    DisConnect.SetActive(true);
                    // SetActive отвечает за скрытие или показ той или иной панели
                    // При выбранном значении "true" открывается панель DisConnect, которая становится действительной
                }
                break;
            case (2):
                {
                    DisConnect.SetActive(false);
                    // SetActive отвечает за скрытие или показ той или иной панели
                    // При выбранном значении "false" скрывается панель DisConnect, которая становится недействительной
                    Time.timeScale = 1;
                    // Time.timescale отвечает за приостановку или возобновление игрового взаимодействия
                    // При выбранном значении "1" игра вновь возобновляется
                }
                break;
            default:
                break;
        }
    }
    #endregion

    #region Изменяемые переменные
    private bool Zed;
    // Значение Zed отвечает за первоначальную инициализацию и рандомное распределение карточек в игре
    private bool[] DKey;
    // Массив DKey состоит из булевских значений, которые соответствуют данным карточкам и 
    // показывают какие из этих карточек уже имют свои числовые значения
    private bool Key;
    // Значение Key определяет, имеет ли карточка из массива DKey свое числовое значение или нет
    private int Number;
    // Значение Number определяет индекс карточки в массиве булевских значений DKey
    public GameObject[] CardsOfGame;
    // Игровые объекты CardsOfGame являются карточками самой игры
    public Sprite[] FaceOfCards;
    // Изображения лицевых(передних) сторон карточек
    public Sprite BackOfCard;
    // Изображение обратной(задней) стороны карточек
    List<int> Digit;
    // Лист Digit содержит в себе только 2 индекса карточек, которые были выбраны в самой игре
    private bool Jey;
    // Значение Jey определяется за счет сравнения двух выделенных карточек
    private int Pairs;
    // Значение Pairs определяет количество нераскрывшихся пар карточек
    public Text CloseCards;
    // Текст CloseCards определяется с помощью количества нераскрывшихся пар Pairs

    #region Переменные для режима локальной сети
    public GameObject MenuOfLocalNetwork;
    // Панель MenuOfLocalNetwork открывается при переходе к режиму локальной сети
    public GameObject DisConnect;
    // Панель DisConnect открывается при попытке отключения от локальной сети
    public GameObject Dis;
    // Панель Dis открывается при отключении от локальной сети
    public GameObject Loading;
    // Панель Loading открывается при ожидании подключения второго игрока к серверу игры
    public GameObject Chat;
    // Панель Chat открывается при показе игрового чата
    public bool Chat1;
    // Значение Chat1 определяется включением или выключением чата первого игрока
    public bool Chat2;
    // Значение Chat2 определяется включением или выключением чата второго игрока
    public NetworkView Synchronization;
    // NetworkView - это компактный и мощный инструмент обнаружения и управления сетью
    // Обнаруживает TCP/IP-узлов в сети, а также TCP-порты
    // Значение переменной Synchronization класса NetworkView обеспечивает синхронизацию между сервером и подключенным к нему клиентом
    public GameObject Winner;
    // Панель Winner открывается при выигрыше игрока в режиме локальной сети
    public GameObject Loser;
    // Панель Loser открывается при проигрыше игрока в режиме локальной сети
    public GameObject Draw;
    // Панель Draw открывается при ничье игроков в режиме локальной сети
    private bool Play;
    // Значение Play отвечает за первоначальные ходы игроков(Сервер - первый игрок, Клиент - второй игрок)
    public Text Running;
    // Текст Running определяется за счет изменения хода игрока
    private static bool Change;
    // Значение Change отвечает за изменение хода игрока во время игры
    List<int> DataBase;
    // Лист DataBase содержит в себе индексы карточек, хранящих в себе свои числовые значения,
    // для синхронизирования этих данных между сервером и подключенным к нему клиентом
    private int ServerPairs;
    // Значение ServerPairs определяет количество пар карточек, раскрывшихся первым игроком, который является сервером игры
    private int ClientPairs;
    // Значение ClientPairs определяет количество пар карточек, раскрывшихся вторым игроком, который является клиентом
    public Text Win;
    // Текст Win определяется за счет выигрыша игрока
    public Text Lose;
    // Текст Running определяется за счет проигрыша игрока
    public Text OnLine;
    // Текст OnLine определяется за счет включения чата у игрока
    public bool Connection;
    // Значение Connection определяется произвольным выходом игрока из текущей игры
    private static bool server;
    // Значение server определяет ход игрока, который является сервером игры
    private static bool client;
    // Значение client определяет ход игрока, который является клиентом, подключенным к серверу игры
    private static int count;
    // Значение count определяет число карт, раскрытых игроком, для смены хода игрока
    #endregion

    #endregion

    #region Свойства отдельных переменных
    // Свойства осуществляют более безопасный доступ к данным переменным
    public bool SChange
    {
        get { return Change; }
        set { Change = value; }
    }

    public bool Sserver
    {
        get { return server; }
        set { server = value; }
    }

    public bool Sclient
    {
        get { return client; }
        set { client = value; }
    }

    public int Scount
    {
        get { return count; }
        set { count = value; }
    }
    #endregion

    #region Инициализация переменных при запуске игры
    // Use this for initialization
    void Start()
    // Встроенный метод Start используется для инициализация переменных при запуске игры
    {
        Zed = true;
        // Значение Zed(true) означает, что доступ к первоначальной инициализации карточек разрешен
        DKey = new bool[CardsOfGame.Length];
        // Размер массива DKey равняется общему количеству всех карточек
        for (int i = 0; i < CardsOfGame.Length; i++)
        { DKey[i] = false; }
        // Каждому из элементов массива булевских значений DKey присвоено первоначальное значение false,
        // так как все игровые карточки еще не получили своих числовых значений 
        Digit = new List<int>();
        // Инициализируем Digit как новый лист
        Jey = false;
        // При запуске игры сравнения двух карточек не осуществлялось, поэтому значение Jey равно false
        Pairs = CardsOfGame.Length / 2;
        // Количество нераскрывшихся пар карточек Pairs равно половине карточек из общего числа CardsOfGame

        #region Инициализация переменных для режима локальной сети
        //
        MenuOfLocalNetwork.SetActive(true);
        DisConnect.SetActive(false);
        Dis.SetActive(false);
        Loading.SetActive(false);
        Chat.SetActive(false);
        Winner.SetActive(false);
        Loser.SetActive(false);
        Draw.SetActive(false);
        // SetActive отвечает за скрытие или показ той или иной панели
        // При выбранном значении "true" панели открываются
        // При выбранном значении "false" панели скрываются
        Chat1 = false;
        // При запуске игры чат у первого игрока отключен
        Chat2 = false;
        // При запуске игры чат у второго игрока отключен
        Synchronization = GetComponent<NetworkView>();
        // При запуске игры инициализируется значение Synchronization
        Play = true;
        // Значение Play(true) означает, что доступ к первоначальному распределению ходов игрококов разрешен
        Change = false;
        // Значение Change(false) означает, что при запуске игры доступ к изменению ходов игрококов запрещен
        DataBase = new List<int>();
        // При запуске игры инициализируется лист DataBase
        ServerPairs = 0;
        // При запуске игры количество пар карточек, раскрывшихся первым игроком, равно 0
        ClientPairs = 0;
        // При запуске игры количество пар карточек, раскрывшихся вторым игроком, равно 0
        Win.text = "Поздравляю!!!      Вы победили)))    Со счетом ";
        // Тексту Win присваивается первоначальное значение
        Lose.text = "Сожалею, но...          Вы проиграли(((       Со счетом ";
        // Тексту Lose присваивается первоначальное значение
        Connection = true;
        // Значение Connection(true) означает, что при запуске игры все игроки на месте и они подключены друг к другу
        server = true;
        client = false;
        // Первый ход присужден серверу, а не второму игроку
        count = 0;
        // При запуске игры карточки еще не были раскрыты
        #endregion

        Time.timeScale = 1;
        // Time.timescale отвечает за приостановку или возобновление игрового взаимодействия
        // При выбранном значении "1" игра вновь возобновляется
    }
    #endregion

    #region Методы, вызывающийся один раз за кадр
    // Update is called once per frame
    void Update()
    // Встроенный метод Update вызывается один раз за кадр
    {
        if (Network.connections.Length == 0 && Connection == false)
        // Если нарушено сетевое соединение между двумя игроками, тогда...
        {
            if(Network.isServer && server == true && client == false)
            // Если игрок является сервером игры и от него отключился второй игрок, тогда идет завершение игры
            { Dis.SetActive(true); }
            else
            if (Network.isClient && server == false && client == true)
            // Если игрок является клиентом игры и от него отключился второй игрок, тогда идет завершение игры
            { Dis.SetActive(true); }
        }

        if (Network.connections.Length == 1)
        // Если имеется сетевое соединение между двумя игроками, тогда начинается распределение ходов для игроков
        {
            #region Первоначальное распределение ходов
            if (Play)
            // Если имеется доступ к первоначальному распределению ходов игрококов, тогда...
            {
                if (Network.isServer)
                // Network.isServer определяет, является ли игрок сервером или нет
                // Если игрок является сервером, тогда первый ход присужден ему
                { Running.text = "ВАШ ХОД      "; }

                if (Network.isClient)
                // Network.isClient определяет, является ли игрок клиентом, подключенным к серверу игры, или нет
                // Если игрок является клиентом, тогда ему присужден второй ход 
                { Running.text = "ХОД ДРУГОГО ИГРОКА      "; }

                Play = false;
                // Значение Play(false) означает, что доступ к первоначальному распределению ходов игрококов запрещен
            }
            #endregion

            #region Смена хода игроков
            if (Change && count == 0)
            // Если доступ к изменению ходов игроков разрешен и если игрок уже сделал свой ход, тогда идет смена ходов
            {
                if (Running.text == "ВАШ ХОД      ")
                // Если первый игрок уже сделал ход, значит ход переходит ко второму игроку
                { Running.text = "ХОД ДРУГОГО ИГРОКА      "; }
                else
                if (Running.text == "ХОД ДРУГОГО ИГРОКА      ")
                // Если второй игрок уже сделал ход, значит ход переходит ко первому игроку
                { Running.text = "ВАШ ХОД      "; }

                Change = false;
                // Значение Change(false) означает, что доступ к изменению ходов игрококов запрещен
            }
            #endregion

            if (Zed && Network.isServer)
            // Если значение Zed равно true и игрок является сервером игры, тогда переходим к инициализации и распределению карточек
            { LoadingValuesImages(); }

            if (Input.GetMouseButtonUp(0))
            // Если была нажата левая кнопка мыши, тогда переходим к выделению выбранной карточки
            {
                // Remote Procedure Calls (RPCs, удаленные вызовы процедур) позволяют вызывать функции на удаленном компьютере
                // При его вызове, метод, который был в него внесен, вызывается как на удаленном компьютере, так и на этом
                Synchronization.RPC("EductionOfCards", RPCMode.All, null);
                // С помощью функции RPC вызываем метод EductionOfCards, используя режим RPCMode.All,
                // который вызывает этот метод на всех подключенных компьюерах, не передавая никаких параметров в этот метод
            }
        }
    }
    #endregion

    #region Инициализация значений лицевых сторон для карточек игры
    void LoadingValuesImages()
    // Метод LoadingValuesImages вызывается всего лишь один раз за игру для 
    // первоначальной инициализации и рандомного распределения карточек в игре
    {
        for (int i = 0; i < 2; i++)
        // Распределение значений для двух половин из всего количества карточек поочередно
        {
            for (int j = 1; j < (CardsOfGame.Length) / 2 + 1; j++)
            // Переменная j отвечает за половину карточек и также является самим числовым значением для них
            {
                Key = true;
                while (Key)
                // Пока не найдена карточка, которой не присвоено числовое значение, возобновляем цикл
                {
                    Number = Random.Range(0, CardsOfGame.Length);
                    // Random.Range используется для выбора рандомного индекса карточки из массива DKey,
                    // чтобы потом этой рандомной карточки присвоить значение j
                    Key = DKey[Number];
                    // Если эта карточка уже имеет свое числовое значение и ее значение в массиве равно true,
                    // тогда продолжаем искать оставшиеся карточки, которые еще эти значения не приобрели
                }
                CardsOfGame[Number].GetComponent<Cards>().SValueOfCard = j;
                // Присваиваем значению SValueOfCard из класса Cards значение j карточки
                // с индексом Number из общего числа карточек CardsOfGame
                DKey[Number] = true;
                // После того, как выбранная карточка получила свое числовое значение,
                // значение этой карточки в массиве равняется true
                Synchronization.RPC("AddingCards", RPCMode.All, new object[] { Number });
                // С помощью функции RPC вызываем метод AddingCards, используя режим RPCMode.All,
                // который вызывает этот метод на всех подключенных компьюерах, передавая индекс карточек Number в этот метод
            }
        }
        Synchronization.RPC("InitializationSynchronization", RPCMode.All, null);
        // С помощью функции RPC вызываем метод InitializationSynchronization, используя режим RPCMode.All,
        // который вызывает этот метод на всех подключенных компьюерах, не передавая никаких параметров в этот метод
    }

    [RPC]
    // Функция обязана быть помеченной как RPC перед тем как её можно будет запускать удаленно
    public void AddingCards(int Index)
    // Метод AddingCards вызывается при добалении индексов карточек Number в лист Database для 
    // синхронизирования собранных данных между двумя игроками при первоначальной инициализации карточек в игре
    { DataBase.Add(Index); }

    [RPC]
    // Функция обязана быть помеченной как RPC перед тем как её можно будет запускать удаленно
    public void InitializationSynchronization()
    // Метод InitializationSynchronization вызывается всего лишь один раз за игру для 
    // синхронизирования первоначальной инициализации и рандомного распределения карточек в игре между двумя игроками
    {
        for (int i = 0, j = 1; i < CardsOfGame.Length; i++, j++)
        // Повторное распределение заданных значений карточек для синхронизации этих данных между двумя игроками
        {
            CardsOfGame[DataBase[i]].GetComponent<Cards>().SValueOfCard = j;
            if (j == 12)
            // Если количество значение закончилось, тогда осуществляется повторный перебор этих значений
            { j = 0; }
        }

        foreach (GameObject Card in CardsOfGame)
        // Для каждой карточки Card из общего числа карточек CardsOfGame
        // вызывается метод Images из класса Cards для присвоения изображения лицевой(передней) стороны 
        // и изображения обратной(задней) стороны карточки
        { Card.GetComponent<Cards>().NetworkImages(); }

        if (Zed)
        // Если доступ был разрешен и инициализация карточек прошла успешно,
        // то доступ к повторной инициализации становится закрытым и значение Zed равняется false 
        { Zed = false; }
    }
    #endregion

    #region Получение текстур для карточек
    public Sprite LoadingFaceOfCards(int i)
    // Метод LoadingFaceOfCard отвечает за возвращение изображения лицевой(передней) стороны карточки 
    // за счет ее числового значения i
    { return FaceOfCards[i - 1]; }

    public Sprite LoadingBackOfCard()
    // Метод LoadingBackOfCard отвечает за возвращение изображения обратной(задней) стороны карточки
    { return BackOfCard; }
    #endregion

    #region Выделение 2-х выбранных карточек
    [RPC]
    // Функция обязана быть помеченной как RPC перед тем как её можно будет запускать удаленно
    void EductionOfCards()
    // Метод EductionOfCards вызывается при каждом нажатии левой кнопки мыши на карточку 
    // и отвечает за выделение только двух выбранных карточек
    {
        Digit = new List<int>();
        // Инициализируем Digit как новый лист
        for (int i = 0; i < CardsOfGame.Length; i++)
        // Перебор всех карточек текущей игры
        {
            if (CardsOfGame[i].GetComponent<Cards>().SKey == true && CardsOfGame[i].GetComponent<Cards>().SJey == false)
            // Если эта карточка была выбрана, и она не является раскрытой, тогда...
            {
                print(CardsOfGame[i].GetComponent<Cards>().SKey);
                Digit.Add(i);
                // Добавления индекса i выделенной карты в лист Digit
            }
        }

        if (Digit.Count == 2)
        // Если были выделены две карточки, тогда вызывается метод CompareOfCards для их сравнения
        // с передачей листа Digit
        { CompareOfCards(Digit); }
    }
    #endregion

    #region Сравнение значений 2-х выбранных карточек
    void CompareOfCards(List<int> Digit)
    // Метод CompareOfCards вызывается, если имеются две выделенные карточки,
    // и отвечает за сравнение этих карточек между собой
    {
        Jey = false;
        // Сравнения двух карточек не осуществлялось, поэтому значение Jey равно false
        Cards Net = new Cards();
        // Переменная класса Cards 
        Net.SZed = false;
        // При сравнении двух выделенных карточек доступ к перелистыванию карточек запрещен,
        // поэтому значение Zed из класса Cards равно false
        if (CardsOfGame[Digit[0]].GetComponent<Cards>().SValueOfCard == CardsOfGame[Digit[1]].GetComponent<Cards>().SValueOfCard)
        // Если две выделенные карточки равны, тогда...
        {
            Jey = true;
            // Эти карточки равны, и поэтому значение Jey равно true
            Pairs--;
            // Количество нераскрывшихся пар карточек Pairs уменьшается на 1
            CloseCards.text = "Количество не раскрывшихся пар: " + Pairs;

            #region Подсчет очков игроков
            if(Network.isServer && server == false)
            // Если игрок является сервером игры и текущий ход принадлежит уже не ему, тогда...
            {
                ServerPairs += 1;
                //Игрок получает 1 очко в свою пользу за раскрывшуюся пару карт
            }

            if(Network.isClient && client == false)
            // Если игрок является клиентом, подключенным к серверу игры, и текущий ход принадлежит уже не ему, тогда...
            {
                ClientPairs += 1;
                //Игрок получает 1 очко в свою пользу за раскрывшуюся пару карт
            }
            #endregion

            #region Завершение игры
            if (Pairs == 0)
            // Если количество нераскрывшихся пар Pairs равно 0, тогда...
            {
                if (Network.isServer)
                // Если игрок является сервером игры, тогда...
                {
                    if (ServerPairs > 6)
                    // Если у первого игрока очков больше, чем у второго, тогда он победил
                    {
                        Win.text += ServerPairs.ToString() + ":";
                        ClientPairs = 12 - ServerPairs;
                        Win.text += ClientPairs.ToString();
                        // Осуществляется подсчет очков первого игрока
                        Winner.SetActive(true);
                        // SetActive отвечает за скрытие или показ той или иной панели
                        // При выбранном значении "true" открывается панель Winner при выигрыше игрока
                    }
                    else
                    if (ServerPairs < 6)
                    // Если у первого игрока очков меньше, чем у второго, тогда он проиграл
                    {
                        Lose.text += ServerPairs.ToString() + ":";
                        ClientPairs = 12 - ServerPairs;
                        Lose.text += ClientPairs.ToString();
                        // Осуществляется подсчет очков первого игрока
                        Loser.SetActive(true);
                        // SetActive отвечает за скрытие или показ той или иной панели
                        // При выбранном значении "true" открывается панель Loser при проигрыше игрока
                    }
                    else
                    if (ServerPairs == 6)
                    // Если итогом игры стала ничья, тогда...
                    {
                        Draw.SetActive(true);
                        // SetActive отвечает за скрытие или показ той или иной панели
                        // При выбранном значении "true" открывается панель Draw при  игрока
                    }
                }

                if (Network.isClient)
                // Если игрок является клиентом, подключенным к серверу игры, тогда...
                {
                    Debug.Log("This is client!!!");
                    if (ClientPairs > 6)
                    // Если у второго игрока очков больше, чем у первого, тогда он победил
                    {
                        Win.text += ClientPairs.ToString() + ":";
                        ServerPairs = 12 - ClientPairs;
                        Win.text += ServerPairs.ToString();
                        // Осуществляется подсчет очков первого игрока
                        Winner.SetActive(true);
                        // SetActive отвечает за скрытие или показ той или иной панели
                        // При выбранном значении "true" открывается панель Winner при выигрыше игрока
                    }
                    else
                    if (ClientPairs < 6)
                    // Если у второго игрока очков меньше, чем у первого, тогда он проиграл
                    {
                        Lose.text += ClientPairs.ToString() + ":";
                        ServerPairs = 12 - ClientPairs;
                        Lose.text += ServerPairs.ToString();
                        // Осуществляется подсчет очков первого игрока
                        Loser.SetActive(true);
                        // SetActive отвечает за скрытие или показ той или иной панели
                        // При выбранном значении "true" открывается панель Loser при проигрыше игрока
                    }
                    else
                    if (ClientPairs == 6)
                    // Если итогом игры стала ничья, тогда...
                    {
                        Draw.SetActive(true);
                        // SetActive отвечает за скрытие или показ той или иной панели
                        // При выбранном значении "true" открывается панель Draw при  игрока
                    }
                }
            }
            #endregion
        }
        else
        // Если две выделенные карточки не равны, тогда эти карточки перестают быть выделеными,
        // и поэтому значения SKey из класса Cards равны false
        {
            CardsOfGame[Digit[0]].GetComponent<Cards>().SKey = false;
            CardsOfGame[Digit[1]].GetComponent<Cards>().SKey = false;
        }

        for (int i = 0; i < Digit.Count; i++)
        // Для каждой карточки из листа Digit выполняется:
        {
            CardsOfGame[Digit[i]].GetComponent<Cards>().SJey = Jey;
            // Результат сравнения Jey присваивается SJey из класса Cards
            CardsOfGame[Digit[i]].GetComponent<Cards>().CheckPoint();
            // Для выбранной карточки вызывается метод CheckPoint,
            // который влияет на дальнейшее развитие игры 
        }
    }
    #endregion
}