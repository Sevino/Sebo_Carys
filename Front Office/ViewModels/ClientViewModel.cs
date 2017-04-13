using Front_Office.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front_Office.ViewModels
{
    public class ClientViewModel
    {         
        public Client Client { get; set; }
        public bool Connecte { get; set; }
        public string Message { get; set; }
    }
}