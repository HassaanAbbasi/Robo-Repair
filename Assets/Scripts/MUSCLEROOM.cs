using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MUSCLEROOM : MonoBehaviour
{
    public Transform molePosition;
    public GameObject Mole;
    public Transform targetDoorPos;
    public GameObject door;
    public bool moveDoor = false;

    public AudioClip rise;
    // Update is called once per frame
    void Update()
    {
        if (moveDoor && door.transform.position.y < targetDoorPos.position.y)
        {
            door.transform.position += new Vector3(0, 1, 0) * Time.deltaTime * 5.0f;

        }
        if (moveDoor)
        {
            if (Mole.transform.position.y < molePosition.position.y)
                Mole.transform.position += new Vector3(0, 1, 0) * Time.deltaTime * 10.0f;
            else
                Mole.SendMessage("Move");

        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            moveDoor = true;
            Camera.main.GetComponent<Camera>().orthographicSize = 25;
            GameController.PlaySound(rise);
        }
    }
}
