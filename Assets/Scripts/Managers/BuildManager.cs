using NUnit.Framework;
using UnityEngine;

public class BuildManager : MonoBehaviour, IInteractable
{
    public AudioSource _speaker;
    private AudioClip _wrong;
    public void Start()
    {
        _wrong = SoundManager.sm.GetClip(SoundManager.AudioClips.WrongSound);
    }
    public virtual void Interact()
    {
        if(GameManager.gm.Sombrium >= 2)
        {
            GameManager.gm.Sombrium -= 2;
            BaseManager.bm.levelUpBuilding(transform);
        }
        else
        {
            _speaker.PlayOneShot(_wrong);
        }
    }
}
