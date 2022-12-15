using System.Collections.Generic;
using WordAlgorithm.Configs;

namespace WordAlgorithm.Interfaces
{
    public interface IWordOrganizer
    {
        void OrganizeWordList(List<List<string>> gridConfig);
        Dictionary<string, List<LetterConfig>> LettersConfigs { get; }
    }
}