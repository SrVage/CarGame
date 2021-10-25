﻿using UnityEngine;

namespace Code.Model.Config
{
    [CreateAssetMenu (order = 3, fileName = "UpgradeRepository", menuName = "Config/Inventory/UpgradeRepository")]
    public class UpgradeItemRepository:ScriptableObject
    {
        public UpgradeItemConfig[] UpgradeItemConfigs;
    }
}