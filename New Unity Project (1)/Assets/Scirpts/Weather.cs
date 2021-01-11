using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine.Experimental.Rendering.HDPipeline;
using UnityEngine;
public class Weather : MonoBehaviour
{

    public Weather_Holder holder;
   
    public float SwitchWeatherTimer = 0f;
    public float reaetWeatherTimer = 20f;

    public float AudioFadeTime = 0.25f;
    public AudioClip SunnyAudio;
    public AudioClip ThunderAudio;
    public AudioClip MistAudio;
    public AudioClip OverCastAudio;
    public AudioClip SnowAudio;

    public float lightDimTime = 0.1f;
    public float thuunderIntensoty = 0f;
    public float sunIntensoty = 1f;
    public float MistIntensoty = 0.5f;
    public float overcastIntensoty = 0.25f;
    public float SnowIntensoty = 0.75f;

    ProceduralSky sky;
    private float SunnySkySunSize = 0.026f;
    private float SunnySkySizeConvergence = 10f;
    private float SunnySkyAtmosphereThickness = 1.55f;
    private float SunnySkyExposure = 0.66f;
    private float SunnySkyMultiplier = 0.79f;

    private float ThunderSkySunSize = 0.0f;
    private float ThunderSkySizeConvergence = 3.23f;
    private float ThunderSkyAtmosphereThickness = 1.69f;
    private float ThunderSkyExposure = 0.8f;
    private float ThunderSkyMultiplier = 0.74f;

    private float MistSkySunSize = 0.013f;
    private float MistSkySizeConvergence = 4.79f;
    private float MistSkyAtmosphereThickness = 1.69f;
    private float MistSkyExposure = 0.99f;
    private float MistSkyMultiplier = 1.19f;

    private float OvercastSkySunSize = 0.0f;
    private float OvercastSkySizeConvergence = 1f;
    private float OvercastSkyAtmosphereThickness = 0.18f;
    private float OvercastSkyExposure = 2.15f;
    private float OvercastSkyMultiplier = 3.09f;

    private float SnowSkySunSize = 0.04f;
    private float SnowSkySizeConvergence = 5f;
    private float SnowSkyAtmosphereThickness = 0.45f;
    private float SnowSkyExposure = 0.92f;
    private float SnowSkyMultiplier = 1.05f;


    Exposure exposure;
    private float SunnyExposureFixedExposure = 0f;

    private float ThunderExposureFixedExposure = 2.47f;

    private float MistExposureFixedExposure = 1.01f;

    private float OvercastExposureFixedExposure = 0.36f;

    private float SnowExposureFixedExposure = 0.29f;

    ExponentialFog fog;
    private float SunnyFogDensity = 0.0f;
    private float SunnyFogDistance = 0f;
    private float SunnyFogBaseHeight = 0;
    private float SunnyFogMaxDistance = 0;
    private float SunnyFogMipFogFar = 0;

    private float ThunderFogDensity = 0.356f;
    private float ThunderFogDistance = 28f;
    private float ThunderFogBaseHeight = 419f;
    private float ThunderFogMaxDistance = 464f;
    private float ThunderFogMipFogFar = 427;

    private float MistFogDensity = 0.75f;
    private float MistFogDistance = 22f;
    private float MistFogBaseHeight = 270f;
    private float MistFogMaxDistance = 0f;
    private float MistFogMipFogFar = 1000f;

    private float OvercastFogDensity = 0.1f;
    private float OvercastFogDistance = 8.9f;
    private float OvercastFogBaseHeight = 25.5f;
    private float OvercastFogMaxDistance = 4749f;
    private float OvercastFogMipFogFar = 869f;

    private float SnowFogDensity = 0.07f;
    private float SnowFogDistance = 3.4f;
    private float SnowFogBaseHeight = 92f;
    private float SnowFogMaxDistance = 4336f;
    private float SnowFogMipFogFar = 859f;

    private float FogDensityDimTime =0.5f;
    public float Timer = 0.0f;
    private float time = 40.0f;

    public WeatherStates weatherStates;
    private int SwitchWeather;


