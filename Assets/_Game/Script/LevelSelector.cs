 using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelSelector : LevelManager

{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private int levelTe;
    void Start()
    {
        levelText.text = "Level" + levelTe.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
