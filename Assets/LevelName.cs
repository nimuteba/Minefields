using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelName : MonoBehaviour
{
    private enemy[] enemies;
    private static int nextLevel = 1;

    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private Button button;

    // Start is called before the first frame update
    void Start()
    {
        enemies = FindObjectsOfType<enemy>();
        Debug.Log("Boutta fade");
        levelText.CrossFadeAlpha(0f, 3.9f, false);
        //fadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        //fadeIn();

        foreach (enemy enemy in enemies)
        {
            if (enemy != null) return;
        }

        Debug.Log("Level" + nextLevel + " cleared!");
        nextLevel += 1;
        string nextLevelName = "Level" + nextLevel;
        //SceneManager.LoadScene(nextLevelName);
    }
}
