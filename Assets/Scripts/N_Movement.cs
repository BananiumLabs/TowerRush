using UnityEngine;
using DarkRift;


public class N_Movement : MonoBehaviour {

    public ushort networkID;
    public bool isMine;

    public Animator anim;
    public Pl_Values plValues;
    public GameObject gui;

    Vector3 lastPosition;
    Quaternion lastRotation;
    

    //public GameObject playerObject;

    // Use this for initialization
    void Start () {
        DarkRiftAPI.onDataDetailed += OnDataRecieved;

        DarkRiftAPI.onPlayerDisconnected += PlayerDisconnected;

        if (isMine)
        {
            gui.SetActive(true);
            gameObject.GetComponent<Pl_MouseLook>().enabled = true;
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
            if (Vector3.Distance(lastPosition, transform.position) >= 1)
            {
                //DarkRiftAPI.SendMessageToOthers(TagIndex.PlayerUpdate, TagIndex.PlayerUpdateSubjects.Position, transform.position);
                SerialisePosA(transform.position);
                lastPosition = transform.position;
            }
            if (Quaternion.Angle(lastRotation,transform.rotation) > 45)
            {
                DarkRiftAPI.SendMessageToOthers(TagIndex.PlayerUpdate, TagIndex.PlayerUpdateSubjects.Rotation, transform.rotation); 
            }
            //SerializeAnim();
            //Update stuff
           
            lastRotation = transform.rotation;
        }
        
        
        //Animation Settings
        anim.SetBool("IsRunning", plValues.running);
        anim.SetBool("IsGrounded", plValues.grounded);
        anim.SetInteger("State", plValues.state);
        anim.SetFloat("Speed", plValues.speed);
        anim.SetFloat("Horizontal", plValues.hor);
        anim.SetFloat("Vertical", plValues.ver);
    }


    void SerialisePosA(Vector3 pos)
    {
        //Serialise Position and Animation Values
        using (DarkRiftWriter writer = new DarkRiftWriter())
        {
            //Next we write any data to the writer
            writer.Write(pos.x);
            writer.Write(pos.y);
            writer.Write(pos.z);

            SerializeAnim();
            /*
            writer.Write(anim.GetBool("IsRunning"));
            writer.Write(anim.GetBool("IsGrounded"));
            writer.Write(anim.GetInteger("State"));
            writer.Write(anim.GetFloat("Speed"));
            writer.Write(anim.GetFloat("Horizontal"));
            writer.Write(anim.GetFloat("Vertical"));*/

            Debug.Log("Serialize");
            DarkRiftAPI.SendMessageToOthers(TagIndex.PlayerUpdate, TagIndex.PlayerUpdateSubjects.Position, writer);
        }
    }

    void DeserialisePosA(object data)
    {

        if (data is DarkRiftReader)
        {
            using (DarkRiftReader reader = (DarkRiftReader)data)
            {
                //Then read!

                transform.position = new Vector3(
                    reader.ReadSingle(),
                    reader.ReadSingle(),
                    reader.ReadSingle()
                );
                //transform.position = Vector3.Lerp(transform.position, new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle()), Time.deltaTime*25);
                
                /*
                plValues.running = reader.ReadBoolean();
                plValues.grounded = reader.ReadBoolean();
                plValues.state = reader.ReadInt32();
                plValues.speed = reader.ReadSingle();
                plValues.hor = reader.ReadSingle();
                plValues.ver = reader.ReadSingle();*/
            }
        }
        else
        {
            Debug.LogError("Should have recieved a DarkRiftReciever but didn't! (Got: " + data.GetType() + ")");
            transform.position = transform.position;
        }
    }

    void SerializeAnim()
    {
        using (DarkRiftWriter writer = new DarkRiftWriter())
        {
            
            writer.Write(anim.GetBool("IsRunning"));
            writer.Write(anim.GetBool("IsGrounded"));
            writer.Write(anim.GetInteger("State"));
            writer.Write(anim.GetFloat("Speed"));
            writer.Write(anim.GetFloat("Horizontal"));
            writer.Write(anim.GetFloat("Vertical"));

            Debug.Log("Serialize");
            DarkRiftAPI.SendMessageToOthers(TagIndex.PlayerUpdate, TagIndex.PlayerUpdateSubjects.Animation, writer);
        }
    }

    void DeserialiseAnim(object data)
    {

        if (data is DarkRiftReader)
        {
            using (DarkRiftReader reader = (DarkRiftReader)data)
            {
               
                plValues.running = reader.ReadBoolean();
                plValues.grounded = reader.ReadBoolean();
                plValues.state = reader.ReadInt32();
                plValues.speed = reader.ReadSingle();
                plValues.hor = reader.ReadSingle();
                plValues.ver = reader.ReadSingle();
            }
        }
        else
        {
            Debug.LogError("Should have recieved a DarkRiftReciever but didn't! (Got: " + data.GetType() + ")");
            transform.position = transform.position;
        }
    }
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
                    Debug.Log("De Position");
                    DeserialisePosA(data);
                    transform.position = (Vector3)data;
                    //Vector3.Lerp(transform.position, (Vector3)data, Time.deltaTime * 5);
                   
                }

                //update our rotation
                if (subject == TagIndex.PlayerUpdateSubjects.Rotation)
                {
                    Debug.Log("Rotation");
                    //Quaternion.Lerp(transform.rotation, (Quaternion)data, Time.deltaTime * 5);
                    transform.rotation = (Quaternion)data;
                  
                }
                if (subject == TagIndex.PlayerUpdateSubjects.Animation)
                {
                    DeserialiseAnim(data);
                }
            }


        }
    }
  
    
        
     
    void PlayerDisconnected(ushort ID) { 

        //Get rid of gameobject

        if (ID == networkID)
        {
            DestroyImmediate(gameObject);
        }
        return;
    }
}
