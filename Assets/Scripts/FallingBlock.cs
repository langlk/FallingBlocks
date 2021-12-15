using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    public Vector2 speedRange = new Vector2(5, 13);
    float speed;
    float screenBottom;

    void Start() {
        speed = Mathf.Lerp(speedRange.x, speedRange.y, Difficulty.GetDifficultyPercent());
        screenBottom = -Camera.main.orthographicSize - transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.Self);
        if (transform.position.y < screenBottom) {
            Destroy(gameObject);
        }
    }
}
