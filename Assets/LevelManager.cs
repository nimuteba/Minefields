using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private const int alpha = 1;
    private enemy[] enemies;
    private static int nextLevel = 1;

    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI scoreText;

    //[SerializeField] enemy enemy1;
    //[SerializeField] enemy enemy2;

    private float fadeLength;
    public int scoreCount = 0;

    // Start is called before the first frame update
    void Start()
    {

        fadeIn();
        //enemy1 = gameObject.GetComponent<enemy>();
        //enemy2 = gameObject.GetComponent<enemy>();
        enemies = FindObjectsOfType<enemy>();
        //scoreText.text = "Score: " + scoreCount;
    }

    private void OnEnable()
    {
        
        //fadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        //fadeIn();
        scoreText.text = "Score: " + scoreCount;
        //scoreCount += enemy1.GetScore();

        foreach (enemy enemy in enemies)
        {
            //Debug.Log("enemis name: "+enemy.name);
            scoreCount += enemy.score;

            //scoreCount = enemy.score;
            //scoreText.text = "Score: " + scoreCount;
            if (enemy != null) return;
        }

        Debug.Log("Level"+nextLevel+" cleared!");
        nextLevel += 1;
        string nextLevelName = "Level"+nextLevel;

        //SceneManager.LoadScene(nextLevelName);
    }

    void fadeIn()
    {
        Debug.Log("In the fade!");
        levelText.text = "Level " + nextLevel /*"Malanda ngulu"*/;
        //levelText.color.a = 0f;
        levelText.CrossFadeAlpha(0f, 0f, false);
        levelText.CrossFadeAlpha(1f, 3f, false);
        fadeLength += Time.deltaTime;
        //levelText.text = "Level" + nextLevel;

        /*if (levelText.color.a == 1 && fadeLength > 3.5f)
        {
            Debug.Log("Out the fade");
            return;
        }*/
    }

    public float getScore()
    {
        return scoreCount;
    }

}
