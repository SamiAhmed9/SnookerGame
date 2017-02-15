using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class P2HSText : MonoBehaviour {

    public Text text;

    void Start()
    {
        text = GetComponent<Text>();
        text.text = "";
    }
}
