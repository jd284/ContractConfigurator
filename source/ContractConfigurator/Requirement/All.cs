﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP;
using KSPAchievements;
using ContractConfigurator.Util;
using KSP.Localization;

namespace ContractConfigurator
{
    /// <summary>
    /// ContractRequirement set requirement.  Requirement is met if all child requirements are met.
    /// </summary>
    public class AllRequirement : ContractRequirement
    {
        public override bool LoadFromConfig(ConfigNode configNode)
        {
            // Load base class
            bool valid = base.LoadFromConfig(configNode);

            // Not invertable
            valid &= ConfigNodeUtil.ParseValue<bool>(configNode, "invertRequirement", x => invertRequirement = x, this, false, x => Validation.EQ(x, false));

            return valid;
        }

        public override bool RequirementMet(ConfiguredContract contract)
        {
            bool requirementMet = true;
            foreach (ContractRequirement requirement in childNodes)
            {
                if (requirement.enabled)
                {
                    requirementMet &= requirement.CheckRequirement(contract);
                }
            }
            return requirementMet;
        }

        public override void OnLoad(ConfigNode configNode) { }
        public override void OnSave(ConfigNode configNode) { }

        protected override string RequirementText()
        {
            return Localizer.Format("#cc.req.All", MissionControlUI.RequirementHighlightColor);
        }
    }
}
