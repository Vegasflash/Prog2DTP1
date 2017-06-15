using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class Converter : MonoBehaviour
{



    string card;
    
    int cardCount = 5;

    int maxCount;

    public string cardNumber;
    public string count;
    public string priority;
    public string english;
    public string french;
    public string spanish;

    // Use this for initialization
    void Start ()
    {
        Core();
    }

    void Core()
    {
        TextAsset textAsset = (TextAsset)Resources.Load("TP1_Cards");
        //Debug.Log(textAsset.text);

        MiniJSON.jsonEncode(textAsset);

        string[] firstSegments = textAsset.ToString().Split('\n');
        string[] secondSegments;



        int counter = 0;


        foreach (string segment in firstSegments)
        {
            secondSegments = segment.Split(';');
            maxCount = secondSegments.Length;
            for (int i = 0; i < secondSegments.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        GetCardNumberSwitch(i, counter, secondSegments);
                        break;
                    case 1:
                        GetCountSwitch(i, counter, secondSegments);
                        break;
                    case 2:
                        GetPrioritySwitch(i, counter, secondSegments);
                        break;
                    case 3:
                        GetEnglishSwitch(i, counter, secondSegments);
                        break;
                    case 4:
                        GetFrenchSwitch(i, counter, secondSegments);
                        break;
                    case 5:
                        GetSpanishSwitch(i, counter, secondSegments);
                        break;
                    default:
                        return;
                }             
            }
            counter++;
            
        }      
    }

    void PrintCards(int counter)
    {
        switch(counter)
        {
            case 0:
                Debug.Log(cardNumber);
                break;
            case 1:
                Debug.Log(count);
                break;
            case 2:
                Debug.Log(priority);
                break;
            case 3:
                Debug.Log(english);
                break;
            case 4:
                Debug.Log(french);
                break;
            case 5:
                Debug.Log(spanish);
                break;
        }
    }

    void ClearStrings(int counter)
    {

        cardNumber = "CardNo: ";
        count = "Count: ";
        priority = "Priority: ";
        english = "English: ";
        french = "French: ";
        spanish = "Spanish: ";
    }

    void GetCardNumberSwitch(int i, int counter, string[] secondSegments)
    {
        switch (counter)
        {
            case 0:
                cardNumber += secondSegments[i].ToString() + ": ";
                break;
            default:
                cardNumber += secondSegments[i].ToString() + " ";
                break;
        }
        PrintCards(i);
        ClearStrings(i);
    }

    void GetCountSwitch(int i, int counter, string[] secondSegments)
    {
        switch (counter)
        {
            case 0:
                count += secondSegments[i].ToString() + ": ";
                break;
            default:
                count += secondSegments[i].ToString() + " ";
                break;
        }
        PrintCards(i);
        ClearStrings(i);
    }

    void GetPrioritySwitch(int i, int counter, string[] secondSegments)
    {
        switch (counter)
        {
            case 0:
                priority += secondSegments[i].ToString() + ": ";
                break;
            default:
                priority += secondSegments[i].ToString() + " ";
                break;
        }
        PrintCards(i);
        ClearStrings(i);
    }

    void GetEnglishSwitch(int i, int counter, string[] secondSegments)
    {
        switch (counter)
        {
            case 0:
                english += secondSegments[i].ToString() + ": ";
                break;
            default:
                english += secondSegments[i].ToString() + " ";
                break;
        }
        PrintCards(i);
        ClearStrings(i);
    }

    void GetFrenchSwitch(int i, int counter, string[] secondSegments)
    {
        switch (counter)
        {
            case 0:
                french += secondSegments[i].ToString() + ": ";
                break;
            default:
                french += secondSegments[i].ToString() + " ";
                break;
        }
        PrintCards(i);
        ClearStrings(i);
    }

    void GetSpanishSwitch(int i, int counter, string[] secondSegments)
    {
        switch (counter)
        {
            case 0:
                spanish += secondSegments[i].ToString() + ": ";
                break;
            default:
                spanish += secondSegments[i].ToString() + " ";
                break;
        }
        PrintCards(i);
        ClearStrings(i);
    }
}
