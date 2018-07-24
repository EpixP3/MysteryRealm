using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_move : MonoBehaviour
{
    public GameObject tutorial_move;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Hidetutorial();
        }
    }
    public void Hidetutorial()
    {
        tutorial_move.SetActive(false);
    }
}

