namespace CabinetMan.Player.Debug
{
    using UnityEngine;

    public class DebugGizmos : MonoBehaviour
    {
        [Header("Ground Check Gizmo:")]
        public Vector3 groundCheckOffset;
        public float groundCheckRadius;
        public bool enableGroundCheckGizmo;

        private void OnDrawGizmosSelected()
        {
            if (enableGroundCheckGizmo)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(transform.position - groundCheckOffset, groundCheckRadius);
            }
        }
    }
}
