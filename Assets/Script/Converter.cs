using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class Converter : MonoBehaviour
{
    int cardCounter = 0;
    int maxCount;

    public string cardNumber = "CardNo: ";
    public string count;
    public string priority;
    public string english;
    public string french;
    public string spanish;


    string first_filter = "";
    string second_filter = "";
    string third_filter = "";

    const int MAX_DECK_SIZE = 35;
    Card[] cardList;

    // Use this for initialization
    void Start ()
    {
        CreateDeck();
        Core();
        PrintCards();
    }

    void CreateDeck()
    {
        cardList = new Card[MAX_DECK_SIZE];
        for(int i = 0; i < MAX_DECK_SIZE; i++)
        {
            cardList[i] = new Card();
        }
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
                if (counter != 0)
                {

                    switch (i)
                    {
                        case 0:
                            SetCardNumber(i, counter, secondSegments);
                            break;
                        case 1:
                            SetCount(i, counter, secondSegments);
                            break;
                        case 2:
                            SetPriority(i, counter, secondSegments);
                            break;
                        case 3:
                            SetEnglishPhrase(i, counter, secondSegments);
                            break;
                        case 4:
                            SetFrenchPhrase(i, counter, secondSegments);
                            break;
                        case 5:
                            SetSpanishPhrase(i, counter, secondSegments);
                            if(cardCounter < MAX_DECK_SIZE + 1)
                            {
                                cardCounter++;
                            }
                            break;
                        default:
                            return;
                    }
                }             
            }
            counter++;         
        }      
    }

    void PrintCards()
    {
        Debug.Log(cardCounter);
        for(int i = 0; i < MAX_DECK_SIZE; i++)
        {
            Debug.Log(cardList[i].GetCardNo());
            Debug.Log(cardList[i].GetCardCount());
            Debug.Log(cardList[i].GetCardPriority());
            Debug.Log(cardList[i].GetCardEnglish());
            Debug.Log(cardList[i].GetCardFrench());
            Debug.Log(cardList[i].GetCardSpanish());
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

    void SetCardNumber(int i, int counter, string[] secondSegments)
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
        cardList[cardCounter].SetCardNo(cardNumber);
        ClearStrings(i);
    }

    void SetCount(int i, int counter, string[] secondSegments)
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
        cardList[cardCounter].SetCardCount(count);
        ClearStrings(i);
    }

    void SetPriority(int i, int counter, string[] secondSegments)
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
        cardList[cardCounter].SetCardPriority(priority);
        ClearStrings(i);
    }

    void SetEnglishPhrase(int i, int counter, string[] secondSegments)
    {
        string filtered_english = "";

        switch (counter)
        {
            case 0:
                english += secondSegments[i].ToString() + ": ";
                break;
            default:
                english += secondSegments[i].ToString() + " ";
                break;
        }    
        if(!english.Contains("<P>") &&
            !english.Contains("< P >") &&
            !english.Contains("<C>") &&
            !english.Contains("< C >"))
        {
            filtered_english = english;
        }
        else
        {
            first_filter = english.Replace("<P>", "\n");
            second_filter = first_filter.Replace("< P >", "\n");
            third_filter = second_filter.Replace("<C>", ",");
            filtered_english = third_filter.Replace("< C> ", ",");

        }
        cardList[cardCounter].SetCardEnglish(filtered_english);
        ClearStrings(i);
    }

    void SetFrenchPhrase(int i, int counter, string[] secondSegments)
    {
        string filtered_french = "";
        switch (counter)
        {
            case 0:
                french += secondSegments[i].ToString() + ": ";
                break;
            default:
                french += secondSegments[i].ToString() + " ";
                break;
        }
        if (!french.Contains("<P>") &&
            !french.Contains("< P >") &&
            !french.Contains("<C>")  &&
            !french.Contains("< C >"))
        {
            filtered_french = french;
        }
        else
        {
            first_filter = french.Replace("<P>", "\n");
            second_filter = first_filter.Replace("< P >", "\n");
            third_filter = second_filter.Replace("<C>", ",");
            filtered_french = third_filter.Replace("< C> ", ",");
        }
        cardList[cardCounter].SetCardFrench(filtered_french);
        ClearStrings(i);
    }

    void SetSpanishPhrase(int i, int counter, string[] secondSegments)
    {
        string filtered_spanish = "";
        switch (counter)
        {
            case 0:
                spanish += secondSegments[i].ToString() + ": ";
                break;
            default:
                spanish += secondSegments[i].ToString() + " ";
                break;
        }
        if (!spanish.Contains("<P>") &&
            !spanish.Contains("< P >") &&
            !spanish.Contains("<C>") &&
            !spanish.Contains("< C >"))
        {
            filtered_spanish = spanish;
        }
        else
        {
            first_filter = spanish.Replace("<P>", "\n");
            second_filter = first_filter.Replace("< P >", "\n");
            third_filter = second_filter.Replace("<C>", ",");
            filtered_spanish = third_filter.Replace("< C> ", ",");
        }
        cardList[cardCounter].SetCardSpanish(filtered_spanish);
        ClearStrings(i);
    }
}
