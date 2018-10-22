﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CommandInputs.extensions
{
    public static class FileExt
    {
        public static bool IsNotValidPath(this string path)
        {
            return !File.Exists(path);
        }
    }
}
