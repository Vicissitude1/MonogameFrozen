﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frozen
{
    enum DIRECTION { Front, Back, Left, Right };
    interface IStrategy

    {
        void Execute(ref DIRECTION currentDirection);
    }
}
