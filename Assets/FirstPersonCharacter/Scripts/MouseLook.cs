using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.FirstPerson
{
    [Serializable]
    public class MouseLook
    {
        public float XSensitivity = 2f;
        public float YSensitivity = 2f;
        public bool clampVerticalRotation = true;
        public float MinimumX = -90F;
        public float MaximumX = 90F;
        public bool smooth;
        public float smoothTime = 1f;


        private Quaternion m_CharacterTargetRot;
        private Quaternion m_CameraTargetRot;


        public void Init(Transform character, Transform camera)
        {
            m_CharacterTargetRot = character.localRotation;
            m_CameraTargetRot = camera.localRotation;
        }

        float yRotation = 0f;
        public Vector3 dir, forwardV;
        public void LookRotation(Transform character, Transform camera)
        {
            float yRot = CrossPlatformInputManager.GetAxis("Mouse X") * XSensitivity;
            float xRot = CrossPlatformInputManager.GetAxis("Mouse Y") * YSensitivity;

            yRotation += yRot;

            //dir = Physics.gravity.normalized;
            //float angle = Mathf.Atan2(dir.y, dir.x);
            //angle += Mathf.PI / 2;
            //float x = Mathf.Cos(angle);
            //float y = Mathf.Sin(angle);
            //forwardV = new Vector3(x, y, dir.z);
            //
            //var r = Quaternion.LookRotation(forwardV, -dir);
            ////r.SetLookRotation(r * Vector3.up, -dir);
            //r.eulerAngles = new Vector3(r.eulerAngles.x, yRotation, r.eulerAngles.z);
            //yRotation = r.eulerAngles.y;
            //m_CharacterTargetRot = r;

            m_CharacterTargetRot = TestRots.RotateWithUp(-Physics.gravity.normalized, yRotation);

            //m_CharacterTargetRot = character.localRotation;
            //m_CharacterTargetRot *= Quaternion.Euler (0, yRot, 0);
            m_CameraTargetRot *= Quaternion.Euler (-xRot, 0f, 0f);

            if(clampVerticalRotation)
                m_CameraTargetRot = ClampRotationAroundXAxis (m_CameraTargetRot);

            if(smooth)
            {
                character.localRotation = Quaternion.Slerp (character.localRotation, m_CharacterTargetRot,
                    smoothTime * Time.deltaTime);
                //Debug.Log("smooth: " + (smoothTime * Time.deltaTime));
                camera.localRotation = Quaternion.Slerp (camera.localRotation, m_CameraTargetRot,
                    smoothTime * Time.deltaTime);
            }
            else
            {
                character.localRotation = m_CharacterTargetRot;
                camera.localRotation = m_CameraTargetRot;
            }
        }


        Quaternion ClampRotationAroundXAxis(Quaternion q)
        {
            q.x /= q.w;
            q.y /= q.w;
            q.z /= q.w;
            q.w = 1.0f;

            float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan (q.x);

            angleX = Mathf.Clamp (angleX, MinimumX, MaximumX);

            q.x = Mathf.Tan (0.5f * Mathf.Deg2Rad * angleX);

            return q;
        }

    }
}
