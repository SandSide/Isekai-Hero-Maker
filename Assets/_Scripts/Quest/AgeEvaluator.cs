using UnityEngine;

public class AgeEvaluator
{
    public static int Evaluate(int requested, int recieved) => Mathf.Abs(requested - recieved) switch 
    {
        <= 0 => 10,
        <= 5 => 5,
        <= 10 => 0,
        <= 15 => -5,
        _ => -10,
    };
}