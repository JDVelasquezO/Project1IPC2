﻿using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Module_Logic
    {
        Module_Data module_Data = new Module_Data();

        public List<Module_Entity> listModule()
        {
            return module_Data.listModule();
        }
    }
}