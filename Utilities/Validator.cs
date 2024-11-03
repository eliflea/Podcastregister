namespace utilities

{
    public static class Validator
    {
        public static bool IsValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out _);
        }

        public static bool IsNotEmpty(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        // Kontrollera om kategori är giltig och inte tom
        public static bool IsValidCategory(string category)
        {
            return !string.IsNullOrWhiteSpace(category) && category.Length >= 3;
        }

        // Kontrollera om kategori är unik
        public static bool IsUniqueCategory(string category, IEnumerable<string> existingCategories)
        {
            return !existingCategories.Contains(category, StringComparer.OrdinalIgnoreCase);
        }

    }

}