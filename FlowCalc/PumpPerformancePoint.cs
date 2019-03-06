﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowCalc
{
    [Serializable]
    [DebuggerDisplay("H = {TotalDynamicHead}; Q = {FlowRate}")]
    public class PumpPerformancePoint
    {
        #region Member


        #endregion Member

        #region Properties
        /// <summary>
        /// Gesamtförderhöhe H
        /// in m
        /// </summary>
        public double TotalDynamicHead { get; set; }

        /// <summary>
        /// Förderstrom Q
        /// in [m^3/h]
        /// </summary>
        public double FlowRate { get; set; }

        #endregion Properties

        #region Constructor
        /// <summary>
        /// Konstruktor
        /// </summary>
        public PumpPerformancePoint()
        {

        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="flow">Förderstrom Q in [m^3/h]</param>
        /// <param name="head">Gesamtförderhöhe H in m</param>
        public PumpPerformancePoint(double head, double flow)
        {
            TotalDynamicHead = head;
            FlowRate = flow;
        }

        #endregion Constructor

        #region Services


        #endregion Services

        #region Internal services


        #endregion Internal services

        #region Events


        #endregion Events
    }
}
