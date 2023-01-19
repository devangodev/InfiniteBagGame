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
    public GameObject[] cardsDeck;
    public int lootedCards = new int();
    public Vector2 defaultPosition;
    private Vector2 fingerDown;
    private Vector2 fingerUp;
    public bool detectSwipeOnlyAfterRelease = false;
    public float SWIPE_THRESHOLD = 20f;
    // Start is called before the first frame update
    void Start()
    {
        QueueGO.Clear();
        lootedCards = 10;
        cards = GameObject.Find("Deck");

        for (int i = 0; i < lootedCards; i++){
            //CardStructure nextCard = new CardStructure();
            GameObject currentCard = Instantiate(CardPrefab, cards.transform);
            QueueGO.Add(currentCard);
            print(currentCard.GetComponent<CardStructure>().cardType);
        }

        print("You looted "+ lootedCards + "cards.");
    }


    public void Dequeue()
    {

    }

    public void PeekCard()
    {
        
        cardsDeck = QueueGO.ToArray();
        GameObject topObject = null;
        float maxY = float.MinValue;

        // Iterate through the list of objects
        foreach (GameObject obj in cardsDeck)
        {
            // Get the object's position in world space
            Vector3 objPos = obj.transform.position;
            // Check if the object's y-position is greater than the current maxY
            if (objPos.y > maxY)
            {
                maxY = objPos.y;
                topObject = obj;
            }
        }

        // Now topObject variable will have the reference of the top most object
        if (topObject != null)
        {
            Debug.Log("Top Object: " + topObject.name);
            topObject = Instantiate(CardPrefab, cards.transform);
        }
        
    }

    public int Count()
    {
        return QueueGO.Count;
    }

    public void Discard(){
       
        cardsDeck = QueueGO.ToArray();
        GameObject topObject = null;
        float maxY = float.MinValue;

        // Iterate through the list of objects
        foreach (GameObject obj in cardsDeck)
        {
            // Get the object's position in world space
            Vector3 objPos = obj.transform.position;
            // Check if the object's y-position is greater than the current maxY
            if (objPos.y > maxY)
            {
                maxY = objPos.y;
                topObject = obj;
            }
        }

        // Now topObject variable will have the reference of the top most object
        if (topObject != null)
        {
            Debug.Log("Top Object: " + topObject.name);
            for (int i = 0; i < QueueGO.Count; i++){
                if (QueueGO[i] == topObject) {
                    QueueGO.RemoveAt(i);
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
         foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUp = touch.position;
                fingerDown = touch.position;
            }

            // Detects Swipe while finger is still moving
            if (touch.phase == TouchPhase.Moved)
            {
                if (!detectSwipeOnlyAfterRelease)
                {
                    fingerDown = touch.position;
                    checkSwipe();
                }
            }

            // Detects swipe after finger is released
            if (touch.phase == TouchPhase.Ended)
            {
                fingerDown = touch.position;
                checkSwipe();
            }
        }
    }
     void checkSwipe()
    {
        // Check if swipe distance is greater than threshold
        if (Mathf.Abs(fingerDown.x - fingerUp.x) > SWIPE_THRESHOLD)
        {
            // Swipe left
            if (fingerDown.x - fingerUp.x > 0)
            {
                Debug.Log("Swipe Left");
                Discard();
    
                }
            // Swipe right
            else if (fingerDown.x - fingerUp.x < 0)
            {
                Debug.Log("Swipe Right");
                // Do something
            }
        }

        // Check if swipe distance is greater than threshold
        if (Mathf.Abs(fingerDown.y - fingerUp.y) > SWIPE_THRESHOLD)
        {
            // Swipe up
            if (fingerDown.y - fingerUp.y > 0)
            {
                Debug.Log("Swipe Up");
                // Do something
            }
            // Swipe down
            else if (fingerDown.y - fingerUp.y < 0)
            {
                Debug.Log("Swipe Down");
                // Do something
            }
        }
    }
}
