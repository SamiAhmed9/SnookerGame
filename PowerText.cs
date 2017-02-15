using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerText : MonoBehaviour {

    Text text;

    void Start()
    {
        text = GetComponent<Text>();
        text.text = "1 - Minimum Power";
    }
	
	public void SetValue(int value)
    {
        text.text = value + " - " + GetDescription(value);
    }

    private string GetDescription(int value)
    {
        if(value == 1)
        {
            return "Minimum Power";
        } else if(value == 2)
        {
            return "Light Touch";
        } else if(value == 3)
        {
            return "Strong Touch";
        } else if(value == 4)
        {
            return "Steady Shot";
        } else if(value == 5)
        {
            return "Shot";
        } else if(value == 6)
        {
            return "Hard Shot";
        } else if(value == 7)
        {
            return "Drive";
        } else if(value == 8)
        {
            return "Forceful";
        } else if(value == 9)
        {
            return "Near Maximum";
        } else
        {
            return "Maximum Power";
        }
    }
}
