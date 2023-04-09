using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserModel 
{
    public UserModel() { }
    public UserModel(string username, string password) {
        this.username = username;
        this.password = password;
    }
    public string username { get; set; }
    public string password { get; set; }
    public string score { get; set; }
    public string positionZ { get; set; }
    public string positionY { get; set; }
    public string positionX { get; set; }
    public string newpassword { get; set; }

}
