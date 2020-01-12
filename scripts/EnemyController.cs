using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public string directionMove;
    [SerializeField] List<Transform> transforms;
    Transform fromTransform;
    Transform toTransform;
    int V;
    [SerializeField] Dictionary<Transform, List<Transform>> goToTransforms = new Dictionary<Transform, List<Transform>>();
    void Start()
    {
        V = 66;
        //------------Initializing the dictionary----------------------
        List<Transform> temp = new List<Transform>();

        temp.Add(transforms[1]);temp.Add(transforms[6]);//0
        goToTransforms.Add(transforms[0], temp.ToList());
        temp.Clear();

        temp.Add(transforms[0]); temp.Add(transforms[2]); temp.Add(transforms[7]);//1
        goToTransforms.Add(transforms[1], temp.ToList());
        temp.Clear();

        temp.Add(transforms[8]); temp.Add(transforms[1]);//2
        goToTransforms.Add(transforms[2], temp.ToList());
        temp.Clear();

        temp.Add(transforms[9]); temp.Add(transforms[4]);//3
        goToTransforms.Add(transforms[3], temp.ToList());
        temp.Clear();

        temp.Add(transforms[3]); temp.Add(transforms[5]); temp.Add(transforms[10]);//4
        goToTransforms.Add(transforms[4], temp.ToList());
        temp.Clear();

        temp.Add(transforms[4]); temp.Add(transforms[11]);//5
        goToTransforms.Add(transforms[5], temp.ToList());
        temp.Clear();

        temp.Add(transforms[0]); temp.Add(transforms[12]); temp.Add(transforms[7]);//6
        goToTransforms.Add(transforms[6], temp.ToList());
        temp.Clear();

        temp.Add(transforms[6]); temp.Add(transforms[1]); temp.Add(transforms[14]); temp.Add(transforms[13]);
        goToTransforms.Add(transforms[7], temp.ToList());
        temp.Clear();

        temp.Add(transforms[14]); temp.Add(transforms[2]); temp.Add(transforms[9]);
        goToTransforms.Add(transforms[8], temp.ToList());
        temp.Clear();

        temp.Add(transforms[8]); temp.Add(transforms[3]); temp.Add(transforms[19]);
        goToTransforms.Add(transforms[9], temp.ToList());
        temp.Clear();

        temp.Add(transforms[4]); temp.Add(transforms[11]); temp.Add(transforms[19]); temp.Add(transforms[20]);
        goToTransforms.Add(transforms[10], temp.ToList());
        temp.Clear();

        temp.Add(transforms[5]); temp.Add(transforms[10]); temp.Add(transforms[21]);
        goToTransforms.Add(transforms[11], temp.ToList());
        temp.Clear();

        temp.Add(transforms[6]); temp.Add(transforms[13]);
        goToTransforms.Add(transforms[12], temp.ToList());
        temp.Clear();

        temp.Add(transforms[7]); temp.Add(transforms[12]); temp.Add(transforms[27]);
        goToTransforms.Add(transforms[13], temp.ToList());
        temp.Clear();

        temp.Add(transforms[15]); temp.Add(transforms[7]); temp.Add(transforms[8]);
        goToTransforms.Add(transforms[14], temp.ToList());
        temp.Clear();

        temp.Add(transforms[14]); temp.Add(transforms[16]);
        goToTransforms.Add(transforms[15], temp.ToList());
        temp.Clear();

        temp.Add(transforms[23]); temp.Add(transforms[15]);
        goToTransforms.Add(transforms[16], temp.ToList());
        temp.Clear();

        temp.Add(transforms[25]); temp.Add(transforms[18]);
        goToTransforms.Add(transforms[17], temp.ToList());
        temp.Clear();

        temp.Add(transforms[19]); temp.Add(transforms[17]);
        goToTransforms.Add(transforms[18], temp.ToList());
        temp.Clear();

        temp.Add(transforms[18]); temp.Add(transforms[9]); temp.Add(transforms[10]);
        goToTransforms.Add(transforms[19], temp.ToList());
        temp.Clear();

        temp.Add(transforms[10]); temp.Add(transforms[31]); temp.Add(transforms[21]);
        goToTransforms.Add(transforms[20], temp.ToList());
        temp.Clear();

        temp.Add(transforms[11]); temp.Add(transforms[20]);
        goToTransforms.Add(transforms[21], temp.ToList());
        temp.Clear();

        temp.Add(transforms[23]); temp.Add(transforms[28]);
        goToTransforms.Add(transforms[22], temp.ToList());
        temp.Clear();

        temp.Add(transforms[22]); temp.Add(transforms[16]); temp.Add(transforms[25]);
        goToTransforms.Add(transforms[23], temp.ToList());
        temp.Clear();

        temp.Add(transforms[23]); temp.Add(transforms[25]);
        goToTransforms.Add(transforms[24], temp.ToList());
        temp.Clear();

        temp.Add(transforms[23]); temp.Add(transforms[17]); temp.Add(transforms[26]);
        goToTransforms.Add(transforms[25], temp.ToList());
        temp.Clear();

        temp.Add(transforms[25]); temp.Add(transforms[30]);
        goToTransforms.Add(transforms[26], temp.ToList());
        temp.Clear();

        temp.Add(transforms[13]); temp.Add(transforms[35]); temp.Add(transforms[28]);
        goToTransforms.Add(transforms[27], temp.ToList());
        temp.Clear();

        temp.Add(transforms[27]); temp.Add(transforms[22]); temp.Add(transforms[32]);
        goToTransforms.Add(transforms[28], temp.ToList());
        temp.Clear();

        temp.Add(transforms[24]);
        goToTransforms.Add(transforms[29], temp.ToList());
        temp.Clear();

        temp.Add(transforms[26]); temp.Add(transforms[31]); temp.Add(transforms[33]);
        goToTransforms.Add(transforms[30], temp.ToList());
        temp.Clear();

        temp.Add(transforms[20]); temp.Add(transforms[30]); temp.Add(transforms[40]);
        goToTransforms.Add(transforms[31], temp.ToList());
        temp.Clear();

        temp.Add(transforms[33]); temp.Add(transforms[36]); temp.Add(transforms[28]);
        goToTransforms.Add(transforms[32], temp.ToList());
        temp.Clear();

        temp.Add(transforms[32]); temp.Add(transforms[30]); temp.Add(transforms[39]);
        goToTransforms.Add(transforms[33], temp.ToList());
        temp.Clear();

        temp.Add(transforms[35]); temp.Add(transforms[42]);
        goToTransforms.Add(transforms[34], temp.ToList());
        temp.Clear();

        temp.Add(transforms[34]); temp.Add(transforms[27]); temp.Add(transforms[36]); temp.Add(transforms[44]);
        goToTransforms.Add(transforms[35], temp.ToList());
        temp.Clear();

        temp.Add(transforms[32]); temp.Add(transforms[35]); temp.Add(transforms[37]);
        goToTransforms.Add(transforms[36], temp.ToList());
        temp.Clear();

        temp.Add(transforms[36]); temp.Add(transforms[46]); 
        goToTransforms.Add(transforms[37], temp.ToList());
        temp.Clear();

        temp.Add(transforms[47]); temp.Add(transforms[39]);
        goToTransforms.Add(transforms[38], temp.ToList());
        temp.Clear();

        temp.Add(transforms[38]); temp.Add(transforms[40]); temp.Add(transforms[33]);
        goToTransforms.Add(transforms[39], temp.ToList());
        temp.Clear();

        temp.Add(transforms[39]); temp.Add(transforms[41]); temp.Add(transforms[31]); temp.Add(transforms[49]);
        goToTransforms.Add(transforms[40], temp.ToList());
        temp.Clear();

        temp.Add(transforms[40]); temp.Add(transforms[51]);
        goToTransforms.Add(transforms[41], temp.ToList());
        temp.Clear();

        temp.Add(transforms[34]); temp.Add(transforms[43]);
        goToTransforms.Add(transforms[42], temp.ToList());
        temp.Clear();

        temp.Add(transforms[42]); temp.Add(transforms[53]);
        goToTransforms.Add(transforms[43], temp.ToList());
        temp.Clear();

        temp.Add(transforms[45]); temp.Add(transforms[35]); temp.Add(transforms[54]);
        goToTransforms.Add(transforms[44], temp.ToList());
        temp.Clear();

        temp.Add(transforms[44]); temp.Add(transforms[46]); temp.Add(transforms[55]);
        goToTransforms.Add(transforms[45], temp.ToList());
        temp.Clear();

        temp.Add(transforms[45]); temp.Add(transforms[47]); temp.Add(transforms[37]);
        goToTransforms.Add(transforms[46], temp.ToList());
        temp.Clear();

        temp.Add(transforms[46]); temp.Add(transforms[48]); temp.Add(transforms[38]);
        goToTransforms.Add(transforms[47], temp.ToList());
        temp.Clear();

        temp.Add(transforms[47]); temp.Add(transforms[49]); temp.Add(transforms[58]);
        goToTransforms.Add(transforms[48], temp.ToList());
        temp.Clear();

        temp.Add(transforms[48]); temp.Add(transforms[59]); temp.Add(transforms[40]);
        goToTransforms.Add(transforms[49], temp.ToList());
        temp.Clear();

        temp.Add(transforms[51]); temp.Add(transforms[60]); 
        goToTransforms.Add(transforms[50], temp.ToList());
        temp.Clear();

        temp.Add(transforms[41]); temp.Add(transforms[50]);
        goToTransforms.Add(transforms[51], temp.ToList());
        temp.Clear();

        temp.Add(transforms[53]); temp.Add(transforms[62]);
        goToTransforms.Add(transforms[52], temp.ToList());
        temp.Clear();

        temp.Add(transforms[52]); temp.Add(transforms[54]); temp.Add(transforms[43]);
        goToTransforms.Add(transforms[53], temp.ToList());
        temp.Clear();

        temp.Add(transforms[53]); temp.Add(transforms[44]); 
        goToTransforms.Add(transforms[54], temp.ToList());
        temp.Clear();

        temp.Add(transforms[56]); temp.Add(transforms[45]);
        goToTransforms.Add(transforms[55], temp.ToList());
        temp.Clear();

        temp.Add(transforms[55]); temp.Add(transforms[63]);
        goToTransforms.Add(transforms[56], temp.ToList());
        temp.Clear();

        temp.Add(transforms[58]); temp.Add(transforms[64]);
        goToTransforms.Add(transforms[57], temp.ToList());
        temp.Clear();

        temp.Add(transforms[57]); temp.Add(transforms[48]);
        goToTransforms.Add(transforms[58], temp.ToList());
        temp.Clear();

        temp.Add(transforms[60]); temp.Add(transforms[49]);
        goToTransforms.Add(transforms[59], temp.ToList());
        temp.Clear();

        temp.Add(transforms[59]); temp.Add(transforms[61]); temp.Add(transforms[50]);
        goToTransforms.Add(transforms[60], temp.ToList());
        temp.Clear();

        temp.Add(transforms[60]); temp.Add(transforms[65]);
        goToTransforms.Add(transforms[61], temp.ToList());
        temp.Clear();

        temp.Add(transforms[63]); temp.Add(transforms[52]);
        goToTransforms.Add(transforms[62], temp.ToList());
        temp.Clear();

        temp.Add(transforms[62]); temp.Add(transforms[64]); temp.Add(transforms[56]);
        goToTransforms.Add(transforms[63], temp.ToList());
        temp.Clear();

        temp.Add(transforms[63]); temp.Add(transforms[65]); temp.Add(transforms[57]);
        goToTransforms.Add(transforms[64], temp.ToList());
        temp.Clear();

        temp.Add(transforms[64]); temp.Add(transforms[61]);
        goToTransforms.Add(transforms[65], temp.ToList());
        temp.Clear();

    //  --------------------initialization over----------------------

        transform.position = transforms[0].position;
        fromTransform = transforms[0];
        toTransform = goToTransforms[fromTransform][Random.Range(0, goToTransforms[fromTransform].Count)];
        //toTransform = transforms[1];
    }

    // Update is called once per frame
    void Update()
    {
        GameObject playerObject = GameObject.Find("Player");
        if(transform.position != toTransform.position && !playerObject.GetComponent<Player>().isDead)
        {
            transform.position = Vector2.MoveTowards(transform.position, toTransform.position,Time.deltaTime * 3.5f);
        }
        else if(transform.position == toTransform.position && !playerObject.GetComponent<Player>().isDead)
        {
            fromTransform = toTransform;
            toTransform = goToTransforms[fromTransform][Random.Range(0,goToTransforms[fromTransform].Count)];
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<Player>().isDead = true;
        }

    }
}
