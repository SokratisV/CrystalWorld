using UnityEngine;

public class MuteSounds : MonoBehaviour {

    private bool muted = false;

    public void Mute()
    {
        if (muted)
        {
            GetComponent<AudioSource>().volume = .5f;
        }
        else
        {
            GetComponent<AudioSource>().volume = 0f;
        }
        muted = !muted;
    }
}
