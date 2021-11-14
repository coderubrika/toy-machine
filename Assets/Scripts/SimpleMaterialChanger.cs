using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class SimpleMaterialChanger : MonoBehaviour
    {
        [SerializeField]
        private MeshRenderer meshRenderer;

        [SerializeField]
        private Material changedMaterial;

        private Material originalMaterial;

        private void Awake()
        {
            originalMaterial = meshRenderer.material;
        }

        public void SetupMaterial()
        {
            meshRenderer.material = changedMaterial;
        }

        public void RevertMaterial()
        {
            meshRenderer.material = originalMaterial;
        }
    }
}