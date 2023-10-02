using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D[] cursorTextArray;

    private int currentFrame;
    private float frameTimer;
    public int frameCount;
    public float frameRate;
    private bool hasFired;

    [SerializeField] GameObject bulletObject;
    Bullet bullet;


    private void Awake()
    {
        bullet = bulletObject.GetComponent<Bullet>();
    }

    void Start()
    {
        Cursor.SetCursor(cursorTextArray[1], new Vector2(24f, 24f), CursorMode.ForceSoftware);
    }

    private void Update()
    {
        frameTimer -= Time.deltaTime;
        if (frameTimer <= 0) 
        {
            frameTimer += frameRate;
            currentFrame = (currentFrame + 1) % frameCount;
            Cursor.SetCursor(cursorTextArray[currentFrame], new Vector2(24f,24f), CursorMode.ForceSoftware);
        }

        if (currentFrame == 0 && !hasFired) 
        { 
            bullet.Fire(); hasFired = true;
        }

        if (currentFrame == 1)
        {
            hasFired = false;
        }
    }
}
