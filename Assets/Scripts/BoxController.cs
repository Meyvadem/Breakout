using UnityEngine;

public class BoxController : MonoBehaviour
{
    public int health;

    public Texture crackedNormal;
    public Texture crackedHeight;
    public Texture crackedOcclusion;
    public Texture crackedAlbedo;
    public float increasedNormalMapValue;


    private Material material;


    void Start()
    {
        material = GetComponent<Renderer>().material;

    }

    public void TakeDamage()
    {
        health--;

        if (health == 1)
        {
            ApplyCrackEffect();

        }
        else if (health <= 0)
        {
            // Üçüncü darbe aldý, tuðla yok edilsin
            Destroy(gameObject);
        }
    }

    public void ApplyCrackEffect()
    {
        if (crackedAlbedo != null)
        {
            material.SetTexture("_MainTex", crackedAlbedo);
        }
        if (crackedNormal != null)
        {
            material.SetTexture("_BumpMap", crackedNormal);
            IncreaseNormalMapValue();
        }
        if (crackedHeight != null)
        {
            material.SetTexture("_ParallaxMap", crackedHeight);
        }
        if (crackedOcclusion != null)
        {
            material.SetTexture("_OcclusionMap", crackedOcclusion);
        }

    }


    void IncreaseNormalMapValue()
    {

        material.SetFloat("_BumpScale", increasedNormalMapValue);

    }



    void Update()
    {

    }

}
