using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class йоу : MonoBehaviour
{ 
    public GameObject P;
    public void crf()
    {
        Time.timeScale = 0;
        P.SetActive(true);
    }
}
