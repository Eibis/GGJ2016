using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public AudioClip sfx_codata;
    public AudioClip sfx_colpo;
    public AudioClip sfx_fuoco;
    public AudioClip sfx_impatto;
    public AudioClip sfx_menu;
    public AudioClip sfx_morte;
    public AudioClip sfx_passo;
    public AudioClip sfx_presa_oggetto_corretta;
    public AudioClip sfx_salto;

    public AudioClip into_demoniaco;
    public AudioClip loop_demoniaco;
    public AudioClip intro_ghiaccio;
    public AudioClip loop_ghiaccio;
    public AudioClip loop_stanza;

    public AudioSource source;
    public AudioSource source_ost;

    private static SoundManager _this;

    public void Start()
    {
        _this = this;
    }

    public static void PlayCodata()
    {
        if (_this.source.isPlaying)
            return;

        _this.source.PlayOneShot(_this.sfx_codata);
    }
    public static void PlayColpo()
    {
        if (_this.source.isPlaying)
            return;

        _this.source.PlayOneShot(_this.sfx_colpo);
    }
    public static void PlayFuoco()
    {
        if (_this.source.isPlaying)
            return;

        _this.source.PlayOneShot(_this.sfx_fuoco);
    }
    public static void PlayImpatto()
    {
        if (_this.source.isPlaying)
            return;

        _this.source.PlayOneShot(_this.sfx_impatto);
    }
    public static void PlayMenu()
    {
        if (_this.source.isPlaying)
            return;

        _this.source.PlayOneShot(_this.sfx_menu);
    }
    public static void PlayMorte()
    {
        if (_this.source.isPlaying)
            return;

        _this.source.PlayOneShot(_this.sfx_morte);
    }
    public static void PlayOggetto()
    {
        if (_this.source.isPlaying)
            return;

        _this.source.PlayOneShot(_this.sfx_presa_oggetto_corretta);
    }
    public static void PlaySalto()
    {
        if (_this.source.isPlaying)
            return;

        _this.source.PlayOneShot(_this.sfx_salto);
    }
    public static void PlayPasso()
    {
        if (_this.source.isPlaying)
            return;

        _this.source.PlayOneShot(_this.sfx_passo);
    }
    public static void PlayStanza()
    {
        _this.StopAllCoroutines();

        _this.source_ost.Stop();

        _this.source_ost.clip=_this.loop_stanza;

        _this.source_ost.Play();

        _this.source_ost.loop = true;
    }
    public static void PlayGhiaccio()
    {

        _this.source_ost.clip = _this.loop_ghiaccio;

        _this.source_ost.Play();

        _this.source_ost.loop = true;


    }
    public static void PlayDemonio()
    {
            
        _this.source_ost.clip = _this.loop_demoniaco;
        
        _this.source_ost.Play();

        _this.source_ost.loop = true;

    }

    IEnumerator Play_next(int flag)
    {
        while(_this.source_ost.isPlaying)
        {
            yield return null;

        }

        if (flag == 0)
            PlayDemonio();
        else if (flag == 1)
            PlayGhiaccio();
        
    }

    public static void PlayIntroDemoniaco()
    {
        _this.StopAllCoroutines();

        _this.source_ost.Stop();

        _this.source_ost.PlayOneShot(_this.into_demoniaco);

        _this.StartCoroutine(_this.Play_next(0));

    }

    public static void PlayIntroGhiaccio()
    {
        _this.StopAllCoroutines();

        _this.source_ost.Stop();

        _this.source_ost.PlayOneShot(_this.intro_ghiaccio);

        _this.StartCoroutine(_this.Play_next(0));

    }
}
