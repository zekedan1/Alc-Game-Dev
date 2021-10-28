using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Ling;
public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public int curHP;
    public int maxHP;
    public int scoreToGive;

    [Header("Movement")]
    public float moveSpeed;
    public float attackRange;
    public float yPathOffset;

    private List<Vector3> path;

    private Weapon weapon;
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        //Gather the Components
        weapon = GetCompents<Weapon>();
        target = FindObjectOfType<PlayerController>().GameObject;

        InvokeRepeating("UpdatePath", 0.0f, 0.5f);
    }

    void UpdatePath ()
    {
        NavMeshPath navMeshPath = new NavMeshPath();
        NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, navMeshPath);

        path = navMesh.corners.ToList();
    }
    void ChaseTargett()
    {
        if(path.Count == 0)
            return;


        //Move towards ghe closest path
        trasnform.positon = Vector3.MoveTowards(transform.position, path[0] + new Vector3(0, yPathOffset, 0, moveSpeed * Time.deltaTime));

        if(transform.position == path[0] + new Vector3(0, yPathOffset, 0))
            path.RemoveAt(0);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
