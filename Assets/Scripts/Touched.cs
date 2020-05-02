using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Touched : MonoBehaviour
{
    public static int touchedAmount;
    private Text touchedText;

    // Start is called before the first frame update
    void Start()
    {
        touchedText = GetComponent<Text>();
        touchedAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        touchedText.text = "Enemies Touched: " + touchedAmount;
    }
}
