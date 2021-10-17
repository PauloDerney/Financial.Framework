namespace Financial.Framework.Hateos
{
    public struct Link
    {
        public Link(string href, string rel, MethodType method)
        {
            Href = href;
            Rel = rel;
            Method = method.ToString();
        }

        public string Href { get; set; }

        public string Rel { get; set; }

        public string Method { get; set; }

        public static Link CreateLinkToGet(string baseHref, string href, string rel)
            => new Link($"{baseHref}/{href}", rel, MethodType.Get);

        public static Link CreateLinkToPost(string baseHref, string href, string rel)
            => new Link($"{baseHref}/{href}", rel, MethodType.Post);

        public static Link CreateLinkToPatch(string baseHref, string href, string rel)
            => new Link($"{baseHref}/{href}", rel, MethodType.Patch);

        public static Link CreateLinkToPut(string baseHref, string href, string rel)
            => new Link($"{baseHref}/{href}", rel, MethodType.Put);

        public static Link CreateLinkToDelete(string baseHref, string href, string rel)
            => new Link($"{baseHref}/{href}", rel, MethodType.Delete);
    }
}