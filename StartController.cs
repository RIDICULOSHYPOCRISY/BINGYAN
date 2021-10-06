using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    // Start is called before the first frame update
    public void Starrrt()
    {
        SceneManager.LoadScene("Roguelike");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
