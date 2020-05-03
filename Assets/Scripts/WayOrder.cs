using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WayOrder : MonoBehaviour
{
    public static string waypointOrder = "rand";
    private Text wayText;

    // Start is called before the first frame update
    void Start()
    {
        wayText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        wayText.text = "WaypointOrder:" + waypointOrder;
    }
}
