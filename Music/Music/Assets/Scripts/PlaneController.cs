﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlaneController : MonoBehaviour {

	public bool keepPlaying = true;
	public static int blockNumPerChannel = 20;
	public Queue<GameObject>[] blocksInPool = new Queue<GameObject>[4], blocksInChannel = new Queue<GameObject>[4];
	public GameObject prefabBlock;
	public GameObject[] blockClone;

	private Vector3[] startingPoints = new Vector3[4], endingPoints = new Vector3[4];
	private float endingPointLocalMin = 0; 
	private int[] speed = new int[]{4, 4, 4, 4};

	void Awake() {
		blockClone = new GameObject[4 * blockNumPerChannel];
		Random.seed = 42;
		calculatePosition ();
		initiateBlocks (blockNumPerChannel);
	}
		

	void Start () {
		StartCoroutine(func());
	}


	void Update () {
		// make all blocks move forward; move them back to pool if they are at the ending points
		for(int i=0; i<4; i++) {
			if(blocksInChannel[i].Count > 0) {
				foreach(GameObject tmpBlock in blocksInChannel[i]) {
					tmpBlock.transform.position -= this.transform.forward / speed [i];

					if(this.transform.InverseTransformPoint (tmpBlock.transform.position).z <= -endingPointLocalMin) {
						blocksInPool [i].Enqueue (blocksInChannel[i].Dequeue());
						tmpBlock.transform.position = new Vector3 (100, 0, 0);
					}
				}	
			}
		}
	}
		

	void calculatePosition() {
		// calculate the x-coordinate of 4 channels
		Collider collider = GetComponent<Collider> ();
		Vector3 leftBottomPoint = collider.bounds.min, rightTopPoint = collider.bounds.max;
		float len = (float)((rightTopPoint.x - leftBottomPoint.x) * 0.8);
		leftBottomPoint.x += len / 8;
		rightTopPoint.x -= len / 8;

		// calculate the starting position and ending position
		for(int i=0; i<4; i++) {
			startingPoints [i] = new Vector3 (leftBottomPoint.x + i * len / 3, rightTopPoint.y, rightTopPoint.z);
			endingPoints [i] = new Vector3 (leftBottomPoint.x + i * len / 3, leftBottomPoint.y, leftBottomPoint.z);
		}

		// calculate the local ending position relative to plane
		endingPointLocalMin = (float)(len * 0.55);
	}

	void initiateBlocks(int num) {
		// build 4 pools and 4 channels which contain corresponding blocks
		for(int i=0; i<4; i++) {
			blocksInPool[i] = new Queue<GameObject> ();	
			blocksInChannel [i] = new Queue<GameObject> ();
		}
			
		int tmpIndex = 0;
		for(int i=0; i<4; i++) {
			for(int j=0; j<blockNumPerChannel; j++) {

				// calculate the index
				tmpIndex = i * blockNumPerChannel + j;

				// initiate block
				blockClone[tmpIndex] = Instantiate (prefabBlock, 
					new Vector3(tmpIndex, 100, 0), Quaternion.identity) as GameObject;
				
				blocksInPool[i].Enqueue (blockClone[tmpIndex]);
			}
		}
	}

	void generateBlocks(int channel) {
		if(blocksInPool[channel].Count > 0) {
			GameObject tmpBlock = blocksInPool [channel].Dequeue();
			blocksInChannel [channel].Enqueue (tmpBlock);
			tmpBlock.transform.position = new Vector3 (
				startingPoints [channel].x, startingPoints [channel].y, startingPoints [channel].z);
		}
	}

	IEnumerator func() {
		while(keepPlaying) {
			float tmp = Random.value * 4;
			if(tmp <= 1) {
				generateBlocks (0);
			} else if(tmp <= 2) {
				generateBlocks (1);
			} else if(tmp <= 3) {
				generateBlocks (2);
			} else {
				generateBlocks (3);
			}
			yield return new WaitForSeconds(Random.value / 2);	
		}
	}

}