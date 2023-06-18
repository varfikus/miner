namespace CommonTypes
{
    public class BoardCell
    {
        public CellType Type { get; set; }
        public int? NearBombCount { get; set; }
        public bool IsOpen { get; set; }
        public bool IsFlag { get; set; }
    }

    public enum CellType { Bomb, Void }
}
