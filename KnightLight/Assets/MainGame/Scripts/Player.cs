using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Completed
{
    public class Player : MovingObject
    {

        public float restartLevelDelay = 1f;
        public int pointsPerCandle = 10;
        public int wallDamage = 1;
        public Text foodText;


        private Animator animator;
        public static int food;

        protected override void Start()
        {
            animator = GetComponent<Animator>();

            food = GameManager.instance.playerFoodPoints;
            foodText.text = "Light: " + food.ToString();
            base.Start();
        }

        private void OnDisable()
        {
            GameManager.instance.playerFoodPoints = food;
        }


        private void Update()
        {
            if (!GameManager.instance.playersTurn) return;



            int horizontal = 0;
            int vertical = 0;

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Application.Quit();
                }

#if UNITY_STANDALONE || UNITY_WEBPLAYER

            horizontal = (int)(Input.GetAxisRaw("Horizontal"));

            vertical = (int)(Input.GetAxisRaw("Vertical"));

            if (horizontal != 0)
            {
                vertical = 0;
            }
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
			
			if (Input.touchCount > 0)
			{
				Touch myTouch = Input.touches[0];
				
				if (myTouch.phase == TouchPhase.Began)
				{
					touchOrigin = myTouch.position;
				}
				
				else if (myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0)
				{
					Vector2 touchEnd = myTouch.position;
					
					float x = touchEnd.x - touchOrigin.x;
					
					float y = touchEnd.y - touchOrigin.y;
					
					touchOrigin.x = -1;
					
					if (Mathf.Abs(x) > Mathf.Abs(y))
						horizontal = x > 0 ? 1 : -1;
					else
						vertical = y > 0 ? 1 : -1;
				}
			}
			
#endif


            if (horizontal != 0 || vertical != 0)
            {
                AttemptMove<Wall>(horizontal, vertical);
            }
        }

        protected override void OnCantMove<T>(T component)
        {
            Wall hitWall = component as Wall;

            hitWall.DamageWall(wallDamage);

            animator.SetTrigger("playerChop");
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Exit")
            {
                Invoke("Restart", restartLevelDelay);

                enabled = false;
            }


            else if (other.tag == "Candle")
            {
                food += pointsPerCandle;

                foodText.text = "+" + pointsPerCandle + " Candle: " + food;


                other.gameObject.SetActive(false);
            }


            else if (other.tag == "Enemy")
            {
                SceneManager.LoadScene("Card Combat");
            }
        }


        private void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }


        public void LoseFood(int loss)
        {
            animator.SetTrigger("playerHit");

            food -= loss;

            foodText.text = "-" + loss + " Food: " + food;

            CheckIfGameOver();
        }


        private void CheckIfGameOver()
        {
            if (food <= 0)
            {

                GameManager.instance.GameOver();
            }
        }
    }
}

