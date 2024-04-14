using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController1 : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 dir;
    // Start is called before the first frame update
    [SerializeField] private int speed;

    private int lineToMove = 1;
    public float lineDistanse = 4;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dir.z = speed;
        characterController.Move(Time.fixedDeltaTime * dir);
    }

    private void Update()
    {
        if (New_Move.swipeRight)
        {
            if (lineToMove < 2)
                lineToMove++;
        }

        if (New_Move.swipeLeft)
        { 
            if (lineToMove > 0)
                lineToMove--;
        }

        Vector3 targetPositoin = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (lineToMove == 0)
            targetPositoin += Vector3.left * lineDistanse;
        else if (lineToMove == 2)
            targetPositoin += Vector3.right * lineDistanse;

        transform.position = targetPositoin;
    }
}
