﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherForcast.Application.Models
{
    public class WeatherItem
    {
        public string State { get; set; }
        public string StateAbbreviation { get; set; }
        public DateTime ApplicableDate { get; set; }
    }
}