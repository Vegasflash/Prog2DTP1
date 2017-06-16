using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    private string cardNo = "";
    private string count = "";
    private string priority = "";
    private string english = "";
    private string french = "";
    private string spanish = "";


    public void SetCardNo(string input) { cardNo = input; }
    public void SetCardCount(string input) { count = input; }
    public void SetCardPriority(string input) { priority = input; }
    public void SetCardEnglish(string input) { english = input; }
    public void SetCardFrench(string input) { french = input; }
    public void SetCardSpanish(string input) { spanish = input; }

    public string GetCardNo() { return cardNo; }
    public string GetCardCount() { return count; }
    public string GetCardPriority() { return priority; }
    public string GetCardEnglish() { return english; }
    public string GetCardFrench() { return french; }
    public string GetCardSpanish() { return spanish; }

}

