namespace KursovayaBlazorNet6.BlazorComponents
{
    public class PageLink
    {
        public int Index { get; set; }

        public string ActiveString { get; set; }

        public static List<PageLink> GetPageLinks(int start, int total)
        {
            int delta = total - start;
            int count = delta < 10 ? delta : 10;

            return Enumerable.Range(start, count + 1)
                .Select(n => new PageLink { Index = n })
                .ToList();
        }
    }
}