    public enum WeatherStates
    {
        PickWeather,
        SunnyWeather,
        ThunderWeather,
        MistWeather,
        OvercastWeather,
        SnowWeather
    }

    private void Start()
    {
        holder.StopEffects();
        Volume volume = gameObject.GetComponent<Volume>();
        ProceduralSky Skytemp;
        Exposure exposuretTemp;
        ExponentialFog fogtemp;
        if ( volume.profile.TryGet<ProceduralSky>(out Skytemp))
        {
            sky = Skytemp;
        }
        if (volume.profile.TryGet<Exposure>(out exposuretTemp))
        {
            exposure = exposuretTemp;
        }

        if (volume.profile.TryGet<ExponentialFog>(out fogtemp))
        {
            fog = fogtemp;
        }

        holder.StopEffects();
        StartCoroutine("WeatherFSm");
      
    }


    private void Update()
    {
         SwitchWeatherTimerAction();

        Timer += Time.deltaTime;
    }

    void SwitchWeatherTimerAction()
    {
       // Debug.Log("SwitchWeatherTimerAction");


        SwitchWeatherTimer += Time.deltaTime;

        if(SwitchWeatherTimer > reaetWeatherTimer)
        {
            SwitchWeather = 0;
            
        }

        if (SwitchWeatherTimer < reaetWeatherTimer)
        {
            return;
        }

        if( SwitchWeatherTimer == reaetWeatherTimer)
        {
            weatherStates = Weather.WeatherStates.PickWeather;
            SwitchWeatherTimer = 0f;
            Debug.Log("PickWeather");
            return;
        }
         
        
    }

    IEnumerator WeatherFSm()
    {
        while (true)
        {
            SwitchWeather = Random.Range(0, 5);
            CancelInvoke();
            holder.StopEffects();
            switch (SwitchWeather)
            {
                case 0:
                    weatherStates = Weather.WeatherStates.SunnyWeather;
                    break;
                case 1:
                    weatherStates = Weather.WeatherStates.ThunderWeather;
                    break;
                case 2:
                    weatherStates = Weather.WeatherStates.MistWeather;
                    break;
                case 3:
                    weatherStates = Weather.WeatherStates.OvercastWeather;
                    break;
                case 4:
                    weatherStates = Weather.WeatherStates.SnowWeather;
                    break;
            }
            switch (weatherStates)
            {
                case WeatherStates.PickWeather:
                   PickWeather();
                    break;
                case WeatherStates.SunnyWeather:
                   // SunnyWeather();
                    Timer = 0f;
                    InvokeRepeating("SunnyWeather", 0.0f, 0.05f);
                    break;
                case WeatherStates.ThunderWeather:
                   // ThunderWeather();
                    Timer = 0f;
                    InvokeRepeating("ThunderWeather", 0.0f, 0.05f);
                    holder.Rain.Play();
                    break;
                case WeatherStates.MistWeather:
                   // MistWeather();
                    Timer = 0f;
                    InvokeRepeating("MistWeather", 0.0f, 0.05f);
                    break;
                case WeatherStates.OvercastWeather:
                  //  OvercastWeather();
                    Timer = 0f;
                    InvokeRepeating("OvercastWeather", 0.0f, 0.05f);
                    break;
                case WeatherStates.SnowWeather:
                  //  SnowWeather();
                    Timer = 0f;
                    InvokeRepeating("SnowWeather", 0.0f, 0.05f);
                    holder.Snow.Play();
                    break;
            }

           

            yield return new WaitForSeconds(60);
        }
    }

    void PickWeather()
    {
        holder.StopEffects();
        SwitchWeather = Random.Range(0, 5);      
    }

