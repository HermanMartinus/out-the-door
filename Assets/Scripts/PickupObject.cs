using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour {

    public string soundName;
    public float delay = 0f;

    private void Start()
    {
        if(delay != 0f)
        {
            GetComponent<AudioSource>().PlayDelayed(delay);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManager.Instance.PlaySoundEffect(soundName);
        FindObjectOfType<TaskMaster>().CheckOff(gameObject.name);
        Destroy(this.gameObject);
    }
}
