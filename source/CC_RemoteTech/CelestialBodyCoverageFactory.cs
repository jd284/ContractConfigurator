﻿using ContractConfigurator.Parameters;
using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContractConfigurator;
using UnityEngine;
using RemoteTech;

namespace ContractConfigurator.RemoteTech
{
    public class CelestialBodyCoverageFactory : ParameterFactory
    {
        protected double coverage;

        public override bool Load(ConfigNode configNode)
        {
            // Load base class
            bool valid = base.Load(configNode);

            // Before loading, verify the RemoteTech version
            valid &= Util.VerifyRemoteTechVersion();

            valid &= ConfigNodeUtil.ParseValue<double>(configNode, "coverage", x => coverage = x, this, 1.0, x => Validation.BetweenInclusive(x, 0.0, 1.0));
            valid &= ValidateTargetBody(configNode);

            return valid;
        }

        public override ContractParameter Generate(Contract contract)
        {
            return new CelestialBodyCoverageParameter(coverage, targetBody, title);
        }
    }
}
