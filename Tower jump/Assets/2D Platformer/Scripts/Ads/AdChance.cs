using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdChance : MonoBehaviour
{
[SerializeField] InterstitialAdsButton interstitialAdsButton;
[SerializeField] float chance;

public void AdCheck()
{
float rand = Random.value;
if (rand < chance)
{
    interstitialAdsButton.ShowAd(); // Show ad
}
}
}
