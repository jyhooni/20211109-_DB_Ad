﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{


	public Ball ScoreCount;
	public GameObject hoop;
	public GameObject newHoop;
	public GameObject block;
	public GameObject block2;
	public GameObject block3;
	public GameObject block4;
	public GameObject block5;

	public GameObject[] arrayHoop;

	//audio source
	//public AudioSource mySfx;
	//public AudioClip bgm;
	//public AudioClip BGM;

	#region Singleton class: GameManager



	// Sprite Renderer component 사용하기 위한 선언,초기화
	//public SpriteRenderer renderer;

	public static GameManager Instance;
	

	//gamdobject bg1,2,3를 받아온다. 
	public GameObject bg1;
	public GameObject bg2;
	public GameObject bg3;


	//private Ball scoremanager;
	

	//싱글톤이라는 디자인패턴. 하나밖에 존재할수밖에 없다. 어디서든 불러 쓸수 있다. 
	public static GameManager I;

	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}

		I = this;

	}


    #endregion

    Camera cam;

	public Ball ball;



	//public Trajectory trajectory;
	[SerializeField] float pushForce = 8f;

	bool isDragging = false;

	Vector2 startPoint;
	Vector2 endPoint;
	Vector2 direction;
	Vector2 force;
	float distance;

	
	//---------------------------------------
	void Start()
	{

		//bgm
		//Bgm();

		Debug.Log("startfunction");
		cam = Camera.main;
		ball.DesactivateRb();

		InvokeRepeating("floating", 0, 2.5f);

		initGame();
		//highscore = PlayerPrefs.GetInt("highscore", 0);
		//highscoreText.text = "HighScore:" + highscore.ToString(); 


		//Sprite Renderer component 사용하기 위한  초기화
		//renderer = GetComponent<SpriteRenderer>();

		//scoremanager = FindObjectOfType<Ball>();

		
	}

	void initGame()
    {
		Time.timeScale = 1.0f;
    }
	
	



	public void floating()
    {
		GameObject newHoop = Instantiate(hoop);
		//Instantiate(hoop);
    }
	
	
		void Update()
	{

		//장애물 생성

		if (GameObject.Find("Ball").GetComponent<Ball>().ScoreCount > 20)
		{
			block.SetActive(true);

		}
		if(GameObject.Find("Ball").GetComponent<Ball>().ScoreCount > 50)
		{
			block2.SetActive(true);
		}
		if (GameObject.Find("Ball").GetComponent<Ball>().ScoreCount > 80)
		{
			block3.SetActive(true);
		}

		if (GameObject.Find("Ball").GetComponent<Ball>().ScoreCount > 110)
		{
			block4.SetActive(true);
		}
		if (GameObject.Find("Ball").GetComponent<Ball>().ScoreCount > 150)
		{
			block5.SetActive(true);
		}
		
		
		//random 숫자 생성, coin의 setactive 랜덤으로 출력하려고. 
		int rand = Random.Range(3, 8);
		//Debug.Log(rand.ToString());

		//짝수
		if (rand % 2 == 0)
		{
			newHoop.transform.Find("coinAnimation").gameObject.SetActive(true);

		}
		if (rand % 2 == 1)
		{
			newHoop.transform.Find("coinAnimation").gameObject.SetActive(false);

		}



		if (Input.GetMouseButtonDown(0))
		{

			isDragging = true;
			OnDragStart();
		}
		if (Input.GetMouseButtonUp(0))
		{
			isDragging = false;
			OnDragEnd();
		}

		if (isDragging)
		{
			OnDrag();
		}

		//유니티 다른 스크립트에 있는 변수에 접근하기
		//GameObJect.Find(스크립트를 포함하는 오브젝트이름).GetComponent<스크립트 이름>().변수

		if (GameObject.Find("Ball").GetComponent<Ball>().ScoreCount< 20)
		{
			//Debug.Log("1");
			//검색해서 하는 방법 코드를 가져와서 사용하기
			//rain스크립트의 오른쪽 화면 component에서 spriterenderer에 color를 수정하는것. 
			//GetComponent<SpriteRenderer>().color = new Color(100 / 255.0f, 100 / 255.0f, 255 / 255.0f, 255 / 255.0f);
			
			//GameObject.Find("bg1").GetComponent<SpriteRenderer>().set
			bg1.SetActive(true);
			bg2.SetActive(false);
			bg3.SetActive(false);

			//.SetActive(true);

			
			newHoop.transform.Find("hoop1").gameObject.SetActive(true);
			//newHoop.transform.Find("hoop1_1").gameObject.SetActive(false);
			//GameObject.FindGameObjectWithTag("hoop1").SetActive(true);
			//GameObject.FindGameObjectWithTag("hoop1_1").SetActive(false);
			//hoop.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
			//hoop1.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
			//Prefabs.Getchild(0).gameObject;

			//GameObject의 부로 hoop -> 자식 hoop1으로 들어가는건 됨. 
			//GameObject.Find("hoop").transform.Find("hoop1").gameObject.SetActive(false);
			//GameObject.Find("hoop").transform.Find("hoop1_1").gameObject.SetActive(false);
			//GameObject.Find("hoop").transform.Find("hoop1_1").gameObject.SetActive(false);

			//Null 이 발생하는건  hoop1이 정의안되서 그런거같다. 

			//GameObject.Find("hoop1").gameObject.SetActive(false);
			//GameObject.Find("hoop1_1").gameObject.SetActive(true);


			//GameObject.Find("hoop").transform.GetChild(3).gameObject.SetActive(true);
			//GameObject.Find("hoop").transform.GetChild(5).gameObject.SetActive(false);


			//.getchild(0).setactive(true);

		}
		if (GameObject.Find("Ball").GetComponent<Ball>().ScoreCount >= 20 && GameObject.Find("Ball").GetComponent<Ball>().ScoreCount < 60)
		{
			//Debug.Log("2");
			bg2.SetActive(true);
			bg3.SetActive(false);
			bg1.SetActive(false);

		
		}
		
		if (GameObject.Find("Ball").GetComponent<Ball>().ScoreCount >= 60 && GameObject.Find("Ball").GetComponent<Ball>().ScoreCount < 100)
		{
			
			bg3.SetActive(true);
			bg2.SetActive(false);
			bg1.SetActive(false);
					
		}
		if (GameObject.Find("Ball").GetComponent<Ball>().ScoreCount >= 100 && GameObject.Find("Ball").GetComponent<Ball>().ScoreCount < 150)
		{

			bg1.SetActive(true);
			bg2.SetActive(false);
			bg3.SetActive(false);

		}


	}
	//score---------------
	
	
	//-Drag--------------------------------------
	void OnDragStart()
	{
		//공이 멈추게 만들어버림.
		//ball.DesactivateRb();
		startPoint = cam.ScreenToWorldPoint(Input.mousePosition);

		//공 점점커지는게 보인다. 
		//trajectory.Show();
	}

	void OnDrag()
	{
		endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
		distance = Vector2.Distance(startPoint, endPoint);
		direction = (startPoint - endPoint).normalized;
		force = direction * distance * pushForce;

		//just for debug
		//Debug.DrawLine(startPoint, endPoint);


		//trajectory.UpdateDots(ball.pos, force);
	}

	void OnDragEnd()
	{
		//push the ball
		ball.ActivateRb();

		ball.Push(force);

		//trajectory.Hide();
	}

	public void retry()
	{
		SceneManager.LoadScene("Game");
	}

	public void gameend()
	{
		SceneManager.LoadScene("Gameover");
	}

	


}