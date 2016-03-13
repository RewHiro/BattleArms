using UnityEngine;
using System.IO;
using System.Text;

public class JumpTest : MonoBehaviour {


    float count_ = 0.0f;

	// Use this for initialization
	void Start ()
    {
        var path = Application.dataPath + "/" + "ranki.txt";

        if (!File.Exists(path))
        {
            {
                FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                BinaryWriter writer = new BinaryWriter(fs);

                if (writer != null)
                {
                    writer.Write(100000);
                    writer.Close();
                }
            }
        }

        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(fs);

            if (reader != null)
            {
                var i = reader.ReadInt32();
                reader.Close();
                Debug.Log(i);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        count_ += Time.deltaTime;

        if (count_ >= 3.0f)
        {
            count_ = 0.0f;
            GetComponent<Rigidbody>().AddForce(Vector3.up * 1000, ForceMode.Impulse);
        }
	}
}
