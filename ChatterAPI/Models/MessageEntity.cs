﻿namespace ChatterAPI
{
    public class MessageEntity
    {
        public int id { get; set; }
        public string? content { get; set; }
        public DateTime created { get; set; }
        public Boolean sent { get; set; }
       
    }
}
