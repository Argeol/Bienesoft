﻿namespace Bienesoft.Models
{
    public class ConfigServer
    {
        public string HostName { get; set; }
        public int PortHost { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
    }
    public class ResponseSend 
    {
        public bool Status { get; set; }
        public String Message { get; set; }
    }
}

