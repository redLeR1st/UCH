using UnityEngine;

using UnityEngine.SceneManagement;

[System.Serializable]
public class Sound
{

	public string name;
	public AudioClip clip;

	[Range(0f, 1f)]
	public float volume = 0.7f;
	[Range(0.5f, 1.5f)]
	public float pitch = 1f;

	[Range(0f, 0.5f)]
	public float randomVolume = 0.1f;
	[Range(0f, 0.5f)]
	public float randomPitch = 0.1f;

	public bool loop;

	private AudioSource source;

	public void SetSource(AudioSource _source)
	{
		source = _source;
		source.clip = clip;
	}
	public AudioSource GetSource()
	{
		return source;
	}

	public void Play()
	{
		source.volume = volume * (1 + Random.Range(-randomVolume / 2, randomVolume / 2));
		source.pitch = pitch * (1 + Random.Range(-randomPitch / 2, randomPitch / 2));
		source.loop = loop;
		source.Play();
	}

	public void Stop()
	{
		source.Stop();
	}

}

public class AudioManager : MonoBehaviour
{

	private bool isMusicPlaying = false;

	public static AudioManager instance;

	[SerializeField]
	Sound[] sounds;


	void Update()
	{
		if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Menu") && !isMusicPlaying)
		{
			PlaySound("Music");
			print("IGEEEN");
			isMusicPlaying = true;
		}
		
		if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Menu") && isMusicPlaying)
		{
			StopSound("Music");
			print("NEEEEEM");
			isMusicPlaying = false;
		}
	}


	void Awake()
	{

		
		/*if (instance != null)
		{
			if (instance != this)
			{
				Destroy(this.gameObject);
			}
		}
		else
		{*/
			instance = this;
			DontDestroyOnLoad(this);
		/*}*/
	}

	void Start()
	{
		for (int i = 0; i < sounds.Length; i++)
		{
			GameObject _go = new GameObject("Sound" + i + "_" + sounds[i].name);
			_go.transform.SetParent(this.transform);
			sounds[i].SetSource(_go.AddComponent<AudioSource>());
		}

		//

		//PlaySound ("Explosion");
	}

	public void PlaySoundOfButtonClick()
	{
		PlaySound("Click");
	}


	public void PlaySound(string _name, float speed, float volume)
	{
		for (int i = 0; i < sounds.Length; i++)
		{
			if (sounds[i].name == _name)
			{
				if (!sounds[i].GetSource().isPlaying)
				{
					//print("ez meghívódik");
					sounds[i].pitch = speed;
					sounds[i].volume = volume;
					sounds[i].Play();
					return;
				}
			}
		}

		// no sound With _name
		Debug.LogWarning("AudioManager: Sound not found in list: " + _name);
	}

	public void PlaySound(string _name)
	{
		for (int i = 0; i < sounds.Length; i++)
		{
			if (sounds[i].name == _name)
			{
				if (!sounds[i].GetSource().isPlaying)
				{
					sounds[i].Play();
					return;
				}
			}
		}

		// no sound With _name
		Debug.LogWarning("AudioManager: Sound not found in list: " + _name);
	}

	public void StopSound(string _name)
	{
		for (int i = 0; i < sounds.Length; i++)
		{
			if (sounds[i].name == _name)
			{
				sounds[i].Stop();
				return;
			}
		}

		// no sound With _name
		Debug.LogWarning("AudioManager: Sound not found in list: " + _name);
	}
}
