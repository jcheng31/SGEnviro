﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SGEnviro.Forecasts
{
    public class PsiUpdate
    {
        public PsiRegionalUpdate National { get; set; }
        public PsiRegionalUpdate Central { get; set; }
        public PsiRegionalUpdate East { get; set; }
        public PsiRegionalUpdate North { get; set; }
        public PsiRegionalUpdate South { get; set; }
        public PsiRegionalUpdate West { get; set; }

        /// <summary>
        /// Constructs a PsiUpdate from an XElement. Expects the XElement to be the root node (channel)
        /// in NEA's PSI API response.
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        public static PsiUpdate FromXElement(XElement channel)
        {
            var regionElements = channel.Descendants("region");
            var updates = regionElements.Select(PsiRegionalUpdate.FromXElement);

            var update = new PsiUpdate();
            foreach (var regionalUpdate in updates)
            {
                switch(regionalUpdate.Region)
                {
                    case Region.National:
                        update.National = regionalUpdate;
                        break;
                    case Region.Central:
                        update.Central = regionalUpdate;
                        break;
                    case Region.East:
                        update.East = regionalUpdate;
                        break;
                    case Region.North:
                        update.North = regionalUpdate;
                        break;
                    case Region.South:
                        update.South = regionalUpdate;
                        break;
                    case Region.West:
                        update.West = regionalUpdate;
                        break;
                }
            }

            return update;
        }
    }
}
