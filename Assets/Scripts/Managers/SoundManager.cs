using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public enum AudioClips
    {
        MainMenuAmbience,
        BaseAmbience,
        BattleAmbience,
        StartGame,
        HoverButton,
        PressButton,
        WrongSound,
        HarvesterFinished,
        HarvesterEmptied,
        EnemyHurt,
        EnemyStun,
        EnemyShoot,
        Punch,
        Step,
        PlayerStunned
    }
    [System.Serializable]
    public struct AudioEntry
    {
        public AudioClips type;
        public AudioClip clip;
    }
    [SerializeField] private List<AudioEntry> _clips = new List<AudioEntry>();
    private Dictionary<AudioClips, AudioClip> _audioDictionary = new Dictionary<AudioClips, AudioClip>();
    public static SoundManager sm;
    private void Awake()
    {
        if (sm != null && sm != this)
        {
            Destroy(this.gameObject);
            return;
        }
        sm = this;
        DontDestroyOnLoad(gameObject);
        BuildDictionary();
    }
    private void BuildDictionary()
    {
        foreach (var entry in _clips)
        {
            if (entry.clip == null)
            {
                Debug.LogWarning($"AudioEntry for {entry.type} has no clip assigned.");
                continue;
            }
            if (!_audioDictionary.TryAdd(entry.type, entry.clip))
                Debug.LogWarning($"Duplicate entry for {entry.type} — skipping.");
        }
    }
    public AudioClip GetClip(AudioClips type)
    {
        if (_audioDictionary.TryGetValue(type, out var clip)) return clip;
        Debug.LogWarning($"Clip not found: {type}");
        return null;
    }
}
