using UnityEngine;
using UnityEngine.UI;

public class SmokeController : MonoBehaviour
{
    public ParticleSystem smoke;
    private bool smokeActive = true;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ToggleSmoke);
    }

    void ToggleSmoke()
    {
        smokeActive = !smokeActive;

        if (smokeActive)
        {
            smoke.Play();
        }
        else
        {
            smoke.Stop();
        }
    }
}
