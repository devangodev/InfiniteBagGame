using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckScript : MonoBehaviour
{
    public GameObject cards;
    [SerializeField]
    public GameObject CardPrefab;
    [SerializeField]
    public List<GameObject> QueueGO;
    public Queue<CardStructure> cardsDeck;
    public int lootedCards = new int();
    public Vector2 defaultPosition;
    // Start is called before the first frame update
    void Start()
    {
        QueueGO.Clear();
        lootedCards = 10;
        cards = GameObject.Find("Deck");

        for (int i = 0; i < lootedCards; i++){
            //CardStructure nextCard = new CardStructure();
            GameObject currentCard = Instantiate(CardPrefab, cards.transform);
            Enqueue(obj: currentCard);
            print(currentCard.GetComponent<CardStructure>().cardType);
        }

        print("You looted "+ lootedCards + "cards.");
    }

     public void Enqueue(GameObject obj)
    {
        QueueGO.Add(obj);
        //cardsDeck.Enqueue(obj);
    }

    public CardStructure Dequeue()
    {
        return cardsDeck.Dequeue();
    }

    public CardStructure Peek()
    {
        return cardsDeck.Peek();
    }

    public int Count()
    {
        return cardsDeck.Count;
    }

    public void CreateDeck(){
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
