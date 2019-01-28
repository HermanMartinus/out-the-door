using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeScript : MonoBehaviour {

    [SerializeField] float extraGumption = 0.1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManager.Instance.PlaySoundEffect("Slurp");
        GumptionMeter.Instance.gumption += extraGumption;
        GumptionMeter.Instance.transform.localScale = Vector2.one * 1.1f;
        Destroy(this.gameObject);
    }
}
