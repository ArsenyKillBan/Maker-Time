using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class CursorLock : MonoBehaviour
 {
        void Start()
        {
            LockCursor();
        }

        void Update()
        {
            
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

            
            if (Input.GetKeyDown(KeyCode.Z))
            {
                LockCursor();
            }
        }

        void LockCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

