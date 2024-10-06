using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// UnityEngine - это библиотека, которая подключает различные инструменты и функции,
// предназначенные для работы с игровым взаимодействием в Unity
using UnityEngine.UI;

public class TextOfChat : MonoBehaviour
{
    #region Присвоение текстовому полю отправляемого сообщения
    public void SetMessange(string MyMessange)
    // Метод SetMessange вызывается для присвоения отправляемого сообщения текстовому полю чата
    {
        if(Network.isServer)
        {
            if (GameObject.Find("Сообщение").GetComponent<InputField>().text == "")
            // Если отправитель не игрок 1, тогда это игрок 2
            { GetComponent<Text>().text = "Игрок 2: "; }
            else
            { GetComponent<Text>().text = "Игрок 1: "; }
        }

        if (Network.isClient)
        {
            if (GameObject.Find("Сообщение").GetComponent<InputField>().text == "")
            // Если отправитель не игрок 2, тогда это игрок 1
            { GetComponent<Text>().text = "Игрок 1: "; }
            else
            { GetComponent<Text>().text = "Игрок 2: "; }
        }
        GetComponent<Text>().text += MyMessange;
        // Присваиваем отправляемое сообщение
    }
    #endregion
}