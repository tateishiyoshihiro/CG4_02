using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public GameObject gameClearText;
    public static bool isGameOver = false;

    private void OnTriggerEnter(Collider other)
    {
        gameClearText.SetActive(true);
        isGameOver = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameClearText.SetActive(false);
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
