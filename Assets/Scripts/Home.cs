using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour {

	public void StartGame () {
        StartCoroutine(FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, "SampleScene"));
    }
}
