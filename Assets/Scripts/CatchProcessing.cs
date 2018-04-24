using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchProcessing : MonoBehaviour {

    public SpriteRenderer FishImage;
    public Text FishName;
    public Text FishDescription;
    public AudioSource FishSpeaker;

    public AudioClip[] FishSounds;
    public string[] FishNames;
    public string[] FishDescriptions;
    public Sprite[] FishSprites;

    public int CountDown = 120;

    Dictionary<string, string> DescriptionDictionary = new Dictionary<string, string>();
    Dictionary<string, Sprite> FishImageDictionary = new Dictionary<string, Sprite>();
    Dictionary<string, AudioClip> AudioDictionary = new Dictionary<string, AudioClip>();



	// Use this for initialization
	void Start () {
		for(int i = 0; i < FishNames.Length; i++)
        {
            DescriptionDictionary.Add(FishNames[i], FishDescriptions[i]);
            FishImageDictionary.Add(FishNames[i], FishSprites[i]);
            AudioDictionary.Add(FishNames[i], FishSounds[i]);
        }
        string CaughtFish = CatchOfTheDay.Instance.CaughtFish;
        FishImage.sprite = FishImageDictionary[CaughtFish];
        FishDescription.text = DescriptionDictionary[CaughtFish];
        FishSpeaker.clip = AudioDictionary[CaughtFish];
        FishName.text = CaughtFish;
	}
	



}
