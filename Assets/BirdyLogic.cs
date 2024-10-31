using UnityEngine;

public class BirdyLogic : MonoBehaviour
{

    float gravity = 0;
    float hop_velocity = 5f;
    float velocity_y = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
    }
    void Start() {

        Globals.Controller.player_birdy = this;

    }
   
    // Update is called once per frame
    void Update()
    {
        transform.position += velocity_y * Vector3.up * Time.deltaTime;
        velocity_y += gravity * Time.deltaTime;
    }

    public void Hop()
    {
        Globals.game_started = true;
        velocity_y = hop_velocity;
        gravity = -15;
    }

    public void OnTriggerEnter(Collider other)
    {
        onLose();

    }
    public void onLose()
    {
        gameObject.SetActive(false);
        Globals.game_started = false;   

    }
}
