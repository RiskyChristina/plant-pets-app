using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectContainer : MonoBehaviour
{
    public bool isDirtFull;
    public bool isSeedFull;
    public GameManager gameManager;
    public Image backgroundImage;
    public Image dirtBackgroundImage;
    public static ObjectContainer instance;

    public void Start()
    {
        gameManager = GameManager.instance;
    }

    private void Awake()
    {
        instance = this;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameManager.draggingObject != null && isDirtFull == false)
        {
            //isDirtFull = true;
            gameManager.currentContainer = this.gameObject;
            backgroundImage.enabled = true;
        }

        if (gameManager.draggingSeed != null && isDirtFull == true && isSeedFull == false) 
        {
            //isSeedFull = true;
            gameManager.seedContainer = this.gameObject;
            dirtBackgroundImage.enabled = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        gameManager.currentContainer = null;
        backgroundImage.enabled = false;
        gameManager.seedContainer = null;
        dirtBackgroundImage.enabled = false;
    }

}
