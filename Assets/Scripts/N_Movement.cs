using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DarkRift;


public class N_Movement : MonoBehaviour {

    public ushort networkID;
    public bool isMine;

    Vector3 lastPosition;
    Quaternion lastRotation;

    //public GameObject playerObject;

    // Use this for initialization
    void Start () {
        if (isMine)
        {
            DarkRiftAPI.onDataDetailed += OnDataRecieved;

            DarkRiftAPI.onPlayerDisconnected += PlayerDisconnected;

            gameObject.GetComponent<MouseLock>().enabled = true;
            gameObject.GetComponent<MouseLook>().enabled = true;
            gameObject.GetComponent<Pl_Controller>().enabled = true;
            gameObject.GetComponent<InputManager>().enabled = true;
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(true);

        }
	}

    // Update is called once per frame
    void Update()
    {
        if (DarkRiftAPI.isConnected && DarkRiftAPI.id == networkID)
        {
            //Serialize if the position or rotation changes
            if (transform.position != lastPosition)
                DarkRiftAPI.SendMessageToOthers(TagIndex.PlayerUpdate, TagIndex.PlayerUpdateSubjects.Position, transform.position);
            //SerialisePos(transform.position);

            if (transform.rotation != lastRotation)
                DarkRiftAPI.SendMessageToOthers(TagIndex.PlayerUpdate, TagIndex.PlayerUpdateSubjects.Rotation, transform.rotation);
            //SerialiseRot(transform.rotation);

            //Update stuff
            lastPosition = transform.position;
            lastRotation = transform.rotation;
        }

    }
    /*
    void SerialisePos(Vector3 pos)
    {
        //Serilize the position ORDER MATTERS
        using (DarkRiftWriter writer = new DarkRiftWriter())
        {
            //Next we write any data to the writer, as we never change the z pos there's no need to 
            //send it.
            writer.Write(pos.x);
            writer.Write(pos.y);
            writer.Write(pos.z);

            Debug.Log("Seralisinzg");
            DarkRiftAPI.SendMessageToOthers(TagIndex.PlayerUpdate, TagIndex.PlayerUpdateSubjects.Position, writer);
        }
    }

    void SerialiseRot(Quaternion rot)
    {
        //Serilize the rotation ORDER MATTERS
        using (DarkRiftWriter writer = new DarkRiftWriter())
        {
            //Write the data
            writer.Write(rot.x);
            writer.Write(rot.y);
            writer.Write(rot.z);
            writer.Write(rot.w);
            Debug.Log("Seralisinzgrot");
            DarkRiftAPI.SendMessageToOthers(TagIndex.PlayerUpdate, TagIndex.PlayerUpdateSubjects.Rotation, writer);
        }
    }
    */
    void OnDataRecieved(ushort senderID, byte tag, ushort subject, object data) {
        Debug.Log("Recieve");
        if (senderID == networkID)
        {
            if (tag == TagIndex.PlayerUpdate)
            {
                Debug.Log("PlayerUpdate");
                //update our position
                if (subject == TagIndex.PlayerUpdateSubjects.Position)
                {
                    Debug.Log("Position");
                    transform.position = (Vector3)data;
                    // DeserialisePos(data);
                }

                //update our rotation
                if (subject == TagIndex.PlayerUpdateSubjects.Rotation)
                {
                    Debug.Log("Rotation");
                    transform.rotation = (Quaternion)data;
                    // DeserialiseRot(data);
                }

            }


        }
    }
   /* void DeserialisePos(object data)
    {
        //Here we decode the stream, the data will arrive as a DarkRiftReader so we need to cast to it
        if (data is DarkRiftReader)
        {
       
            using (DarkRiftReader reader = (DarkRiftReader)data)
            {
                //Then read!
                transform.position = new Vector3(
                    (float)reader.ReadDouble(),
                    (float)reader.ReadDouble(),
                    (float)reader.ReadDouble()
                );
            }
        }
    }
    void DeserialiseRot(object data)
    {
        if (data is DarkRiftReader)
        {
            //Read the rotation
            using(DarkRiftReader reader = (DarkRiftReader)data)
            {
                transform.rotation = new Quaternion(
                    (float)reader.ReadDouble(),
                    (float)reader.ReadDouble(),
                    (float)reader.ReadDouble(),
                    (float)reader.ReadDouble()
                    );
            }
        }
        
    } */
    void PlayerDisconnected(ushort ID) { 

        //Get rid of gameobject

        if (ID == networkID)
        {
            Destroy(gameObject);
        }
    }
}
