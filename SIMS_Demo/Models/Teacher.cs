﻿using Microsoft.AspNetCore.Authentication;
using System.Reflection.Metadata;

namespace SIMS_Demo.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DoB {  get; set; }

    }
}
