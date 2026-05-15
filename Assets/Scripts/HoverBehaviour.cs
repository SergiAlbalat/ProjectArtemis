using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class HoverBehaviour : MonoBehaviour
{
    private AudioClip hoverSound;
    void Awake()
    {
        hoverSound = SoundManager.sm.GetClip(SoundManager.AudioClips.HoverButton);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverSound != null)
        {

        }
            
    }
}
