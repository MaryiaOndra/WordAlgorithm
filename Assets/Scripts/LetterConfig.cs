namespace WordAlgorithm
{
    public class LetterConfig
    {
        public string Letter { get; } 
        public int RowIndex{ get; } 
        public int ColumnIndex{ get; } 

        public LetterConfig(string letter, int rowIndex, int columnIndex)
        {
            Letter = letter;
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
        }
    }
}