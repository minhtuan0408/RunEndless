using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region PlayerState
    public enum PlayerState
    {
        Idle,
        Left,
        Right,
        Fire
    }
    #endregion

    #region StateMachine
    private void ChangeState(PlayerState newstate)
    {
        animator.SetBool(currentState.ToString(), false);

        animator.SetBool(newstate.ToString(), true);

        currentState = newstate;
    }


    #endregion

    #region ControllerOnMobile
    public bool FreeMove;
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private Vector3 targetPosition;
    private Camera mainCamera;
    #endregion

    #region Skin
    public RuntimeAnimatorController[] animatorControllers;
    private Animator animator;
    #endregion

    #region Skill
    private bool isShield = true;
    public GameObject Shield;

    public GameObject Magnet;

    #endregion


    private PlayerState currentState;
    private PlayerHeart playerHeart;
    private SpriteRenderer spriteRenderer;

    private new Rigidbody2D rigidbody2D;


    public Transform[] RoadPosition;
    private int index;
    
    private void Awake()
    {
        transform.position = new Vector3(RoadPosition[1].position.x, RoadPosition[1].position.y, transform.position.z);
        index = 1;


        playerHeart = GetComponent<PlayerHeart>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        FreeMove = false;
        mainCamera = Camera.main;
        int selectedSkinIndex = PlayerPrefs.GetInt("SelectedSkin", 0);
        animator.runtimeAnimatorController = animatorControllers[selectedSkinIndex];
        targetPosition = transform.position;
        currentState = PlayerState.Idle;
    }
    private void Update()
    {
        if (FreeMove)
        {
            PlayerFreeController();
        }
        else
        {
            MoveIndex();
        }
    
    }
    private int IndexToMoveLeft()
    {
        if (this.index > 0 && this.index < 3)
        {
            this.index -= 1;
        }
        else if (this.index > 3 && this.index < 6)
        {
            this.index -= 1;
        }
        return this.index;
    }

    private int IndexToMoveRight()
    {
        if (this.index < 2)
        {
            this.index += 1;
        }
        else if (this.index < 5 && this.index > 2)
        {
            this.index += 1;
        }
        return this.index;
    }

    private int IndexToMoveUp()
    {
        if (this.index > -1 && this.index < 3)
        {
            this.index += 3;
        }
        return this.index;
    }

    private int IndexToMoveDown()
    {
        if (this.index > 2 && this.index < 6)
        {
            this.index -= 3;
        }
        return this.index;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Bullet"))
        {
            if (!isShield)
            {
                playerHeart.HeartImage[playerHeart.HeartCount - 1].SetActive(false);
                playerHeart.HeartCount--;
                if (playerHeart.HeartCount > 1)
                {
                    Debug.Log("GameOver");
                }
                StartCoroutine(TakedDamege(2f));
            }
        }

        if (collision.gameObject.CompareTag("Magnet"))
        {
            StartCoroutine(MagnetUsed(5f));
        }

        if (collision.gameObject.CompareTag("Shield"))
        {
            StartCoroutine(ShieldUsed(5f));
        }
    }

    private IEnumerator TakedDamege(float value)
    {
        float elapsedTime = 0f;
        Physics2D.IgnoreLayerCollision(8, 9, true);
        while (elapsedTime < value)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.2f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.2f);
            elapsedTime += 0.4f;
        }
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }

    private IEnumerator MagnetUsed(float value)
    {
        Magnet.SetActive(true);
        yield return new WaitForSeconds(value);
        Magnet.SetActive(false);
    }

    private IEnumerator ShieldUsed(float value) 
    {
        Shield.SetActive(true);
        isShield = true;
        yield return new WaitForSeconds(value);
        isShield = false;
        Shield.SetActive(false);
    }

    #region MoveController
    public void MoveIndex()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }



        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;
            // check xem vuốt lên hay xuống;
            Vector2 swipeVector = endTouchPosition - startTouchPosition;

            if (swipeVector.sqrMagnitude > 0)
            {   // Trái phải
                if (Mathf.Abs(swipeVector.x) > Mathf.Abs(swipeVector.y))
                {
                    if (endTouchPosition.x < startTouchPosition.x)
                    {
                        targetPosition = RoadPosition[IndexToMoveLeft()].transform.position;
                        ChangeState(PlayerState.Left);
                    }
                    else if (endTouchPosition.x > startTouchPosition.x)
                    {
                        targetPosition = RoadPosition[IndexToMoveRight()].transform.position;
                        ChangeState(PlayerState.Right);
                    }
                }
                // Lên Xuống
                else
                {

                    if (endTouchPosition.y < startTouchPosition.y)
                    {
                        targetPosition = RoadPosition[IndexToMoveDown()].transform.position;

                    }

                    else if (endTouchPosition.y > startTouchPosition.y)
                    {
                        targetPosition = RoadPosition[IndexToMoveUp()].transform.position;

                    }
                }

            }

        }

        if (Math.Abs(transform.position.x - targetPosition.x) < 0.4f)
        {
            ChangeState(PlayerState.Idle);

        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, 5f * Time.deltaTime);
    }

    public void PlayerFreeController()
    {
        if (Input.touchCount > 0 )
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 touchPosition = mainCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0));
                targetPosition = touchPosition;
            }
        }
        transform.position = Vector2.Lerp(transform.position, targetPosition, 10f * Time.deltaTime);
        

    }
    #endregion
}


