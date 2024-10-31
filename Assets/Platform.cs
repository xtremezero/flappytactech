using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour
{
    float destruction_time = 12;
    float default_speed =3;    
    float max_speed = 10;    
    float current_speed = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        Globals.Controller.platforms_ahead.Add(gameObject);
        transform.position += transform.up*(Random.Range(-2.5f, 2.5f));
        foreach (Transform t in transform)
            t.localScale=(transform.up * Globals.Controller.platform_scale_precentage)+new Vector3(1,0,1);

        yield return new WaitForSeconds(destruction_time);

        if (Globals.game_started)
        {
            if (Globals.Controller.platforms_ahead.Contains(gameObject))
                Globals.Controller.platforms_ahead.Remove(gameObject);
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!Globals.game_started)
            return;


        current_speed = Mathf.Lerp(current_speed, Mathf.Lerp(default_speed, max_speed, Globals.Controller.platform_velocity_x), Time.deltaTime);
        transform.position += Vector3.left * current_speed *Time.deltaTime;

        if (transform.position.x < 0)
            if (Globals.Controller.platforms_ahead.Contains(gameObject))
            {
                Globals.Controller.platforms_ahead.Remove(gameObject);
                Globals.Controller.AddScore(1);
            }
    }
}
