using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LevelChosing : MonoBehaviour
{

    public TextMeshProUGUI applesLevel1;
    public TextMeshProUGUI applesLevel2;
    // Start is called before the first frame update
    void Start()
    {
        applesLevel1.text = PlayerPrefs.GetInt("NumberOfApplesLevel1",0).ToString()+"/50";
        applesLevel2.text = PlayerPrefs.GetInt("NumberOfApplesLevel2",0).ToString()+"/50";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
