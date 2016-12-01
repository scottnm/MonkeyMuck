using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FireRingReload : MonoBehaviour
{
    [SerializeField]
    float fadeTime;
    [SerializeField]
    float endFadeIntensity;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            var controlScript = col.gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>();
            if (controlScript.enabled)
            {
                controlScript.enabled = false;
                StartCoroutine(RunFadeAndReload());
            }
        }
    }

    IEnumerator RunFadeAndReload()
    {
        var overlayScript = GameObject.FindObjectOfType<Camera>().gameObject.GetComponent<UnityStandardAssets.ImageEffects.ScreenOverlay>();
        float time = 0;
        while (time < fadeTime)
        {
            overlayScript.intensity = Mathf.Lerp(0, endFadeIntensity, time / fadeTime);
            yield return new WaitForFixedUpdate();
            time += Time.deltaTime;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
