namespace Ch_3
{
    class UrlDetails
    {
        public string Url { get; set; }

        public int ContentLength { get; set; }

        public override string ToString() => $"Url: {Url} => Length: {ContentLength}";
    }
}