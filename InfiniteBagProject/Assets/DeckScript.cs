using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckScript : MonoBehaviour
{
    public Queue<GameObject> cardsDeck = new Queue<GameObject>();
    public int lootedCards = new int();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < lootedCards; i++){
            CardStructure nextCard = new CardStructure();
            Enqueue(obj: nextCard.DealCard());
        }
        print ("You looted "+ lootedCards + "cards.");
    }
     public void Enqueue(GameObject obj)
    {
        cardsDeck.Enqueue(obj);
    }

    public GameObject Dequeue()
    {
        return cardsDeck.Dequeue();
    }

    public GameObject Peek()
    {
        return cardsDeck.Peek();
    }

    public int Count()
    {
        return cardsDeck.Count;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
