using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class HoverBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    private AudioClip hoverSound;
    private AudioClip clickSound;
    private float lastPlayTime;
    private float lastClickTime;
    void Start()
    {
        hoverSound = SoundManager.sm.GetClip(SoundManager.AudioClips.HoverButton);
        clickSound = SoundManager.sm.GetClip(SoundManager.AudioClips.PressButton);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverSound != null && Time.time - lastPlayTime > 0.2f)
        {
            GameManager.gm.PlayGlobalSFX(hoverSound);
            lastPlayTime = Time.time;
        } 
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (clickSound != null && Time.time - lastClickTime > 0.2f)
        {
            GameManager.gm.PlayGlobalSFX(clickSound);
            lastClickTime = Time.time;
        }
    }
}
