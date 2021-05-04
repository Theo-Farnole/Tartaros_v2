// Copyright © 2018 Procedural Worlds Pty Limited.  All Rights Reserved.
using UnityEngine;
using UnityEditor;

namespace PWCommon2
{
    public class PWEditor : Editor, IPWEditor
    {
        // These don't do anything on an Editor but need the common interface for standalone editors.
        public Rect position { get; set; }
        public bool maximized { get; set; }

        public bool PositionChecked { get; set; }
    }
}