    void SunnyWeather()
    {
        // SunCloundsParticleSysterm.Play();
       // Debug.Log("SunnyWeather");
       
        if (sky.sunSize.value != SunnySkySunSize)
        {
            sky.sunSize.value = (Mathf.Lerp(sky.sunSize.value, SunnySkySunSize, time));


        }
        if (sky.sunSizeConvergence != SunnySkySizeConvergence)
        {
            sky.sunSizeConvergence.value = (Mathf.Lerp(sky.sunSizeConvergence.value, SunnySkySizeConvergence, time));
        }
        if (sky.atmosphereThickness != SunnySkyAtmosphereThickness)
        {
            sky.atmosphereThickness.value = (Mathf.Lerp(sky.atmosphereThickness.value, SunnySkyAtmosphereThickness, time));
        }
        if (sky.exposure != SunnySkyExposure)
        {
            sky.exposure.value = (Mathf.Lerp(sky.exposure.value, SunnySkyExposure, time));
        }
        if (sky.multiplier != SunnySkyMultiplier)
        {
            sky.multiplier.value = (Mathf.Lerp(sky.multiplier.value, SunnySkyMultiplier, time));
        }
        // exposure 
        if (exposure.fixedExposure != SunnyExposureFixedExposure)
        {
            exposure.fixedExposure.value = (Mathf.Lerp(exposure.fixedExposure.value, SunnyExposureFixedExposure, time));
        }
        //fog
        if (fog.density != SunnyFogDensity)
        {
            fog.density.value = (Mathf.Lerp(fog.density.value, SunnyFogDensity, Timer / time));
        }
        if (fog.fogDistance != SunnyFogDistance)
        {
            fog.fogDistance.value = (Mathf.Lerp(fog.fogDistance.value, SunnyFogDistance, time));
        }
        if (fog.fogBaseHeight != SunnyFogBaseHeight)
        {
            fog.fogBaseHeight.value = (Mathf.Lerp(fog.fogBaseHeight.value, SunnyFogBaseHeight, time));
        }
        if (fog.maxFogDistance != SunnyFogMaxDistance)
        {
            fog.maxFogDistance.value = (Mathf.Lerp(fog.maxFogDistance.value, SunnyFogMaxDistance, time));
        }
        if (fog.mipFogFar != SunnyFogMipFogFar)
        {
            fog.mipFogFar.value = (Mathf.Lerp(fog.mipFogFar.value, SunnyFogMipFogFar, time));
        }
    }

    void ThunderWeather()
    {
        //ThunderStormParticleSysterm.Play();
       // Debug.Log("ThunderWeather");
        if (sky.sunSize.value != ThunderSkySunSize)
        {
            sky.sunSize.value = (Mathf.Lerp(sky.sunSize.value, ThunderSkySunSize, Timer / 20f));
        }
        if (sky.sunSizeConvergence != ThunderSkySizeConvergence)
        {
            sky.sunSizeConvergence.value = (Mathf.Lerp(sky.sunSizeConvergence.value, ThunderSkySizeConvergence, Timer / 20f));
        }
        if (sky.atmosphereThickness != ThunderSkyAtmosphereThickness)
        {
            sky.atmosphereThickness.value = (Mathf.Lerp(sky.atmosphereThickness.value, ThunderSkyAtmosphereThickness, Timer / 20f));
        }
        if (sky.exposure != ThunderSkyExposure)
        {
            sky.exposure.value = (Mathf.Lerp(sky.exposure.value, ThunderSkyExposure, Timer / 20f));
        }
        if (sky.multiplier != ThunderSkyMultiplier)
        {
            sky.multiplier.value = (Mathf.Lerp(sky.multiplier.value, ThunderSkyMultiplier, Timer / 20f));
        }
        // exposure 
        if (exposure.fixedExposure != ThunderExposureFixedExposure)
        {
            exposure.fixedExposure.value = (Mathf.Lerp(exposure.fixedExposure.value, ThunderExposureFixedExposure, Timer / 20f));
        }
        //fog
        if (fog.density != ThunderFogDensity)
        {
            fog.density.value = (Mathf.Lerp(fog.density.value, ThunderFogDensity, Timer / 20f));
        }
        if (fog.fogDistance != ThunderFogDistance)
        {
            fog.fogDistance.value = (Mathf.Lerp(fog.fogDistance.value, ThunderFogDistance, Timer / 20f));
        }
        if (fog.fogBaseHeight != ThunderFogBaseHeight)
        {
            fog.fogBaseHeight.value = (Mathf.Lerp(fog.fogBaseHeight.value, ThunderFogBaseHeight, Timer / 20f));
        }
        if (fog.maxFogDistance != ThunderFogMaxDistance)
        {
            fog.maxFogDistance.value = (Mathf.Lerp(fog.maxFogDistance.value, ThunderFogMaxDistance, Timer / 20f));
        }
        if (fog.mipFogFar != ThunderFogMipFogFar)
        {
            fog.mipFogFar.value = (Mathf.Lerp(fog.mipFogFar.value, ThunderFogMipFogFar, Timer / 20f));
        }
    }

