/*
	This code is adapted from the TwistReceiver of 
	ros-sharp . It is basically a copy/paste 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneTwistSubscriber : RosSharp.RosBridgeClient.Subscriber<RosSharp.RosBridgeClient.Messages.Geometry.Twist>
{

    public DroneController controller;

    private float previousRealTime;
    private Vector3 linearVelocity;
    private Vector3 angularVelocity;
    private bool isMessageReceived;

    protected override void Start()
    {
        base.Start();
    }

    protected override void ReceiveMessage(RosSharp.RosBridgeClient.Messages.Geometry.Twist message)
    {
        linearVelocity = RosSharp.TransformExtensions.Ros2Unity(ToVector3(message.linear));
        angularVelocity = -RosSharp.TransformExtensions.Ros2Unity(ToVector3(message.angular));
        isMessageReceived = true;
    }

    private static Vector3 ToVector3(RosSharp.RosBridgeClient.Messages.Geometry.Vector3 geometryVector3)
    {
        return new Vector3(geometryVector3.x, geometryVector3.y, geometryVector3.z);
    }

    private void Update()
    {
        if (isMessageReceived)
            ProcessMessage();
    }
    private void ProcessMessage()
    {
        controller.UpdateVelocities(linearVelocity, angularVelocity);

        previousRealTime = Time.realtimeSinceStartup;

        isMessageReceived = false;
    }
}