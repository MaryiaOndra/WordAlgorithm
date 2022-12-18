using UnityEngine;

namespace WordAlgorithm.Configs
{
    public struct LetterConfig
    {
        public string Letter { get; }

        /// <summary>
        /// position of the cell where X is row, Y is column
        /// </summary>
        public Vector2 Position { get; }

        public LetterConfig(string letter, int rowIndex, int columnIndex)
        {
            Letter = letter;
            Position = new Vector2(rowIndex, columnIndex);
        }
    }
}