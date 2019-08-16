using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameObject[] ballsList;    

    private float x;
    private float y;

    // Start is called before the first frame update
    void Start()
    {
        ballsList = GetListOfBalls();
        
        foreach(GameObject ball in ballsList) {
            
            ball.transform.position = RandomPos();
        }
    }

    GameObject[] GetListOfBalls()
    {
        int size = gameObject.transform.childCount;
        ballsList = new GameObject[size];
        for (int i = 0; i < size; i++)
        {
            ballsList[i] = gameObject.transform.GetChild(i).gameObject;
        }
        return ballsList;
    }

    Vector3 RandomPos()
    {
        x = Random.Range(-1.89f, 1.89f);
        y = Random.Range(-2.44f, 4.09f);
        return new Vector3(x, y);
    }
}
