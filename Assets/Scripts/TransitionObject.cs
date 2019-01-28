using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionObject : MonoBehaviour {

    [SerializeField] GameObject transitionFrom;
    [SerializeField] GameObject transitionTo;
    [SerializeField] Transform spawnPlace;

    public bool insider = false;

    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.UpArrow) && insider)
        {
            SoundManager.Instance.PlaySoundEffect("Door");
            transitionFrom.SetActive(false);
            transitionTo.SetActive(true);
            PlayerPlatformerController.Instance.transform.position = spawnPlace.position;
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
}
