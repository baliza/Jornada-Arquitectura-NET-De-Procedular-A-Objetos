﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Painters.Core
{
    public class PaintersCompany
    {
        private readonly IEnumerable<IPainter> _painters;

        public PaintersCompany(IEnumerable<IPainter> painters)
        {
            _painters = painters;
        }
        public IPainter FindCheapestPainter(double sqMeters )
        {
            double bestPrice = 0;
            IPainter cheapest = null;
            foreach (var painter in _painters)
            {
                if (painter.Status == PainterStatus.Available)
                {
                    double price = painter.EstimatePrice(sqMeters);
                    if (cheapest == null || price < bestPrice)
                    {
                        cheapest = painter;
                        bestPrice = price;
                    }
                }
            }
            return cheapest;
        }

        public IPainter FindFasterPainter(double sqMeters)
        {
            TimeSpan lessTime = default;
            IPainter faster = null;
            foreach (var painter in _painters)
            {
                if (painter.Status == PainterStatus.Available)
                {
                    TimeSpan time = painter.EstimateTimeToPaint(sqMeters);
                    if (faster == null || time < lessTime)
                    {
                        faster = painter;
                        lessTime = time;
                    }
                }
            }
            return faster;
        }
    }
}
