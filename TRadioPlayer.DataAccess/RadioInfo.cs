namespace TRadioPlayer.DataAccess
{
    public class RadioInfo
    {
        public int Index { get; set; }
        public string Title { get; set; }
        public string StreamUrl { get; set; }
        public string StreamUrl2 { get; set; }
        public string StreamUrl3 { get; set; }
        public string HomePage { get; set; }
        public int CategoryId { get; set; }
        public bool Active { get; set; }
        public bool Faved { get; set; }

        public RadioInfo()
        {
            Active = true;
            Faved = false;
        }
    }
}
