using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MUSCLEMOVE : MonoBehaviour
{
    [SerializeField]
    float speed = 10.0f;
    bool move = false;
    public Rigidbody2D rigidbody;
    public AudioClip RUN;
    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            rigidbody.velocity = new Vector3(transform.right.x * -1 * speed, 0, 0);
            if (Time.timeScale == 0)
                transform.position += new Vector3(-1, 0, 0);
        }
    }

    public void Move()
    {
        StartCoroutine(WaitThenRun());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("DeathZone");
        }
    }

    public IEnumerator WaitThenRun()
    {
        GameController.PlaySound(RUN);
        yield return new WaitForSeconds(2);
        move = true;
    }
}
