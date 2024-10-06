using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// UnityEngine - это библиотека, которая подключает различные инструменты и функции,
// предназначенные для работы с игровым взаимодействием в Unity
using UnityEngine.UI;

public class ChatOfNetworkGame : MonoBehaviour
{
    #region Изменяемые переменные
    public GameObject Messange;
    // Объектом Messange будет являться сообщение, отправляемое игроком
    string TextMessange;
    // Значение TextMessange определяется отправляемым сообщением игрока
    public NetworkView Chat;
    // NetworkView - это компактный и мощный инструмент обнаружения и управления сетью
    // Обнаруживает TCP/IP-узлов в сети, а также TCP-порты
    // Значение переменной Chat класса NetworkView обеспечивает синхронизацию чата между сервером и подключенным к нему клиентом
    #endregion

    #region Отправление сообщения второму игроку
        public void SendMessange()
        // Метод SendMessange вызывается для отправки сообщения второму игроку в текущей игре
        {
            TextMessange = GameObject.Find("Сообщение").GetComponent<InputField>().text;
            // Значению TextMessange присваивается отправляемое сообщение
            Chat = GetComponent<NetworkView>();
            Chat.RPC("Send", RPCMode.All, new object[] { TextMessange });
            // С помощью функции RPC вызываем метод Send, используя режим RPCMode.All,
            // который вызывает этот метод на всех подключенных компьюерах, передавая параметр TextMessange в этот метод
        }

        [RPC]
        // Функция обязана быть помеченной как RPC перед тем как её можно будет запускать удаленно
        public void Send(string Text)
        // Метод Send вызывается для доставки сообщения второму игроку в текущей игре
        {
            GameObject newText = Instantiate(Messange) as GameObject;
            // Создаем новый объект, в котором будет размещаться текст
            newText.SetActive(true);
            // Делаем это объект активным
            newText.GetComponent<TextOfChat>().SetMessange(Text);
            // Присваиваем тексту этого объекта отправляемое сообщение
            GameObject.Find("Сообщение").GetComponent<InputField>().text = "";
            // Перед отправкой опустошаем поле, предназначенное написания сообщения
            newText.transform.SetParent(Messange.transform.parent, false);
            // Размещаем сообщение в истории чата
        }
        #endregion
}