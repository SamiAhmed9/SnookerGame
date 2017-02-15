using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player1Text : MonoBehaviour {

    public Text text;

	void Start () {
        text = GetComponent<Text>();
        text.text = "";
    }
}
