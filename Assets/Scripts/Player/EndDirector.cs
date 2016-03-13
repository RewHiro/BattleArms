using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using System.Collections;

public class EndDirector : NetworkBehaviour
{

    [SerializeField]
    Text text_ = null;

    [SerializeField]
    Text score_ = null;

    [SerializeField]
    Text hi_score_text_ = null;

    int hi_score_ = 0;

    bool is_director_ = false;
    
    [SerializeField]
    GameObject text_object_ = null;

    IEnumerator ChangeColor()
    {

        while (true)
        {
            hi_score_text_.color = UnityEngine.Random.ColorHSV();

            yield return new WaitForSeconds(0.1f);
        }
    }

    [ClientRpc]
    public void RpcTellClientStart(string str)
    {
        Debug.Log("OK");
        text_object_.SetActive(true);
        text_.text = str;
        score_.gameObject.SetActive(false);
        hi_score_text_.gameObject.SetActive(false);
    }

    [ClientRpc]
    public void RpcTellClientTime(int current_count)
    {

        int min = current_count / 60;
        int sec = current_count % 60;

        int ten_sec = sec / 10;
        int one_sec = sec % 10;

        score_.text = "クリア時間:" + min.ToString() + ":" + ten_sec.ToString() + one_sec.ToString();
        score_.gameObject.SetActive(true);
        hi_score_text_.gameObject.SetActive(true);

        if (current_count > hi_score_) return;
        if (is_director_) return;
        is_director_ = true;

        {
            var path = Application.dataPath + "/" + "ranki.txt";
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(fs);

            if (writer != null)
            {
                writer.Write(current_count);
                writer.Close();
            }
        }

        StartCoroutine(ChangeColor());
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
    }

    void Start()
    {
        if (!isLocalPlayer) return;

        var path = Application.dataPath + "/" + "ranki.txt";

        if (!File.Exists(path))
        {
            {
                FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                BinaryWriter writer = new BinaryWriter(fs);

                if (writer != null)
                {
                    writer.Write(60 * 5);
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
                hi_score_ = i;
            }
        }

        int min = hi_score_ / 60;
        int sec = hi_score_ % 60;

        int ten_sec = sec / 10;
        int one_sec = sec % 10;

        hi_score_text_.text = "最短クリア時間" + min.ToString() + ":" + ten_sec.ToString() + one_sec.ToString();
    }

}
