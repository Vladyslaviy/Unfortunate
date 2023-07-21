using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.IO;

public class Multiplayer : MonoBehaviour
{
    int port = 5340;
    string server_ip = "73.193.125.176";
    TcpClient server = new TcpClient();
    int others_player_count = 0;
    NetworkStream nwStream;
    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists(@"C:\GameServer"))
        {
            server_ip = "10.0.0.174";
        }
        Connect();
    }
    async void Connect()
    {
        //---data to send to the server---
        string textToSend = DateTime.Now.ToString();

        //---create a TCPClient object at the IP and port no.---
        while (!server.Connected)
        {
            try
            {
                await server.ConnectAsync(server_ip, port);
            }
            catch (Exception)
            {
                continue;
            }

        }

        nwStream = server.GetStream();

        while (true)
        {
            if (server.Connected)
            {
                //Debug.LogWarning("Server alive!");
            }
            byte[] bytesToRead = new byte[1024];
            if (nwStream.CanWrite)
            {
                await nwStream.ReadAsync(bytesToRead, 0, 1024);
            }
            string message = ASCIIEncoding.ASCII.GetString(bytesToRead).TrimEnd('\0');
            message.Trim();
            if (message.Contains("NewPl"))
            {
                NewPl();
            }
            await Task.Delay(100);
        }




    }
    void NewPl()
    {
        Vector3 vector3 = new Vector3(10, 10, 10);
        others_player_count++;
        NewPlayerObject.name = "Player " + others_player_count;
        NewPlayerObject.transform.position = vector3;
        newPlayers.Add(new Player(Instantiate(NewPlayerObject)));
        Debug.LogWarning("NewPlayerObject");
    }
    public GameObject NewPlayerObject;
    List<Player> newPlayers = new List<Player>();
    // Update is called once per frame
    async void Update()
    {
        try
        {

            string data_transform = "";
            data_transform += "px" + this.transform.position.x + '|';
            data_transform += "py" + this.transform.position.y + '|';
            data_transform += "pz" + this.transform.position.z + '|';
            data_transform += "rx" + this.transform.eulerAngles.x + '|';
            data_transform += "ry" + this.transform.eulerAngles.y + '|';
            data_transform += "rz" + this.transform.eulerAngles.z + '|';
            //Debug.Log(transform.rotation.w);
            if (nwStream.CanWrite)
            {
                await nwStream.FlushAsync();
                await nwStream.WriteAsync(ASCIIEncoding.ASCII.GetBytes(data_transform));
            }
        }
        catch (Exception)
        {
        }
        try
        {

                for (int i = 0; i < newPlayers.Count; i++)
                {
                    byte[] bytesToRead = new byte[1024];
                    await nwStream.ReadAsync(bytesToRead, 0, 1024);
                    string message = ASCIIEncoding.ASCII.GetString(bytesToRead).TrimEnd('\0');
                    if (message.Contains("NewPl"))
                    {
                        NewPl();
                        i--;
                        continue;
                    }
                    if (message.Length < 5)
                    {
                        continue;
                    }
                    string px_s, py_s, pz_s;
                    string rx_s, ry_s, rz_s;
                    try
                    {
                        //Debug.Log(message);
                        px_s = message.Substring(message.IndexOf("px") + 2, message.IndexOf("|") - 2);
                        message = message.Remove(0, message.IndexOf("|") + 1);
                        py_s = message.Substring(message.IndexOf("py") + 2, message.IndexOf("|") - 2);
                        message = message.Remove(0, message.IndexOf("|") + 1);
                        pz_s = message.Substring(message.IndexOf("pz") + 2, message.IndexOf("|") - 2);
                        message = message.Remove(0, message.IndexOf("|") + 1);

                        rx_s = message.Substring(message.IndexOf("rx") + 2, message.IndexOf("|") - 2);
                        message = message.Remove(0, message.IndexOf("|") + 1);
                        ry_s = message.Substring(message.IndexOf("ry") + 2, message.IndexOf("|") - 2);
                        message = message.Remove(0, message.IndexOf("|") + 1);
                        rz_s = message.Substring(message.IndexOf("rz") + 2, message.IndexOf("|") - 2);

                        Vector3 position_ = new Vector3();
                        position_.x = float.Parse(px_s, CultureInfo.InvariantCulture.NumberFormat);
                        position_.y = float.Parse(py_s, CultureInfo.InvariantCulture.NumberFormat);
                        position_.z = float.Parse(pz_s, CultureInfo.InvariantCulture.NumberFormat);

                        Vector3 eulerAngles_ = new Vector3();
                        eulerAngles_.x = float.Parse(rx_s, CultureInfo.InvariantCulture.NumberFormat);
                        eulerAngles_.y = float.Parse(ry_s, CultureInfo.InvariantCulture.NumberFormat);
                        eulerAngles_.z = float.Parse(rz_s, CultureInfo.InvariantCulture.NumberFormat);

                        newPlayers[i].gameObject.transform.position = position_;
                        newPlayers[i].gameObject.transform.eulerAngles = eulerAngles_;

                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
        }
        catch (Exception)
        {
        }
        await Task.Delay(2);

    }
    ~Multiplayer()
    {
        server.Close();
    }
}
class Player
{
    public GameObject gameObject;
    public Player(GameObject gameObject)
    {
        this.gameObject = gameObject;
    }
};
