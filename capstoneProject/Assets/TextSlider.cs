using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextSlider : MonoBehaviour
{
    public TextMeshProUGUI textNumber;

    public void SetNumberText(float number)
    {
        textNumber.text = number.ToString();
    }
}
