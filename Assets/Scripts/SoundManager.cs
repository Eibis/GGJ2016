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
}
