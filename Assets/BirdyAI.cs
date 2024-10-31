using UnityEngine;

public class BirdyAI : MonoBehaviour
{
    float aciton_cooldown = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!Globals.ai_controller)
            return;
        aciton_cooldown -= Time.deltaTime;
        if (Globals.Controller.platforms_ahead.Count > 0 && Globals.Controller.platforms_ahead[0] != null )
        {
            if ( Globals.Controller.platforms_ahead[0].transform.position.y > Globals.Controller.player_birdy.transform.position.y + 0.35f)
            if (aciton_cooldown < 0)
            {
                aciton_cooldown = 0.5f; //difficulty controllere is here
                Globals.Controller.player_birdy.Hop();
            }
        }
        else if(Globals.Controller.player_birdy.transform.position.y < 0)
        {

            if (aciton_cooldown < 0)
            {
                aciton_cooldown = 0.2f;
                Globals.Controller.player_birdy.Hop();
            }
        }
    }
}
