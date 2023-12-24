using System.Collections;
using UnityEngine;

public class LightReleaseTechnique : MonoBehaviour
{
    public PlayerTechniqueUiController TechniqueUiController;
    public float LightReleaseTechniqueTimer = 0f;
    [SerializeField] private float _lightReleaseTechniqueCooldown = 2.5f;
    public ParticleSystem LightReleaseParticleSystem;
    private bool _canCastLightRelease = true;

    public void ReleaseLightChi()
    {
        if (_canCastLightRelease)
        {
            StopCoroutine(LightReleaseTechniqueCDRoutine());
            LightReleaseParticleSystem.Play();
            _canCastLightRelease = false;
            TechniqueUiController.UpdateTechniqueUiHint(true);
            StartCoroutine(LightReleaseTechniqueCDRoutine());
        }
    }

    private IEnumerator LightReleaseTechniqueCDRoutine()
    {
        LightReleaseTechniqueTimer = _lightReleaseTechniqueCooldown;
        _canCastLightRelease = false;
        while (LightReleaseTechniqueTimer > 0f)
        {
            TechniqueUiController.UpdateTechniqueUi(LightReleaseTechniqueTimer);
            LightReleaseTechniqueTimer -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        TechniqueUiController.UpdateTechniqueUiHint(false);
        _canCastLightRelease = true;
        yield return null;
    }
}
