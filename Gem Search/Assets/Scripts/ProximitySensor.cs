using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProximitySensor : MonoBehaviour
{
    public Transform Player;
    public Transform Target;
    public float MaxSignalStrength = 100.0f;
    public float MinSignalStrength = 1.0f;

    public TMP_Text DistanceTxt;
    public TMP_Text SignalStrengthTxt;
    public TMP_Text PointingTowardsTxt;
    public TMP_Text AdjustedSignalTxt;
    public TMP_Text NeedleAngleTxt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (Player.position - Target.position).magnitude;
        DistanceTxt.text = "Distance: " + distance.ToString();

        float signalStrength = MaxSignalStrength / ((distance * distance) + 0.9f);
        signalStrength = Mathf.Min(signalStrength, MaxSignalStrength);
        SignalStrengthTxt.text = "Signal Strength: " + signalStrength.ToString();

        Vector3 playerToTarget = (Target.position - Player.position).normalized;
        float pointingTowards = Vector3.Dot(playerToTarget, Player.forward);
        pointingTowards = Mathf.Max(pointingTowards, 0.0f);
        PointingTowardsTxt.text = "Pointing Towards: " + pointingTowards.ToString();

        float adjustedSignalStrength = signalStrength * pointingTowards;
        AdjustedSignalTxt.text = "Adjusted Signal: " + adjustedSignalStrength.ToString();

        CalculateNeedleAngle(adjustedSignalStrength);
    }

    private void CalculateNeedleAngle(float adjustedSignalStrength)
    {
        float proportion = (adjustedSignalStrength - MinSignalStrength) /
                           (MaxSignalStrength - MinSignalStrength);
        proportion = Mathf.Clamp(proportion, 0, 1);

        float needleAngle = 180.0f * proportion;
        NeedleAngleTxt.text = "Needle Angle: " + needleAngle;
    }
}
