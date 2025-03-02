using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("🔊 오디오 소스")]
    [SerializeField] private AudioSource bgmSource;  // 배경음
    [SerializeField] private AudioSource sfxSource;  // 효과음

    [Header("🎶 BGM Clips")]
    public AudioClip titleBGM;  // 타이틀 씬 BGM
    public AudioClip introBGM;  // 인트로 씬 BGM
    public AudioClip menuBGM;   // 메뉴 씬 BGM

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
            Debug.Log("SoundManager 생성됨");
        }
        else
        {
            Debug.Log("기존 SoundManager가 존재, 삭제됨");
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
        if (masterSlider != null) masterSlider.value = masterVolume;
        if (bgmSlider != null) bgmSlider.value = bgmVolume;
        if (sfxSlider != null) sfxSlider.value = sfxVolume;

        // 볼륨 설정 적용
        ApplyVolume();
        UpdateVolumeTexts();  // ✅ 텍스트 초기화 보장

        // 🎛 슬라이더 값 변경 이벤트 추가 (실시간 반영)
        if (masterSlider != null) masterSlider.onValueChanged.AddListener(SetMasterVolume);
        if (bgmSlider != null) bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        if (sfxSlider != null) sfxSlider.onValueChanged.AddListener(SetSFXVolume);

        // 씬 변경 시 BGM을 설정하도록 설정
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"씬 로드됨: {scene.name}");
        ChangeBGM(scene.name);
    }

    public void ChangeBGM(string sceneName)
    {
        AudioClip newBGM = null;

        switch (sceneName)
        {
            case "1_YSA_MainTitle":
                newBGM = titleBGM;
                break;
            case "2_YSA_Intro":
                newBGM = introBGM;
                break;
            case "3_YSA_MenuPopup":
                newBGM = menuBGM;
                break;
            default:
                Debug.LogWarning("해당 씬에 맞는 BGM이 없음.");
                break;
        }

        if (newBGM != null)
        {
            if (bgmSource.clip != newBGM)
            {
                Debug.Log($"BGM 변경: {sceneName} -> {newBGM.name}");
                bgmSource.clip = newBGM;
                bgmSource.Play();
            }
            else
            {
                Debug.Log("BGM 변경 없음 (이미 같은 BGM)");
            }
        }
        else
        {
            Debug.LogWarning($"해당 씬({sceneName})에 맞는 BGM이 없음!");
        }
    }

    private void ApplyVolume()
    {
        AudioListener.volume = masterVolume;
        if (bgmSource != null) bgmSource.volume = bgmVolume * masterVolume;
        if (sfxSource != null) sfxSource.volume = sfxVolume * masterVolume;
    }

    public void SetMasterVolume(float volume)
    {
        masterVolume = volume;
        PlayerPrefs.SetFloat("MasterVolume", volume);
        PlayerPrefs.Save();
        ApplyVolume();
        UpdateVolumeTexts();
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
            sfxSource.clip = clip;
            sfxSource.Play();
        }
    }

    // 📊 볼륨 값을 숫자로 변환하여 UI 업데이트
    private void UpdateVolumeTexts()
    {
        if (masterValueText != null)
            masterValueText.text = Mathf.RoundToInt(masterVolume * 100).ToString();

        if (bgmValueText != null)
            bgmValueText.text = Mathf.RoundToInt(bgmVolume * 100).ToString();

        if (sfxValueText != null)
            sfxValueText.text = Mathf.RoundToInt(sfxVolume * 100).ToString();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
