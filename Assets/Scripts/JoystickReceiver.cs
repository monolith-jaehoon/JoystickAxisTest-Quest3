using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JoystickReceiver : MonoBehaviour
{
	public GameObject goTextArea;
	
	protected TextMeshPro[] textAxisValue = new TextMeshPro[28];
	

    // Start is called before the first frame update
    void Start()
    {
        GameObject textAxis1 = GameObject.Find("Axis1");
        TextMeshPro textAxis1TextComponent = textAxis1.GetComponent<TextMeshPro>();
        textAxis1TextComponent.text = 1.ToString();

        Vector3 axis1Position = textAxis1.transform.localPosition;

        textAxisValue[0] = textAxis1TextComponent;

        for (int i = 1; i < 28; i++) {
            int row = i % 7;
            int col = (int) (i / 7.0f);
            GameObject newAxis = GameObject.Instantiate(textAxis1);
            TextMeshPro textNewAxisTextComponent = newAxis.GetComponent<TextMeshPro>();
            textNewAxisTextComponent.text = (i + 1).ToString();
            newAxis.transform.parent = goTextArea.transform;
            newAxis.transform.localPosition = axis1Position + new Vector3(0 + (col * 4), 0 - (1.0f * row), 0);
            textAxisValue[i] = textNewAxisTextComponent;
        }

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 28; i++) {
		    textAxisValue[i].text = (i+1).ToString() + ": " + Input.GetAxis("No" + (i + 1).ToString()).ToString();
		}
    }
}
