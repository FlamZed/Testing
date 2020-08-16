using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelControll : MonoBehaviour
{
    private static int levelCount { get; set; }
    [SerializeField] private TargetControll targetControll;
    [SerializeField] private TMP_Text levelText;

    void Start()
    {
        levelCount = 1;
    }

    public void nextLevel()
    {
        levelCount++;
        levelText.text = levelCount.ToString();
        Enemy.reactionSpeed = levelCount;
        targetControll.ResetTarget();
    }
}
