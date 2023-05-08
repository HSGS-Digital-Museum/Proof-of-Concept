using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    int[] rotations = {0, 90, 180, 270};
    [SerializeField] float PipeType;

    public int correctRotation;
    [SerializeField]bool isPlaced = false;

    GameManager gameManager;

    private void Awake(){
        
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Start()
    {
        int rand = Random.Range(1, rotations.Length-1);
        transform.eulerAngles = new Vector3(0, 0, rotations[rand]);
        if(PipeType == 1){
            if((transform.eulerAngles.z == correctRotation || transform.eulerAngles.z == correctRotation - 180 || transform.eulerAngles.z == correctRotation + 180) && !isPlaced){
                isPlaced = true;
                gameManager.CorrectMove();
            }
        }
        if(transform.eulerAngles.z == correctRotation && !isPlaced){
            isPlaced = true;
            gameManager.CorrectMove();
        }
    }

    private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0,0,90));
        transform.eulerAngles = new Vector3(0, 0, Mathf.Round(transform.eulerAngles.z));
        
        // if(PipeType == 2){
        //     Debug.Log(transform.eulerAngles.z);
        // }

        if(PipeType == 1){
            if((transform.eulerAngles.z == correctRotation || transform.eulerAngles.z == correctRotation - 180 || transform.eulerAngles.z == correctRotation + 180) && !isPlaced){
                isPlaced = true;
                gameManager.CorrectMove();
            }
            else if(isPlaced){
                    isPlaced = false;
                    gameManager.WrongMove();
            }
        }
        else{
            if(transform.eulerAngles.z == correctRotation && !isPlaced){
                isPlaced = true;
                gameManager.CorrectMove();
            }
            else if(isPlaced){
                    isPlaced = false; 
                    gameManager.WrongMove();   
            }
        }
    }
}
