using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace WordAlgorithm
{
    public class ConfigLoader
    {
        public GridConfig LoadConfigByName(string filename)
        {
            //TODO: Add async operation
            var jsonText = Resources.Load<TextAsset>($"JSONConfigs/{filename}");
            return JsonConvert.DeserializeObject<GridConfig>(jsonText.text);
        }
    }
    
    [Serializable]
    public class GridConfig
    {
        public List<List<string>> grid;
        public string failReaction;
    }
}
