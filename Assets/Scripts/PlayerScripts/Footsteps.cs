using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioClip[] woodClips;
    public AudioClip[] grassClips;
    public AudioClip[] sandClips;
    public AudioClip[] concreteClips;
    //public AudioClip[] jumpClips;
    //public AudioClip[] climbClips;
    //public AudioClip[] fallClips;

    private AudioSource audioSource;
    private TerrainDetector terrainDetector;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        terrainDetector = new TerrainDetector();
    }

    private void Step()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomClip()
    {
        int terrainTextureIndex = terrainDetector.GetActiveTerrainTextureIdx(transform.position);

        switch (terrainTextureIndex)
        {
            case 0:
                return concreteClips[Random.Range(0, concreteClips.Length)];
            case 1:
                return sandClips[Random.Range(0, sandClips.Length)];
            case 2:
                return grassClips[Random.Range(0, grassClips.Length)];
            default:
                return concreteClips[Random.Range(0, concreteClips.Length)];
        }
    }
}
