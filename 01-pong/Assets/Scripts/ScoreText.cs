using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    //передача текста
    public TextMeshProUGUI text;
    
    //установка значения
    public void SetScore(int value)
    {
        text.text = value.ToString();//конвертация в текст
    }
}
