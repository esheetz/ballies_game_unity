using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // sprite renderer
    private SpriteRenderer enemySprite;

    // speed parameters
    public float speedMin = 0.8f;
    public float speedMax = 1.2f;
    public float speed;

    // colors
    public Color redEnemyColor = new Color(195, 38, 38, 255);
    public Color greenEnemyColor = new Color(4, 166, 0, 255);
    public Color blueEnemyColor = new Color(0, 70, 255, 255);
    public Color purpleEnemyColor = new Color(144, 0, 255, 255);

    // flag for setting random colors
    public bool setRandomColor = false;

    // Start is called before the first frame update
    void Start()
    {
        // set speed
        speed = Random.Range(speedMin, speedMax);
    }

    void Awake()
    {
        // get the SpriteRenderer
        enemySprite = GetComponent<SpriteRenderer>();

        if (setRandomColor)
        {
            // randomly set color
            SetRandomColor();
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateEnemyPosition();
    }

    private void SetRandomColor()
    {
        // random integer [0, 4)
        int randInt = Random.Range(0, 4);
        // set color
        SetColor(randInt);
    }

    public void SetColor(int colorIdx)
    {
        // set color
        if (colorIdx == 0)
        {
            enemySprite.color = redEnemyColor;
        }
        else if (colorIdx == 1)
        {
            enemySprite.color = greenEnemyColor;
        }
        else if (colorIdx == 2)
        {
            enemySprite.color = blueEnemyColor;
        }
        else { // colorIdx == 3
            enemySprite.color = purpleEnemyColor;
        }
    }

    private void UpdateEnemyPosition()
    {
        // get mouse position relative to the camera
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // create new position
        Vector2 enemyDist = new Vector2((mousePos.x - this.gameObject.transform.position.x),
                                        (mousePos.y - this.gameObject.transform.position.y));
        enemyDist.Normalize();
        Vector2 enemyPos = new Vector2(this.gameObject.transform.position.x + (speed * Time.deltaTime * enemyDist.x),
                                       this.gameObject.transform.position.y + (speed * Time.deltaTime * enemyDist.y));
        // update enemy position based on mouse
        this.gameObject.transform.position = enemyPos;
    }
}
