using UnityEngine;

public class FlyDirection : MonoBehaviour
{
    Vector3 PreviousPosition, CurrentPosition;
    void Start()
    {
        CurrentPosition = transform.position;
        PreviousPosition = CurrentPosition;
    }

    // Update is called once per frame
    void Update()
    {

        if (Globals.game_started)
        {
            PreviousPosition = CurrentPosition;
            CurrentPosition = transform.position;
        }

        var delta_position = (CurrentPosition.y - PreviousPosition.y);
        if (delta_position > 0.0001f)
        {

            transform.rotation = Quaternion.Euler(0, 0,4*Mathf.Lerp(-Mathf.PI / 2, Mathf.PI / 2, delta_position / Time.deltaTime));
        }
    }
}
