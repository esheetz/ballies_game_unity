using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int lives = 3;
    public int bombs = 10;
    public int score = 0;
    public int level = 1;

    // Start is called before the first frame update
    void Start()
    {
        // set player position
        this.gameObject.transform.position = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerPosition();
    }

    private void UpdatePlayerPosition()
    {
        // get mouse position relative to the camera
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // create new position
        Vector2 playerPos = new Vector2(mousePos.x, mousePos.y);
        // set player position based on mouse
        this.gameObject.transform.position = playerPos;
    }
}
