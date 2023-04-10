using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class VignetteOnDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public static VignetteOnDamage Instance { get; private set; }
    private PostProcessProfile volumeProfile;
    void Start()
    {
        Instance = this;
        volumeProfile = GetComponent<PostProcessVolume>().profile;
        if (!volumeProfile) throw new System.NullReferenceException(nameof(PostProcessProfile));
    }

    public IEnumerator showVignette(int seconds)
    {
        //why does it only get enabled after death?
        
        Vignette vignette;

        if (!volumeProfile.TryGetSettings(out vignette)) throw new System.NullReferenceException(nameof(vignette));

        float initialintensity = vignette.intensity;
        vignette.intensity.Override(0.6f);
        yield return new WaitForSecondsRealtime(seconds);
        vignette.intensity.Override(initialintensity);
    }

}
