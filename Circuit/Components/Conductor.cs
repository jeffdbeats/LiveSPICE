﻿using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyMath;

namespace Circuit
{
    /// <summary>
    /// This component isn't useful. It is present for completeness.
    /// </summary>
    [CategoryAttribute("Standard")]
    [DisplayName("Wire")]
    public class Conductor : PassiveTwoTerminal
    {
        public Conductor() { Name = "_1"; }

        public override void Analyze(ModifiedNodalAnalysis Mna) 
        {
            i = Mna.AddNewUnknown("i" + Name);
            Mna.AddEquation(Anode.V, Cathode.V);
        }

        public static Expression Analyze(ModifiedNodalAnalysis Mna, Expression V)
        {
            Expression i = Mna.AddNewUnknown();
            Mna.AddEquation(V, Constant.Zero);
            return i;
        }
        
        protected override void DrawSymbol(SymbolLayout Sym) { Sym.AddWire(Anode, Cathode); }
    }
}