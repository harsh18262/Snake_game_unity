using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;



public class snake : MonoBehaviour
{
	Vector2 dir =Vector2.right;
	public bool ate =false;

	public GameObject tailPrefab;

	List<Transform> tail = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
    	for(int i=0;i<=4;i++){
    	Vector2 v = transform.position;
    	transform.Translate(dir);
		GameObject g =(GameObject)Instantiate (tailPrefab,v,Quaternion.identity);
		tail.Insert(0,g.transform);
	}	
			


        InvokeRepeating("Move",0.12f,0.12f);
    }

    // Update is called once per frame
    void Update()
    {
    	if(Input.GetKey(KeyCode.RightArrow) && dir!=-Vector2.right)
    	dir=Vector2.right;
    	else if(Input.GetKey(KeyCode.DownArrow)&& dir!=Vector2.up)
    	dir= -Vector2.up;
		else if(Input.GetKey(KeyCode.LeftArrow)&& dir!=Vector2.right)
    	dir=-Vector2.right;
    	else if(Input.GetKey(KeyCode.UpArrow)&& dir!=-Vector2.up)
    	dir= Vector2.up;
        
    }

    void Move()
    {
    	

    	Vector2 v = transform.position;

    		
    	transform.Translate(dir);

    	if(ate)
    	{
		GameObject g =(GameObject)Instantiate (tailPrefab,v,Quaternion.identity);
    		tail.Insert(0,g.transform);

    		ate=false;
    	}

    	else if(tail.Count>0)
    	{
    		tail.Last().position=v;

    		tail.Insert(0,tail.Last());

    		tail.RemoveAt(tail.Count-1);


    	}
    }



	 void OnTriggerEnter2D(Collider2D coll)
	    {
    		if(coll.name.StartsWith("FoodPrefab"))
			{
				ate =true;
				Destroy(coll.gameObject);
				foodspawn.food=false;
			}
			else
			{
				//public static void LoadScene(string Gameover, SceneManagement.LoadSceneMode mode = LoadSceneMode.Single);
				SceneManager.LoadScene("Gameover", LoadSceneMode.Additive);
				print("gameover");
			}
    	}
	}