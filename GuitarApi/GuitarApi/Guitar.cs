namespace GuitarApi
{
    [TableName("Products")]
    public class Guitar
    {
        public string ProductID { get; set; }

        public string Company { get; set; }

        public string Model { get; set; }

        public string Description { get; set; }

        public string BodyType { get; set; }

        public string TotalFrets { get; set; }

        public string FinishTop { get; set; }

        public string FinishNeck { get; set; }

        public string FinishBackSides { get; set; }

        public string Price { get; set; }

        public string Url { get; set; }
    }
}
