using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float delayBeforeReload = 1f;
    [SerializeField] ParticleSystem finishEffect;
    [SerializeField] ParticleSystem lineEffect;

    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player");

        if (collision.gameObject.layer == layerIndex)
        {
            finishEffect.Play();
            lineEffect.Stop();
            Invoke("ReloadScene", delayBeforeReload);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
