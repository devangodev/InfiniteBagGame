using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardStructure : MonoBehaviour
{
    public int cardType;
    public Sprite weaponSprite;
    public Sprite shieldSprite;
    public Sprite healSprite;

    


    //public TMPro.TMP_Text textComponent;

    // Start is called before the first frame update
    
    void Start() 
    {
        
        //textComponent = targetObject.AddComponent<TMPro.TMP_Text>();
        cardType = Random.Range(1,4);
        switch (cardType){
            case 1:
            GetComponent<SpriteRenderer>().sprite = weaponSprite;
            break;

            case 2:
            GetComponent<SpriteRenderer>().sprite = shieldSprite;
            break;

            case 3:
            GetComponent<SpriteRenderer>().sprite = healSprite;
            break;

            default:
            break;
        }
        /*textComponent.text = cardType.ToString();
        textComponent.color = Color.black;
        textComponent.fontSize = 10;*/
        
        
    }

    public int GetCardType(){
        return cardType;
    }


    // Update is called once per frame
    void Update()
    {

    }

}
