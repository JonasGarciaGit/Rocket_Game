using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManipulateTextMeshPro : MonoBehaviour
{

    public TMP_Text textComponent;


    void Update()
    {
        textComponent.ForceMeshUpdate();
        var textInfo = textComponent.textInfo;

        for(int i = 0; i < textInfo.characterCount; ++i){
            var charInfo = textInfo.characterInfo[i];

            if(!charInfo.isVisible){
                continue;
            }

            var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

            for(int j = 0; j < 4; ++j){
                var originalPosition = verts[charInfo.vertexIndex + j];
                verts[charInfo.vertexIndex + j] = originalPosition + new Vector3(0, Mathf.Sin(Time.time*4f + originalPosition.x * 0.01f) * 10f, 0);
            }
        }

        for(int i = 0; i < textInfo.meshInfo.Length; ++i){
            var meshInfo = textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;
            textComponent.UpdateGeometry(meshInfo.mesh, i);
        }


    }
}
