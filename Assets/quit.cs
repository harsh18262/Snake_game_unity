using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quit : MonoBehaviour
{
	public Button qu;
    // Start is called before the first frame update
    void Start()
    {
    	qu.onClick.AddListener(quit_game);
        
    }

    void quit_game()
    {
    	Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
