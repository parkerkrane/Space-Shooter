using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectLifetime : MonoBehaviour
{
    public float lifeTime;
    public float blinkingDelay;
    public UnityEvent OnTimerReachedZero;
    private float timer;

    void Start()
    {
        timer = lifeTime;

        StartCoroutine(ObjectTimer());
    }

    
    void Update()
    {
        if (timer <= 0)
        {
            OnTimerReachedZero?.Invoke();
        }

        timer -= Time.deltaTime;
    }

    private IEnumerator ObjectTimer()
    {
        Color defaultColor = GetComponent<SpriteRenderer>().color;
        Color blinkColor = defaultColor;
        blinkColor.a = 0.5f;

        yield return new WaitForSeconds(lifeTime * 0.7f);

        while (timer > 0)
        {
            GetComponent<SpriteRenderer>().color = blinkColor;
            yield return new WaitForSeconds(blinkingDelay);
            GetComponent<SpriteRenderer>().color = defaultColor;
            yield return new WaitForSeconds(blinkingDelay);
        }
    }
}
