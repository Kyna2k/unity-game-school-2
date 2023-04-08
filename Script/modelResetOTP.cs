using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modelResetOTP 
{
    public modelResetOTP(string username, string newpassword, string otp)
    {
        this.username = username;
        this.newpassword = newpassword;
        this.otp = otp;
    }

    // Start is called before the first frame update
    public string username { get; set; }
    public string newpassword { get; set; }
    public string otp { get; set; }
}
