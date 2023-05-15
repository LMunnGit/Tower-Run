using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChange : MonoBehaviour
{
[SerializeField] private SpriteRenderer rend;
[SerializeField] private PlatformSpawner spawner;
[SerializeField] private Sprite[] Background;

[SerializeField] private float transitionDuration;

void Start()
{
    rend.sprite = Background[0];
    Color color1 = rend.color;
    color1.a = 1f;
}
void Update()
{
    if (spawner.chunkHeight == spawner.stoneChunkStart + 3)
    {
        StartCoroutine("BGChange");
    }
}

IEnumerator BGChange()
{
    float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime / transitionDuration;

            // Fade in the next sprite
            Color color2 = rend.color;
            color2.a = Mathf.Lerp(0.33f, 1f, t);
            rend.sprite = Background[1];
            rend.color = color2;

            yield return null;
        }
}

}
