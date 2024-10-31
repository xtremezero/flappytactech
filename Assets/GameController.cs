
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject platform_prefab;
    public Transform platform_spawn_transform;

    public BirdyLogic player_birdy;

    public float platform_velocity_x = 0;
    public float platform_scale_precentage = 1;
    public List<GameObject> platforms_ahead;
    float platform_spawn_timer = 2;

    public Transform kill_y_up;
    public Transform kill_y_down;

    public Transform city_environment;

    public GameObject start_prompt;
    public RawImage player_icon;
    public RawImage cpu_icon;
    public Texture2D[] player_icons;
    public Texture2D[] cpu_icons;
    public Text score_ui;
    public float score = 0;

    float rotationSpeed = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Globals.Controller = this;
    }

    private void Start()
    {
        StartCoroutine(nameof(WaitAndHidePrompt));
    }
    IEnumerator WaitAndHidePrompt()
    {
        yield return new WaitUntil(() => { return Globals.game_started; });
        start_prompt.SetActive(false);
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        if (platform_prefab != null)
            if (platform_spawn_timer < 0)
            {
                platform_spawn_timer = 2; //reset timer
                Instantiate(platform_prefab, platform_spawn_transform);
            }


        UpdateVars();


        if (player_birdy.transform.position.y > kill_y_up.transform.position.y || player_birdy.transform.position.y < kill_y_down.transform.position.y)
        {
            player_birdy.onLose();

        }
    }

    void UpdateVars()
    {
        if (Globals.game_started)
        {
            platform_spawn_timer -= Time.deltaTime;
            platform_scale_precentage = Mathf.Lerp(platform_scale_precentage, 1.25f, Time.deltaTime * 0.01f);
            platform_velocity_x = Mathf.Lerp(platform_velocity_x, 1f, Time.deltaTime * 0.01f);


            // Calculate the rotation amount based on time and speed
            float rotationAmount = rotationSpeed * Time.deltaTime;

            // Get the current rotation of the skybox
            float currentRotation = RenderSettings.skybox.GetFloat("_Rotation");

            // Update the skybox rotation
            RenderSettings.skybox.SetFloat("_Rotation", currentRotation + rotationAmount);
            city_environment.Rotate(0, 1 * Time.deltaTime, 0);



        }

    }


    public void enableAI()
    {
        Globals.ai_controller = true;
        cpu_icon.texture = cpu_icons[1];
        player_icon.texture = player_icons[0];

    }

    public void disableAI()
    {
        Globals.ai_controller = false;
        cpu_icon.texture = cpu_icons[0];
        player_icon.texture = player_icons[1];
    }
    public void AddScore(int value)
    {

        score += value;
        score_ui.text = ((int)(MathF.Floor(score))).ToString();
    }

    public void Restart()
    {
        Globals.ai_controller = false;
        Globals.game_started = false;
        SceneManager.LoadScene(0);

    }

}

