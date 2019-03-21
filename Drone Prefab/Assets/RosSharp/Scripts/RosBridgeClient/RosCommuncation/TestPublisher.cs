/*
© Siemens AG, 2017-2018
Author: Dr. Martin Bischoff (martin.bischoff@siemens.com)

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at
<http://www.apache.org/licenses/LICENSE-2.0>.
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class TestPublisher : Publisher<Messages.Geometry.PoseStamped>
    {        
        private Vector3 initialPosition;
        public Transform publishedTransform; 
        private Messages.Geometry.PoseStamped message;       
        protected override void Start()
        {
            base.Start();
            InitializeMessage();
            initialPosition = publishedTransform.position;
        }

        private void FixedUpdate()
        {
            UpdateMessage();
        }
        
        private void InitializeMessage()
        {
            message = new Messages.Geometry.PoseStamped();
            message.pose.position = new Messages.Geometry.Point();
            message.pose.orientation = new Messages.Geometry.Quaternion();
            message.header.frame_id = "map";
        }
        private void UpdateMessage()
        {
            Vector3 position = publishedTransform.position - initialPosition;
            Quaternion orientation = publishedTransform.rotation;
            //Debug.Log(position); 
            message.pose.position = GetGeometryPoint(position.Unity2Ros());
            message.pose.orientation = GetGeometryQuaternion(orientation.Unity2Ros());

            Publish(message);
        }

        private static Messages.Geometry.Point GetGeometryPoint(Vector3 vector3)
        {
            Messages.Geometry.Point geometryPoint = new Messages.Geometry.Point();
            geometryPoint.x = vector3.x;
            geometryPoint.y = vector3.y;
            geometryPoint.z = vector3.z;
            return geometryPoint;
        }

		private static Messages.Geometry.Quaternion GetGeometryQuaternion(Quaternion quaternion)
        {
            Messages.Geometry.Quaternion geometryQuaternion = new Messages.Geometry.Quaternion();
            geometryQuaternion.w = quaternion.w;
            geometryQuaternion.x = quaternion.x;
			geometryQuaternion.y = quaternion.y;
			geometryQuaternion.z = quaternion.z;			
            return geometryQuaternion;
        }
    }
}
