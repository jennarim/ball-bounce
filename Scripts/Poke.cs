using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poke : MonoBehaviour
{
    public Sprite poke1;
    public Sprite poke2;

    void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().sprite = poke2;
    }

    void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().sprite = poke1;
    }

}
