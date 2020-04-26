using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodspawn : MonoBehaviour
{

public GameObject FoodPrefab;

public Transform border_top;
public Transform border_bottom;
public Transform border_left;
public Transform border_right;

public static bool food=true;

    // Start is called before the first frame update
    void Start()
    {
    	spawn();
       //InvokeRepeating("spawn",3,4);
       
      

    }

    void Update()
    {
    	if(!food)
    	{
    	spawn();
   		}
    }

    void spawn()
    {
        int y=(int) Random.Range(border_top.position.y-1,border_bottom.position.y-1);

        int x=(int) Random.Range(border_left.position.x-1,border_right.position.x-1);

        Instantiate(FoodPrefab, new Vector2(x,y),Quaternion.identity);

        food=true;


    }


}
