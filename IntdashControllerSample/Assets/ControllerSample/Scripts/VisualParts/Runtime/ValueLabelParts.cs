using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ValueLabelParts : MonoBehaviour
{
    public TMP_Text ValueText;

    public string TextFormat = "0.000";

    public double Value;
    private double? _Value;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (ValueText == null) return;
        if (Value == _Value) return;
        _Value = Value;
        if (string.IsNullOrWhiteSpace(TextFormat))
        {
            ValueText.text = Value.ToString();
        }
        else
        {
            try
            {
                ValueText.text = string.Format("{0:" + TextFormat + "}", Value);
            }
            catch (System.Exception e)
            {
                Debug.LogWarning(e.Message);
                ValueText.text = Value.ToString();
            }
        }
    }
}
