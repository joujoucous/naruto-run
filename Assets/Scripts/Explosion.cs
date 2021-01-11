using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    Mesh mesh;
    [SerializeField] bool m_Display_normals = false;
    AudioSource boum;
    public Vector3 center_;
    public float radius_;
    Vector3[] verts;
    private bool touched = false;

    public void push_vertex(Vector3 center, float radius, GameObject other)
    {
        Vector3 caving = new Vector3(0, 0.1f, 0);
        verts = mesh.vertices;
        // InverseTransformPoint to go from World to Local
        // TransformPoint to go from local to World;
        for (int index = 0; index < verts.Length; index++)
        {
            
            float distance = Vector3.Distance(center, other.transform.TransformPoint(verts[index]));
            while(distance < radius)
            {
                verts[index] -= caving;
                distance = Vector3.Distance(center, other.transform.TransformPoint(verts[index]));
            }

        }
        mesh.vertices = verts;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh.RecalculateTangents();
        other.GetComponent<MeshCollider>().sharedMesh = null;
        other.GetComponent<MeshCollider>().sharedMesh = mesh;
        //Destroy(gameObject);
    }

    void OnDrawGizmos()
    {
        if (!m_Display_normals)
            return;
        Gizmos.DrawWireSphere(center_, radius_);
        if (mesh == null)
            return;
        Vector3[] vertices = mesh.vertices;
        Vector3[] normals = mesh.normals;

        Gizmos.color = Color.green;

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 pt = transform.TransformPoint(vertices[i]);
            Gizmos.DrawLine(pt, pt + transform.TransformDirection(normals[i]));
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Terrain")
        {

            Explode();
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius_);
            for (int i = 0; i < hitColliders.Length; ++i)
            {
                if(hitColliders[i].tag == "Terrain")
                {
                    
                    mesh = hitColliders[i].transform.GetComponent<MeshFilter>().mesh;
                    push_vertex(transform.position, radius_, hitColliders[i].gameObject);
                    //Explode();
                    Destroy(gameObject, 1);
                }
            }            
        }
        
    }
    public void Explode()
    {
        boum = GetComponent<AudioSource>();
        boum.Play(0);
        ParticleSystem expl = this.GetComponentInChildren<ParticleSystem>();
        expl.Play();
        this.GetComponent<FlyToPlayer>().enabled = false;

    }
}
