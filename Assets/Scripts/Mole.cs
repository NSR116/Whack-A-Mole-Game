using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    [SerializeField] private float positionY = 0.6f;
    [SerializeField] private float speed = 5f;

    private bool readyShow = false;
    public bool ReadyShow   // property
    {
        get { return readyShow; }
        set { readyShow = value; }
    }
    private bool hides = false;
    public bool Hides   // property
    {
        get { return hides; }
        set { hides = value; }
    }
    private Vector3 startPosition;
    private PolygonCollider2D cc;
    // Event for mole click
    public event Action MoleClicked;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = gameObject.transform.position;
        cc = gameObject.GetComponent<PolygonCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (!hides)
        {
            cc.enabled = true;

                if (gameObject.transform.position.y < positionY)
                    movingUp();

                else
                    gameObject.transform.position = new Vector3(startPosition.x, positionY, startPosition.z);

        }

        else
        {
            if (gameObject.transform.position.y >= positionY)
                movingDown();

            else
                gameObject.transform.position = new Vector3(startPosition.x, -0.5f, startPosition.z);
        }


    }

    private void movingUp()
    {
        gameObject.transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void movingDown()
    {
        gameObject.transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        if (!hides)
        {
            MoleClicked.Invoke();
            hides = true;
            cc.enabled = false;
        }
        
    }
}
