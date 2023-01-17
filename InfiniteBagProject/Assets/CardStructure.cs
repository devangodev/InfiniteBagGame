using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardStructure : MonoBehaviour
{
    [SerializeField] GameObject targetObject;
    [SerializeField] int cardType;
    public string text; // The string to draw
    public Color textColor; // The color of the text
    public int fontSize; // The size of the text
    public Font font; // The font of the text

    System.Random random = new System.Random();

    private Text textComponent;

    // Start is called before the first frame update
    void Start() 
    {
        cardType = random.Next(1,3);
        textComponent = gameObject.AddComponent<Text>();
        textComponent.text = cardType.ToString();
        textComponent.color = textColor;
        textComponent.font = font;
        textComponent.fontSize = fontSize;
        
        

        textComponent.rectTransform.position = targetObject.transform.position;

    }
    public GameObject DealCard(){
        return targetObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

}
