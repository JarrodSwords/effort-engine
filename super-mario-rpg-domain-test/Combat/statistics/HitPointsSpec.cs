﻿using Effort.Domain;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Domain.Test.Combat
{
    public class HitPointsSpec : StatisticSpec
    {
        #region Protected Interface

        protected override ValueObject Create() => new HitPoints(1);
        protected override ValueObject CreateOther() => new HitPoints(2);

        #endregion
    }
}
