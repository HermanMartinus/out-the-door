using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GumptionMeter : MonoBehaviour {

    [SerializeField] Slider slider;
    public float gumption = 1f;

    float timer;

    public static GumptionMeter Instance;

    bool fellAsleep = false;

    private void Start()
    {
        Instance = this;
        timer = Time.time;
    }
    // Update is called once per frame
    void Update () {
        if (gumption > 1)
        {
            gumption = 1;
        }
        slider.value = gumption;
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1)
        {
            //Called once every second
            if (Time.time - timer > 1f)
            {
                gumption -= 0.03f;
                timer = Time.time;
                transform.localScale = Vector2.one * 1.01f;
            }
        }

        if(gumption < 0 && !fellAsleep)
        {
            fellAsleep = true;
            SoundManager.Instance.PlaySoundEffect("Snore");
            PlayerPlatformerController.Instance.GetComponent<Animator>().SetTrigger("fallAsleep");
            PlayerPlatformerController.Instance.enabled = false;
            StartCoroutine(FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, "SampleScene"));
        }


        transform.localScale = Vector2.Lerp(transform.localScale, Vector2.one, Time.deltaTime*10);

    }
}
