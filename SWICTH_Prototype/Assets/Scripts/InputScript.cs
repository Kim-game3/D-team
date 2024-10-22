using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputKey
{
    public class InputScript
    {
        public static bool on_rotation;
        public static bool IsDecision;
        // Start is called before the first frame update
        void Start()
        {
            on_rotation = false;//Ç±ÇÍÇ™trueÇÃä‘ÇÕï ÇÃâÒì]ÇÃÉLÅ[ÇâüÇµÇƒÇ‡îΩâûÇµÇ»Ç¢
            IsDecision = false;
        }

        // Update is called once per frame
        static bool isCheck_Input;
        static bool preventContinuityInput;

        static float buttonDownTime;
        static float timer;

        /// <summary>
        /// Simultaneous input prohibited
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool SingleInputKeyDown(KeyCode key)
        {
            if (Input.anyKeyDown == false) isCheck_Input = false;

            if (isCheck_Input == false)
            {
                if (Input.GetKeyDown(key))
                {
                    isCheck_Input = true;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Continuity input prohibited
        /// </summary>
        /// <param name="key"></param>
        /// <param name="intervalSeconds"></param>
        /// <returns></returns>
        public static bool Interval_InputKeydown(KeyCode key, float intervalSeconds)
        {
            timer = Time.time;

            if (Input.GetKeyDown(key) && timer - buttonDownTime >= intervalSeconds)
            {
                if (preventContinuityInput == false)
                {
                    preventContinuityInput = true;
                    buttonDownTime = Time.time;
                    return true;
                }
                else if (preventContinuityInput)
                {
                    preventContinuityInput = false;
                    buttonDownTime = Time.time;
                    return true;
                }
            }

            return false;
        }
    }
}
