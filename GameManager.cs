using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PipesHolder;
    public GameObject[] Pipes;

    [SerializeField]int correctedPipe = 0;
     
    [SerializeField]int totalPipes = 0;
    // Start is called before the first frame update
    void Start()
    {
        totalPipes = PipesHolder.transform.childCount;

        Pipes = new GameObject[totalPipes];

        for(int i = 0 ; i < Pipes.Length ; i++)
        {
            Pipes[i] = PipesHolder.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    public void CorrectMove(){
        correctedPipe++;

        if(correctedPipe == totalPipes){
            Debug.Log("YOU WIN!");
        }
    }

    public void WrongMove(){
        correctedPipe--;
    }
}
