using UnityEngine;

[System.Serializable]
public class Sound
{
	public AudioClip clip;
	public string soundID;
}
public class SoundManager : MonoBehaviour
{
	public static SoundManager Instance;
	[SerializeField] private Sound[] gameSounds;
	[SerializeField] private AudioSource defaultAudioSource;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public AudioClip GetAudioClipFromID(string id)
	{
		for (int i = 0; i < gameSounds.Length; i++)
		{
			var sound = gameSounds[i];
			if (sound.soundID == id)
			{
				return sound.clip;
			}
		}

		Debug.LogError($"Clip with id {id} not found");
		return default;
	}
	
	public void PlayClipFromID(string id)
	{
		AudioClip clipToPlay = GetAudioClipFromID(id);
		if (clipToPlay == default)
		{
			return;			
		}

		defaultAudioSource.PlayOneShot(clipToPlay);
	}

}