    void MistWeather()
    {
        //  MistParticleSysterm.Play();
       // Debug.Log("MistWeather");
        // sky 
        

        if (sky.sunSize != MistSkySunSize)
        {
            sky.sunSize.value = (Mathf.Lerp(sky.sunSize.value, MistSkySunSize, Timer / 20f));
        }
        if (sky.sunSizeConvergence != MistSkySizeConvergence)
        {
            sky.sunSizeConvergence.value = (Mathf.Lerp(sky.sunSizeConvergence.value, MistSkySizeConvergence, Timer / 20f));
        }
        if (sky.exposure != MistSkyExposure)
        {
            sky.atmosphereThickness.value = (Mathf.Lerp(sky.atmosphereThickness.value, MistSkyAtmosphereThickness, Timer / 20f));
        }
        if (sky.exposure != MistSkyExposure)
        {
            sky.exposure.value = (Mathf.Lerp(sky.exposure.value, MistSkyExposure, Timer / 20f));
        }
        if (sky.multiplier != MistSkyMultiplier)
        {
            sky.multiplier.value = (Mathf.Lerp(sky.multiplier.value, MistSkyMultiplier, Timer / 20f));
        }
        // exposure 
        if (exposure.fixedExposure != MistExposureFixedExposure)
        {
            exposure.fixedExposure.value = (Mathf.Lerp(exposure.fixedExposure.value, MistExposureFixedExposure, Timer / 20f));
        }
        //fog
        if (fog.density != MistFogDensity)
        {
            fog.density.value = (Mathf.Lerp(fog.density.value, MistFogDensity, Timer / 20f));
        }
        if (fog.fogDistance != MistFogDistance)
        {
            fog.fogDistance.value = (Mathf.Lerp(fog.fogDistance.value, MistFogDistance, Timer / 20f));
        }
        if (fog.fogBaseHeight != MistFogBaseHeight)
        {
            fog.fogBaseHeight.value = (Mathf.Lerp(fog.fogBaseHeight.value, MistFogBaseHeight, Timer / 20f));
        }
        if (fog.maxFogDistance != MistFogMaxDistance)
        {
            fog.maxFogDistance.value = (Mathf.Lerp(fog.maxFogDistance.value, MistFogMaxDistance, Timer / 20f));
        }
        if (fog.mipFogFar != MistFogMipFogFar)
        {
            fog.mipFogFar.value = (Mathf.Lerp(fog.mipFogFar.value, MistFogMipFogFar, Timer / 20f));
        }
    }

