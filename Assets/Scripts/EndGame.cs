using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

    public bool insider = false;
    public Sprite open;

    private void Update()
    {

        GetComponent<SpriteRenderer>().sprite = FindObjectOfType<TaskMaster>().IsCompleted() ? open : GetComponent<SpriteRenderer>().sprite;
        if (Input.GetKeyDown(KeyCode.UpArrow) && insider)
        {
            if (FindObjectOfType<TaskMaster>().IsCompleted())
            {
                SoundManager.Instance.PlaySoundEffect("OutTheDoor");
                SceneManager.LoadScene("Home");
            }
            else
            {
                SoundManager.Instance.PlaySoundEffect("Locked");
                FindObjectOfType<TaskMaster>().transform.localScale = Vector2.one * 1.5f;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        insider = true;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        insider = false;
    }

    public void StartAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
