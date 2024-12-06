using UnityEngine;

namespace aRPG
{
    public class ClickableObject : MonoBehaviour, IClickableObject
    {
        public void Click()
        {
            Debug.Log(name);
        }
    }
}