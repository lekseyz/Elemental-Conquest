using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MagicSystem : MonoBehaviour 
{
    public enum Elements
    {
        Fire,
        Wind,
        Stone,
        Water
    }
    const int maxElem = 2;

    private Queue<Elements> elementsAdded = new Queue<Elements>();


    public void addElem(Elements element)
    {
        Debug.Log(element + " added");
        elementsAdded.Enqueue(element);

        if (elementsAdded.Count > maxElem)
        {
            Debug.Log(elementsAdded.Dequeue() + " removed");
        }
    }

    public string getFinalCombination()
    {
        if(elementsAdded.Count == 0) { return ""; }

        string combination = "";
        while (elementsAdded.Count > 0)
        {
            var elem = elementsAdded.Dequeue();
            switch(elem)
            {
                case Elements.Fire:
                    combination += "f";
                    break;
                case Elements.Wind:
                    combination += "w";
                    break;
                   
            }
        }
        char[] chars = combination.ToCharArray();
        Array.Sort(chars);
        combination = new string(chars);

        return combination;
    }
}
