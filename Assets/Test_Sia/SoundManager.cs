using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("🔊 오디오 소스")]
    public AudioSource bgmSource;  // 배경음 오디오
    public AudioSource sfxSource;  // 효과음 오디오

    [Header("🎛 볼륨 슬라이더")]
    public Slider masterSlider;
    public Slider bgmSlider;
    public Slider sfxSlider;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // 씬 변경 시 유지
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        // 🔄 저장된 볼륨 값 불러오기
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
        bgmSlider.value = PlayerPrefs.GetFloat("BGMVolume", 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);

        ApplyVolume(); // 🔊 초기 볼륨 적용

        // 🎚 슬라이더 값 변경 시 볼륨 업데이트
        masterSlider.onValueChanged.AddListener(delegate { SetMasterVolume(masterSlider.value); });
        bgmSlider.onValueChanged.AddListener(delegate { SetBGMVolume(bgmSlider.value); });
        sfxSlider.onValueChanged.AddListener(delegate { SetSFXVolume(sfxSlider.value); });
    }

    public void SetMasterVolume(float volume)
    {
        AudioListener.volume = volume;  // 모든 오디오에 적용
        PlayerPrefs.SetFloat("MasterVolume", volume);
        PlayerPrefs.Save();
    }

    public void SetBGMVolume(float volume)
    {
        bgmSource.volume = volume;
        PlayerPrefs.SetFloat("BGMVolume", volume);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
        PlayerPrefs.SetFloat("SFXVolume", volume);
        PlayerPrefs.Save();
    }

    private void ApplyVolume()
    {
        AudioListener.volume = masterSlider.value;
        bgmSource.volume = bgmSlider.value;
        sfxSource.volume = sfxSlider.value;
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
}
