using UnityEngine;
using System.Collections;

public class FlickeringLight : MonoBehaviour {

	public float 	timePassed = 0;
	public float 	flickerTime = 0.1f;
	public float 	timeBetween;
	public bool 	lightsOut = false;
	public float	intensity = 0.5f;
	public float	maxIntensity = 0.5f;
	public float	maxTimeBetween = 10f;
	public float	minTimeBetween = 5f;

	public float	shortTimePassed = 0;
	public float	shortFlickerTime = 0.1f;
	public float	maxTimeOff = 10f;
	public float	minTimeOff = 5f;
	public float	shortTimeBetween;
	public bool		shortFlicker = false;
	public float	lightRange;

	// Use this for initialization
	void Start () {
		timeBetween = Random.Range(minTimeBetween, maxTimeBetween);
		shortTimeBetween = Random.Range(minTimeOff, maxTimeOff);
	}
	
	// Update is called once per frame
	void Update () {

		GetComponent<Light>().intensity += (intensity - GetComponent<Light>().intensity) * Time.deltaTime * 8;

		timePassed += Time.deltaTime;
		if(timePassed > timeBetween && !lightsOut) {
			intensity = 0.1f;
			timePassed = 0;
			lightsOut = true;
		} else if(timePassed > flickerTime && lightsOut) {
			intensity = maxIntensity;
			timePassed = 0;
			lightsOut = false;
			minTimeBetween = Mathf.Max(minTimeBetween - 10 * Time.deltaTime, 1);
			maxTimeBetween = Mathf.Max(maxTimeBetween - 10 * Time.deltaTime, 2);
			flickerTime = Mathf.Min(flickerTime + Time.deltaTime/2, 1);
			maxIntensity = Mathf.Max (maxIntensity - Time.deltaTime/20, 0.2f);
			timeBetween = Random.Range(minTimeBetween, maxTimeBetween);
		}
		if(Time.time > 10) {
			shortTimePassed += Time.deltaTime;
			if(shortTimePassed > shortTimeBetween && !shortFlicker) {
				shortFlicker = true;
				lightRange = GetComponent<Light>().range;
				GetComponent<Light>().range = 0;
				shortTimePassed = 0;
			} else if(shortTimePassed > shortFlickerTime && shortFlicker) {
				shortFlicker = false;
				GetComponent<Light>().range = lightRange;
				shortTimePassed = 0;
				minTimeOff = Mathf.Max(minTimeOff - 10 * Time.deltaTime, 0);
				maxTimeOff = Mathf.Max(maxTimeOff - 10 * Time.deltaTime, 4);
				shortTimeBetween = Random.Range(minTimeOff, maxTimeOff);
			}
		}
	}
}
