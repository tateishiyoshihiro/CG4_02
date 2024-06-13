using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    
    public GameObject block;
    public GameObject block2;
    public GameObject goal;
    public GameObject coin;
    public GameObject goalParticle;
    public TextMeshProUGUI scoreText;
    public static int score = 0;
    int[,] map = {
    {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
    {1,0,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,1,0,1,0,0,0,1,0,2,1,0,1,0,1,0,0,0,0,0,0,0,0,1},
    {1,0,1,1,1,0,1,1,1,0,1,2,0,1,0,1,1,1,0,0,0,1,0,0,0,0,1,0,0,0,0,0,1,0,1,1,1,1,0,1},
    {1,0,1,3,1,0,1,0,0,0,1,1,0,1,0,1,0,0,0,1,0,1,1,1,1,1,1,1,0,1,1,1,1,1,1,2,0,1,0,1},
    {1,0,1,0,2,0,0,0,1,0,0,1,0,1,2,1,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,1,0,1},
    {1,0,1,0,1,1,1,1,1,1,0,1,0,1,1,1,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,0,1,0,1},
    {1,0,1,0,0,0,0,0,0,1,0,1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,1,1,0,1,0,1},
    {1,0,1,1,1,1,1,1,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,0,1,0,1,1,0,0,1,0,1,0,1},
    {1,4,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,2,1,0,0,0,1,2,1},
    {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
    };
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, false);
        Vector3 position = Vector3.zero;
        Instantiate(block, position, Quaternion.identity);
        GameManagerScript.score = 0;
        int lenY = map.GetLength(0);
        int lenX = map.GetLength(1);
     for (int x = 0; x < 40; x++)
      for (int y = 0; y < 10; y++)
      {
       {
        position.x = x;
        position.y = y;
        position.y = -y + 5;
        if (map[y, x] == 1)
        {
            Instantiate(block, position, Quaternion.identity);
        }
        if (map[y, x] == 3)
        {
             Instantiate(goal, position, Quaternion.identity);
             goal.transform.position = position;
             goalParticle.transform.position = position;
        }
        if (map[y, x] == 2)
        {
            Instantiate(coin, position, Quaternion.identity);
        }
       }
      }
        for(int y = 0; y < lenY; y++)
        {
            for(int x = 0; x < lenX; x++)
            {
                position.x = x;
                position.y = -y + 5;
                position.z = 3;
                Instantiate(block2, position, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE" + score;
        //ゲームクリアでスペースキーでタイトルに
        if (GoalScript.isGameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("TitleScene");
            }
        }
    }
    //完了
}
