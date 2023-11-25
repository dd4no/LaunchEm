using UnityEngine;

public static class SoundManager
{
    public enum Sound
    {
        EnemyRise,
        EnemyFire,
        EnemyEscape,
        EnemyDestroyed,
        AltEnemyDestroyed,
        PowerupMoving,
        PowerupDestroyed,
        MissedShot
    }

   public static void PlaySound(Sound sound, float volume)
   {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(GetAudioClip(sound), volume);
   }

    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.Instance.soundAudioClipArray)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }
        return null;
    }
}
