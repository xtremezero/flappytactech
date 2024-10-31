using UnityEngine;

public class BirdyPlayer : MonoBehaviour
{
    float aciton_cooldown = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    public void Jump()
    {

        if (enabled && !Globals.ai_controller )
        {
            Globals.Controller.player_birdy.Hop();
            Globals.Controller.disableAI();
        }
    }
}
