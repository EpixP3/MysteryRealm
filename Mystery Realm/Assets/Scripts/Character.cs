using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Character : MonoBehaviour {
    public float Speed;
    public Vector2 touchOrigin;
    public Image touchpadImg, touchballImg;
    public Animator animator;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.touchCount > 0)
        {
            Touch myTouch = Input.touches[0];
            if (myTouch.phase == TouchPhase.Began)
            {
                if (myTouch.position.x < Screen.width/2)
                {
                    touchOrigin = myTouch.position;
                    animator.SetBool("isMoving", true);
                    touchpadImg.gameObject.SetActive(true);
                    touchballImg.gameObject.SetActive(true);
                    touchpadImg.gameObject.transform.SetPositionAndRotation(new Vector3(touchOrigin.x, touchOrigin.y,0), touchpadImg.transform.rotation);
                }
                else
                {
                    touchOrigin = new Vector2(0, 0);
                }
            }
            if (myTouch.phase == TouchPhase.Moved || myTouch.phase == TouchPhase.Stationary)
            {
                if (touchOrigin.x != 0 && touchOrigin.y != 0)
                {
                    Vector2 position = new Vector2(touchOrigin.x - myTouch.position.x, touchOrigin.y - myTouch.position.y);
                    if (position.x > 75)
                    {
                        position.x = 75;
                    }
                    if (position.y > 75)
                    {
                        position.y = 75;
                    }
                    if (position.x < -75)
                    {
                        position.x = -75;
                    }
                    if (position.y < -75)
                    {
                        position.y = -75;
                    }
                    touchballImg.gameObject.transform.SetPositionAndRotation(new Vector3(touchOrigin.x-position.x, touchOrigin.y-position.y, 0), touchballImg.transform.rotation);
                    float movex = position.x / -75;
                    float movey = position.y / -75;
                    animator.SetFloat("movex", movex);
                    animator.SetFloat("movey", movey);
                    transform.Translate(new Vector3(movex * Time.deltaTime * Speed, movey * Time.deltaTime * Speed, 0));
                    if (movex < 0) movex *= -1;
                    if (movey < 0) movey *= -1;
                    animator.speed = (movex * 1.5f) + (movey * 1.5f);
                }
            }
            if (myTouch.phase == TouchPhase.Ended){
                touchpadImg.gameObject.SetActive(false);
                animator.SetBool("isMoving", false);
                touchballImg.gameObject.SetActive(false);
                touchOrigin = new Vector2(0, 0);
            }
        }

    }
}
