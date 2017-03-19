﻿#region copyright
// Copyright (c) 2017 All Rights Reserved
// Author: İsmail Kundakcı
// Author Website: www.ismailkundakci.com
// Author Email: ism.kundakci@hotmail.com
// Date: 19/03/2017 13:15:00
// Description: OrangeDNS is a powerfull dns firewall solution written by C#
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrangeDNS.UI.Model
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}