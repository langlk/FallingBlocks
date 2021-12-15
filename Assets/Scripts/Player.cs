using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10;
    public event System.Action OnPlayerDeath;

    float screenWrapPoint;
    // Start is called before the first frame update
    void Start()
    {
        screenWrapPoint = Camera.main.aspect * Camera.main.orthographicSize + transform.localScale.x / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        Vector3 velocity = input.normalized * speed;
        transform.Translate(velocity * Time.deltaTime);

        if (transform.position.x < -screenWrapPoint) {
            transform.position = new Vector2(screenWrapPoint, transform.position.y);
        } else if (transform.position.x > screenWrapPoint) {
            transform.position = new Vector2(-screenWrapPoint, transform.position.y);
        }
    }

    void OnTriggerEnter2D(Collider2D triggerCollider) {
        if (triggerCollider.tag == "Block") {
            if (OnPlayerDeath != null) OnPlayerDeath();
            Destroy(gameObject);
        }
    }
}
