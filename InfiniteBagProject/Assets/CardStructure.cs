using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardStructure : MonoBehaviour
{
    public GameObject targetObject;
    public int cardType;
    public string text; // The string to draw
    public Color textColor; // The color of the text
    public int fontSize; // The size of the text


    private Text textComponent;

    // Start is called before the first frame update
    void Start() 
    {
    }
    public void Awake() {
        textComponent = gameObject.AddComponent<Text>();
        textComponent.text = cardType.ToString();
        textComponent.color = Color.black;
        textComponent.fontSize = 100;
        textComponent.rectTransform.position = targetObject.transform.position;
    }
    public GameObject DealCard(){
        cardType = Random.Range(1,3);
        return targetObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

}
