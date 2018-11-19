using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralStuff : MonoBehaviour
{
    public int chunkAmount = 100;
    public Transform chunk;
    public Transform crate;
    public Transform gap;
    public Transform spikes;


    private Transform lastChunk;
    private Transform baseChunk;
    private int lastRoll = 0;

	void Start ()
    {
        baseChunk = Instantiate(chunk, new Vector3(0, 0, 0), Quaternion.identity);
        lastChunk = baseChunk;

        Vector3 posIncrement;

        for (int numOfSpawnedChunks = 0; numOfSpawnedChunks < chunkAmount - 1; numOfSpawnedChunks++)
        {
            // 7 sided dice lolololo
            int dice = Random.Range(1, 8);

            posIncrement = new Vector3(Random.Range(1, 5), Random.Range(0, 0), 0);  

            lastChunk = Instantiate(chunk, lastChunk.position += posIncrement, Quaternion.identity);

            if (dice == 1)
            {
                Instantiate(gap, lastChunk.position + new Vector3(0f, 1.7071f, 0f), Quaternion.identity);
            }
            else if (dice == 2 && lastRoll != 2)
            {
                Instantiate(spikes, lastChunk.position + new Vector3(0f, 0.06907f, 0f), Quaternion.identity);
            }
            else if (dice > 6 && dice < 8)
            {
                int cratePosId = Random.Range(1, 3);

                if (cratePosId == 1)
                {
                    Instantiate(crate, lastChunk.position + new Vector3(0f, 0.29907f, 0f), Quaternion.identity);
                }
                else
                {
                    Instantiate(crate, lastChunk.position + new Vector3(0f, 1.35f, 0f), Quaternion.identity);
                }
            }

            lastRoll = dice;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