    void OvercastWeather()
    {
        //OverCatParticleSysterm.Play();
       // Debug.Log("OvercastWeather");
        // sky 
        if (sky.sunSize.value != OvercastSkySunSize)
        {
            sky.sunSize.value = (Mathf.Lerp(sky.sunSize.value, OvercastSkySunSize, Timer / 20f));
        }
        if (sky.sunSizeConvergence != OvercastSkySizeConvergence)
        {
            sky.sunSizeConvergence.value = (Mathf.Lerp(sky.sunSizeConvergence.value, OvercastSkySizeConvergence, Timer / 20f));
        }
        if (sky.atmosphereThickness != OvercastSkyAtmosphereThickness)
        {
            sky.atmosphereThickness.value = (Mathf.Lerp(sky.atmosphereThickness.value, OvercastSkyAtmosphereThickness, Timer / 20f));
        }
        if (sky.exposure != OvercastSkyExposure)
        {
            sky.exposure.value = (Mathf.Lerp(sky.exposure.value, OvercastSkyExposure, Timer / 20f));
        }
        if (sky.multiplier != OvercastSkyMultiplier)
        {
            sky.multiplier.value = (Mathf.Lerp(sky.multiplier.value, OvercastSkyMultiplier, Timer / 20f));
        }
        // exposure 
        if (exposure.fixedExposure != OvercastExposureFixedExposure)
        {
            exposure.fixedExposure.value = (Mathf.Lerp(exposure.fixedExposure.value, OvercastExposureFixedExposure, Timer / 20f));
        }
        //fog
        if (fog.density != OvercastFogDensity)
        {
            fog.density.value = (Mathf.Lerp(fog.density.value, OvercastFogDensity, Timer / 20f));
        }
        if (fog.fogDistance != OvercastFogDistance)
        {
            fog.fogDistance.value = (Mathf.Lerp(fog.fogDistance.value, OvercastFogDistance, Timer / 20f));
        }
        if (fog.fogBaseHeight != OvercastFogBaseHeight)
        {
            fog.fogBaseHeight.value = (Mathf.Lerp(fog.fogBaseHeight.value, OvercastFogBaseHeight, Timer / 20f));
        }
        if (fog.maxFogDistance != OvercastFogMaxDistance)
        {
            fog.maxFogDistance.value = (Mathf.Lerp(fog.maxFogDistance.value, OvercastFogMaxDistance, Timer / 20f));
        }
        if (fog.mipFogFar != OvercastFogMipFogFar)
        {
            fog.mipFogFar.value = (Mathf.Lerp(fog.mipFogFar.value, OvercastFogMipFogFar, Timer / 20f));
        }
    }

    void SnowWeather()
    {
        //  SnowParticleSysterm.Play();
       // Debug.Log("SnowWeather");
        // sky 
        if (sky.sunSize.value != SnowSkySunSize)
        {
            sky.sunSize.value = (Mathf.Lerp(sky.sunSize.value, SnowSkySunSize, Timer / 20f));
        }
        if (sky.sunSizeConvergence != SnowSkySizeConvergence)
        {
            sky.sunSizeConvergence.value = (Mathf.Lerp(sky.sunSizeConvergence.value, SnowSkySizeConvergence, Timer / 20f));
        }
        if (sky.atmosphereThickness != SnowSkyAtmosphereThickness)
        {
            sky.atmosphereThickness.value = (Mathf.Lerp(sky.atmosphereThickness.value, SnowSkyAtmosphereThickness, Timer / 20f));
        }
        if (sky.exposure != SnowSkyExposure)
        {
            sky.exposure.value = (Mathf.Lerp(sky.exposure.value, SnowSkyExposure, Timer / 20f));
        }
        if (sky.multiplier != SnowSkyMultiplier)
        {
            sky.multiplier.value = (Mathf.Lerp(sky.multiplier.value, SnowSkyMultiplier, Timer / 20f));
        }
        // exposure 
        if (exposure.fixedExposure != SnowExposureFixedExposure)
        {
            exposure.fixedExposure.value = (Mathf.Lerp(exposure.fixedExposure.value, SnowExposureFixedExposure, Timer / 20f));
        }
        //fog
        if (fog.density != SnowFogDensity)
        {
            fog.density.value = (Mathf.Lerp(fog.density.value, SnowFogDensity, Timer / 20f));
        }
        if (fog.fogDistance != SnowFogDistance)
        {
            fog.fogDistance.value = (Mathf.Lerp(fog.fogDistance.value, SnowFogDistance, Timer / 20f));
        }
        if (fog.fogBaseHeight != SnowFogBaseHeight)
        {
            fog.fogBaseHeight.value = (Mathf.Lerp(fog.fogBaseHeight.value, SnowFogBaseHeight, Timer / 20f));
        }
        if (fog.maxFogDistance != SnowFogMaxDistance)
        {
            fog.maxFogDistance.value = (Mathf.Lerp(fog.maxFogDistance.value, SnowFogMaxDistance, Timer / 20f));
        }
        if (fog.mipFogFar != SnowFogMipFogFar)
        {
            fog.mipFogFar.value = (Mathf.Lerp(fog.mipFogFar.value, SnowFogMipFogFar, Timer / 20f));
        }
    }

}
