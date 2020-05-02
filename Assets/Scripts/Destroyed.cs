using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroyed : MonoBehaviour
{
    public static int destroyedAmount;
    private Text destroyedText;

    // Start is called before the first frame update
    void Start()
    {
        destroyedText = GetComponent<Text>();
        destroyedAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        destroyedText.text = "EnemiesDestroyed: " + destroyedAmount;
    }
}
