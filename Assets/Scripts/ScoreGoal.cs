using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGoal : MonoBehaviour
{
    public Transform TheBall;
    public Transform BallResetPoint;

    public Text blueGoals;
    private int blueGoalsNum = 0;
    public Text RedGoals;
    private int redGoalsNum = 0;

    void Start()
    {
    }

    void OnCollisionEnter(Collision collision)
    {

        //if ball is scored on blue do a reset
        if (collision.gameObject.name == "GoalBlue")
        {
            blueGoalsNum++;
            blueGoals.text = blueGoalsNum.ToString();
            TheBall.position = BallResetPoint.position;
        }

        //if ball is scored on red do a reset
        if (collision.gameObject.name == "GoalRed")
        {
            redGoalsNum++;
            RedGoals.text = redGoalsNum.ToString();
            TheBall.position = BallResetPoint.position;
        }
    }
}
