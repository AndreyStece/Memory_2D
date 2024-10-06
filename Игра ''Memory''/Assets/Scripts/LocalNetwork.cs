using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
// UnityEngine - это библиотека, которая подключает различные инструменты и функции,
// предназначенные для работы с игровым взаимодействием в Unity
using UnityEngine.SceneManagement;
// UnityEngine.SceneManagement - это библиотека, которая подключает инструменты и функции 
// для "управления сценами игры"(SceneManagement)
using UnityEngine.UI;

public class LocalNetwork : MonoBehaviour
{
    #region Изменяемые переменные
    public GameObject LocalNetworkMenu;
    // Панель LocalNetworkMenu открывается при запуске режима локальной сети
    public GameObject Server;
    // Панель Server открывается для создания игрового сервера
    public GameObject Client;
    // Панель Client открывается для создания клиента и подключения к серверу
    public GameObject Wait;
    // Панель Wait открывается при создании игрового сервера и для ожидания подключения клиента к нему
    public string IP;
    // Значение IP показывает Ip-address комьютера, который хочет создать сервер или подключиться к нему
    public string Port;
    // Значение Port показывает порт сервера, который указывается при создании этого сервера или подключении к нему
    private int PortNumber;
    // Значение PortNumber получает значение Port за счет конвертирования Port из string в int

    public static bool Connected { get; private set; }
    #endregion

    #region Инициализация переменных при запуске игры
    // Use this for initialization
    void Start()
    // Встроенный метод Start используется для инициализация переменных при запуске игры
    {
        LocalNetworkMenu.SetActive(true);
        Server.SetActive(false);
        Client.SetActive(false);
        Wait.SetActive(false);
        // SetActive отвечает за скрытие или показ той или иной панели
        // При выбранном значении "true" панели скрываются
        // При выбранном значении "false" панели скрываются
    }
    #endregion

    #region Методы, вызывающийся один раз за кадр
    // Update is called once per frame
    void Update()
    // Встроенный метод Update вызывается один раз за кадр
    {
        if (Network.connections.Length == 1)
        // Значение Network.connections.Length показывает, сколько установлено сетевых соединений
        // Если между двумя игроками установлено локальное сетевое соединение, то включается сама игра
        {
            LocalNetworkMenu.SetActive(false);
            Server.SetActive(false);
            Client.SetActive(false);
            Wait.SetActive(false);
            // SetActive отвечает за скрытие или показ той или иной панели
            // При выбранном значении "false" панели скрываются
            //GUILayout.Label("Connections: " + Network.connections.Length.ToString());
        }
    }
    #endregion

    #region Меню режима локальной сети
    public void NetworkMenu(int i)
    // Метод NetworkMenu вызывается для осуществления какого-либо действия, совершенного пользователем в меню режима локальной сети
    {
        switch (i)
        // Функция, которую запрашивает пользователь, нажав какую-то из показанных ему кнопок,
        // выбирается и осуществляется только по числовому значению данной кнопки, которой и соответствует эта функция
        {
            case (0):
                // Создание сервера
                {
                    LocalNetworkMenu.SetActive(false);
                    Server.SetActive(true);
                    // SetActive отвечает за скрытие или показ той или иной панели
                    // При выбранном значении "false" панели скрываются
                    // При выбранном значении "true" панели скрываются
                }
                break;
            case (1):
                // Создание клиента
                {
                    LocalNetworkMenu.SetActive(false);
                    Client.SetActive(true);
                    // SetActive отвечает за скрытие или показ той или иной панели
                    // При выбранном значении "false" панели скрываются
                    // При выбранном значении "true" панели скрываются
                }
                break;
            case (2):
                SceneManager.LoadScene("Menu of Game");
                // При нажатии кнопки "Вернуться в главное меню" осуществляется загрузка новой сцены(SceneManager.LoadScene) 
                // и переход к главному игровому меню("Menu of Game")
                break;
            default:
                break;
        }
    }
    #endregion

    #region Создание игрового сервера
    public void ServerCreation(int i)
    // Метод ServerCreation вызывается для осуществления какого-либо действия, совершенного пользователем при создании сервера
    {
        switch (i)
        // Функция, которую запрашивает пользователь, нажав какую-то из показанных ему кнопок,
        // выбирается и осуществляется только по числовому значению данной кнопки, которой и соответствует эта функция
        {
            case (0):
                // Создание сервера
                {
                    IP = GameObject.Find("IP-address").GetComponent<InputField>().text;
                    if (IP == "")
                    {
                        IP = "127.0.0.1";
                    }
                    Port = GameObject.Find("Port").GetComponent<InputField>().text;
                    if (Port == "")
                    {
                        Port = "8632";
                    }
                    PortNumber = Convert.ToInt32(Port);
                    Network.InitializeServer(2, PortNumber, true);
            
                    Wait.SetActive(true);
                    // SetActive отвечает за скрытие или показ той или иной панели
                    // При выбранном значении "true" открывается панель Wait,
                    // которая становится действительной при создании сервера
                }
                break;
            case (1):
                {
                    Server.SetActive(false);
                    LocalNetworkMenu.SetActive(true);
                    // SetActive отвечает за скрытие или показ той или иной панели
                    // При выбранном значении "false" панели скрываются
                    // При выбранном значении "true" панели скрываются
                }
                break;
            case (2):
                SceneManager.LoadScene("Menu of Game");
                // При нажатии кнопки "Вернуться в главное меню" осуществляется загрузка новой сцены(SceneManager.LoadScene) 
                // и переход к главному игровому меню("Menu of Game")
                break;
            default:
                break;
        }
    }
    #endregion

    #region Создание клиента и подключение к игровому серверу
    public void ClientCreation(int i)
    // Метод ClientCreation вызывается для осуществления какого-либо действия, совершенного пользователем при создании клиента
    {
        switch (i)
        // Функция, которую запрашивает пользователь, нажав какую-то из показанных ему кнопок,
        // выбирается и осуществляется только по числовому значению данной кнопки, которой и соответствует эта функция
        {
            case (0):
                // Создание клиента
                {
                    IP = GameObject.Find("IP-address").GetComponent<InputField>().text;
                    if (IP == "")
                    {
                        IP = "127.0.0.1";
                    }
                    Port = GameObject.Find("Port").GetComponent<InputField>().text;
                    if (Port == "")
                    {
                        Port = "8632";
                    }
                    PortNumber = Convert.ToInt32(Port);
                    Network.Connect(IP, PortNumber);
                }
                break;
            case (1):
                {
                    Client.SetActive(false);
                    LocalNetworkMenu.SetActive(true);
                    // SetActive отвечает за скрытие или показ той или иной панели
                    // При выбранном значении "false" панели скрываются
                    // При выбранном значении "true" панели скрываются
                }
                break;
            case (2):
                SceneManager.LoadScene("Menu of Game");
                // При нажатии кнопки "Вернуться в главное меню" осуществляется загрузка новой сцены(SceneManager.LoadScene) 
                // и переход к главному игровому меню("Menu of Game")
                break;
            default:
                break;
        }
    }
    #endregion

    #region пока оставить
    private void OnConnectedToServer()
    {
        // 
        Connected = true;
    }

    private void OnServerInitialized()
    {
        // 
        Connected = true;
    }

    private void OnDisconnectedFromServer(NetworkDisconnection info)
    {
        // 
        Connected = false;
    }
    #endregion
}