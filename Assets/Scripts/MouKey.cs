using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouKey : MonoBehaviour
{
    public static bool mouseState;
    private Text driveText;

    // Start is called before the first frame update
    void Start()
    {
        driveText = GetComponent<Text>();
        mouseState = true;
    }

    // Update is called once per frame
    void Update()
    {
        string msg = "";
        if (mouseState) {
            msg = "(Mouse)";
        } else {
            msg = "(Key)";
        }
        driveText.text = "HERO: Drive " + msg;
    }
}
