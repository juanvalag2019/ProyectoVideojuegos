using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpecial : MonoBehaviour
{
    [SerializeField] float speed;
    public bool direction;
    private float maxX, minX;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        float tamX = (GetComponent<SpriteRenderer>()).bounds.size.x;
        float tamY = (GetComponent<SpriteRenderer>()).bounds.size.y;
        Vector2 esquinaInfDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
        maxX = esquinaInfDer.x;
        Vector2 esquinalnflzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        minX = esquinalnflzq.x;
    }
    // Update is called once per frame
    void Update()
    {

        transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
        if (direction)
            transform.Translate(new Vector2(speed * Time.deltaTime, 0));
        else
            transform.Translate(new Vector2(-speed * Time.deltaTime, 0));

        if (transform.position.x >= maxX)
        {
            direction = false;
        }
        else if (transform.position.x <= minX)
        {
            direction = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
        }
    }


}
