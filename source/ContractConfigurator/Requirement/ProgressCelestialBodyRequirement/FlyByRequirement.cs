﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP;
using KSPAchievements;
using KSP.Localization;

namespace ContractConfigurator
{
    /// <summary>
    /// ContractRequirement to provide requirement for player having performed done a fly by of a specific CelestialBody.
    /// </summary>
    public class FlyByRequirement : ProgressCelestialBodyRequirement
    {
        public override bool LoadFromConfig(ConfigNode configNode)
        {
            // Disallow Kerbin
            allowKerbin = false;
            return base.LoadFromConfig(configNode);
        }

        protected override ProgressNode GetTypeSpecificProgressNode(CelestialBodySubtree celestialBodySubtree)
        {
            return celestialBodySubtree.flyBy;
        }

        public override bool RequirementMet(ConfiguredContract contract)
        {
            return base.RequirementMet(contract) &&
                GetCelestialBodySubtree().IsComplete;
        }
    }
}
