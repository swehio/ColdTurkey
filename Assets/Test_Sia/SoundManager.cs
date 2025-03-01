using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("🔊 오디오 소스")]
    [SerializeField] private AudioSource bgmSource;  // 배경음
    [SerializeField] private AudioSource sfxSource;  // 효과음

    [Header("🎛 볼륨 슬라이더")]
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;

    [Header("📊 볼륨 값 표시 텍스트")]
    [SerializeField] private TMP_Text masterValueText;
    [SerializeField] private TMP_Text bgmValueText;
    [SerializeField] private TMP_Text sfxValueText;

    private float masterVolume = 1f;
    private float bgmVolume = 1f;
    private float sfxVolume = 1f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        // 저장된 볼륨 값 불러오기
        masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        bgmVolume = PlayerPrefs.GetFloat("BGMVolume", 1f);
        sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);

        // 슬라이더 값 반영
        masterSlider.value = masterVolume;
        bgmSlider.value = bgmVolume;
        sfxSlider.value = sfxVolume;

        // 볼륨 설정 적용
        ApplyVolume();
        UpdateVolumeTexts();

        // 슬라이더 값 변경 시 볼륨 업데이트
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    private void ApplyVolume()
    {
        // 마스터 볼륨은 전체 볼륨 조절
        AudioListener.volume = masterVolume;

        // BGM과 SFX 볼륨을 개별적으로 조절 (마스터 볼륨과 곱하여 적용)
        bgmSource.volume = bgmVolume * masterVolume;
        sfxSource.volume = sfxVolume * masterVolume;

    }

    public void SetMasterVolume(float volume)
    {
        masterVolume = volume;
        PlayerPrefs.SetFloat("MasterVolume", volume);
        PlayerPrefs.Save();
        ApplyVolume();  // 즉시 볼륨 적용
        UpdateVolumeTexts(); // 볼륨 변경 시 숫자도 업데이트
    }

    public void SetBGMVolume(float volume)
    {
        bgmVolume = volume;
        PlayerPrefs.SetFloat("BGMVolume", volume);
        PlayerPrefs.Save();
        ApplyVolume();
        UpdateVolumeTexts();


    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        PlayerPrefs.SetFloat("SFXVolume", volume);
        PlayerPrefs.Save();
        ApplyVolume();
        UpdateVolumeTexts();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            //sfxSource.PlayOneShot(clip);
            sfxSource.clip = clip;
            sfxSource.Play();  //Play()는 즉시 재생됨
        }
    }
    // 📊 볼륨 값을 숫자로 변환하여 UI 업데이트
    private void UpdateVolumeTexts()
    {
        masterValueText.text = Mathf.RoundToInt(masterVolume * 100).ToString();
        bgmValueText.text = Mathf.RoundToInt(bgmVolume * 100).ToString();
        sfxValueText.text = Mathf.RoundToInt(sfxVolume * 100).ToString();
    }
}
